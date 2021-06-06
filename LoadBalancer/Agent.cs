using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text.Json;

namespace LoadBalancer
{ 
    public class Agent
    {
        public delegate void Callback(Task task);
        private const int _bufferSize = 1024 * 1024;
        private System.Threading.Tasks.Task _listenerTask;
        private Socket _connectionSocket;
        private SortedSet<Task> _backloadTasks;
        public bool IsAlive { get; set; }
        public Agent(Socket connection, ref SortedSet<Task> backload)
        {
            _connectionSocket = connection;
            AgentId = _connectionSocket.GetHashCode();
            Tasks = new Dictionary<Guid, Tuple<Task, Callback>>();
            _listenerTask = new System.Threading.Tasks.Task(ResultListener);
            _listenerTask.Start();
            IsAlive = true;
            _backloadTasks = backload;
        }
        public int AgentId
        {
            get;
            set;
        }

        public Dictionary<Guid, Tuple<Task, Callback>> Tasks
        {
            get;
        }

        public void AddTask(Task task, Callback callback)
        {
            try
            {
                Tasks.Add(task.Id, new Tuple<Task, Callback>(task, callback));
                TaskSender.SendTask(task, _connectionSocket);
                Console.WriteLine("Agent " + AgentId + " added task " + task.Id);
            }
            catch (Exception e)
            {
                IsAlive = false;
                Console.WriteLine(e.Message);
                ShutDown();
            }
        }

        public void ShutDown()
        {
            foreach (var task in Tasks)
            {
                _backloadTasks.Add(task.Value.Item1);
            }
            Tasks.Clear();
        }
        private void ResultListener()
        {
            byte[] buffer = new byte[_bufferSize];
            try
            {
                while (_connectionSocket.Connected)
                {
                    Task completedTask = TaskSender.RecieveTask(_connectionSocket);
                    Tasks[completedTask.Id].Item2(completedTask);
                    Tasks.Remove(completedTask.Id);
                }
            }
            catch (Exception e)
            {
                IsAlive = false;
                Console.WriteLine(e.Message);
                ShutDown();
            }
        }
    }
}