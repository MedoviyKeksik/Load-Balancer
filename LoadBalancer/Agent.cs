using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text.Json;

namespace LoadBalancer
{
    public class Agent
    {
        private const int _bufferSize = 1024 * 1024;
        private System.Threading.Tasks.Task _listenerTask;
        private Socket _connectionSocket;
        public Agent(Socket connection)
        {
            _connectionSocket = connection;
            AgentId = _connectionSocket.GetHashCode();
            Tasks = new SortedSet<Task>();
        }
        public int AgentId
        {
            get;
            set;
        }

        public SortedSet<Task> Tasks
        {
            get;
        }

        public void AddTask(Task task)
        {
            Tasks.Add(task);
            _connectionSocket.Send(JsonSerializer.SerializeToUtf8Bytes(task));
            Console.WriteLine("Agent " + AgentId + " added task " + task.Id);
        }

        private void ResultListener()
        {
            byte[] buffer = new byte[_bufferSize];
            int n = _connectionSocket.Receive(buffer);
            
        }
        
        public bool IsAlive()
        {
            return false;
        }

    }
}