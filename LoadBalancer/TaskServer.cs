using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;

namespace LoadBalancer
{
    public class TaskServer
    {
        private int _port = 8080;
        private int _maxConnections = 4;
        private int _maxAgents = 4;
        private int _agentsPort = 7070;
        private int _bufferSize = 1024 * 1024;

        private System.Threading.Tasks.Task _taskServerTask;
        private CancellationTokenSource _taskListenerTokenSource;
        private CancellationToken _taskListenerToken;

        
        private Socket _taskListenerSocket;
        public Queue<Task> Tasks;
        
        public TaskServer()
        {
            _taskListenerTokenSource = new CancellationTokenSource();
            _taskListenerToken = _taskListenerTokenSource.Token;    
            Tasks = new Queue<Task>();
        }

        private void TaskListener()
        {
            using (_taskListenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                _taskListenerSocket.Bind(new IPEndPoint(IPAddress.Any, _port));
                _taskListenerSocket.Listen(_maxConnections);
                Console.WriteLine("Server is running on port " + _port);
                while (!_taskListenerToken.IsCancellationRequested)
                {
                    var connectedSocket = _taskListenerSocket.Accept();
                    Console.WriteLine("Accepted connection from " + connectedSocket.RemoteEndPoint);
                    System.Threading.Tasks.Task recieve = new System.Threading.Tasks.Task(TaskReciever, connectedSocket);
                    recieve.Start();
                }
            }
        }
        
        private byte[] GetPrefix(byte[] buffer, int count)
        {
            byte[] result = new byte[count];
            Array.Copy(buffer, result, count);
            return result;
        }

        private void TaskReciever(object socket)
        {
            byte[] buffer = new byte[_bufferSize];
            int recieved = ((Socket) socket).Receive(buffer);
            Console.WriteLine("Recieved: " + recieved + " bytes");
            lock (Tasks)
            {
                Tasks.Enqueue(JsonSerializer.Deserialize<Task>(Encoding.UTF8.GetString(GetPrefix(buffer, recieved))));
            }
        }
        public void Start()
        {
            _taskServerTask = new System.Threading.Tasks.Task(TaskListener);
            _taskServerTask.Start();
        }

        public void Wait()
        {
            _taskServerTask.Wait();
        }

        public void Stop()
        {
            _taskListenerTokenSource.Cancel();
        }
     }
}