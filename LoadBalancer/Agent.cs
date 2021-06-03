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
        public Agent(Socket connection)
        {
            _connectionSocket = connection;
            AgentId = _connectionSocket.GetHashCode();
            Tasks = new Dictionary<Guid, Tuple<Task, Callback>>();
            _listenerTask = new System.Threading.Tasks.Task(ResultListener);
            _listenerTask.Start();
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
            Tasks.Add(task.Id, new Tuple<Task, Callback>(task, callback));
            _connectionSocket.Send(JsonSerializer.SerializeToUtf8Bytes(task));
            Console.WriteLine("Agent " + AgentId + " added task " + task.Id);
        }
        private byte[] GetPrefix(byte[] buffer, int count)
        {
            byte[] result = new byte[count];
            Array.Copy(buffer, result, count);
            return result;
        }

        private void ResultListener()
        {
            byte[] buffer = new byte[_bufferSize];
            while (_connectionSocket.Connected)
            {
                int n = _connectionSocket.Receive(buffer);
                Task completedTask = JsonSerializer.Deserialize<Task>(GetPrefix(buffer, n));
                Tasks[completedTask.Id].Item2(completedTask);
            }
        }
        
        public bool IsAlive()
        {
            return _connectionSocket.Poll(1000000, SelectMode.SelectRead);
        }

    }
}