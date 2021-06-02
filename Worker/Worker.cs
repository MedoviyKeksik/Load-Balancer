using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;

namespace Worker
{ 
    public class Worker
    {
        protected SortedSet<LoadBalancer.Task> queue;
        public delegate object TaskHandler(LoadBalancer.Task task);
        private Socket _connectionSocket;
        private CancellationTokenSource _taskProcessingTokenSource;
        private CancellationToken _taskProcessingToken;
        private const int _delay = 100;
        private const int _bufferSize = 1024 * 1024;
        private byte[] _buffer;

        public Worker()
        {
            _connectionSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            queue = new SortedSet<LoadBalancer.Task>(new LoadBalancer.TaskComparer());
            _buffer = new byte[_bufferSize];
            _taskProcessingTokenSource = new CancellationTokenSource();
            _taskProcessingToken = _taskProcessingTokenSource.Token;
        }

        public Worker(IPEndPoint endPoint) : this()
        {
            Connect(endPoint);
        }
        public void Connect(IPEndPoint endPoint)
        {
            _connectionSocket.Connect(endPoint);
        }

        private void TaskProcessing(object callback)
        {
            TaskHandler callbackFunction = callback as TaskHandler;
            while (!_taskProcessingToken.IsCancellationRequested)
            {
                if (queue.Count == 0) Thread.Sleep(_delay);
                else
                {
                    LoadBalancer.Task currentTask = queue.Min;
                    queue.Remove(currentTask);
                    currentTask.Result = callbackFunction(currentTask);
                    Console.WriteLine("Send result: " + currentTask.Id);
                    lock (_connectionSocket)
                    {
                        _connectionSocket.Send(JsonSerializer.SerializeToUtf8Bytes(currentTask));
                    }
                }
            }
        }

        private byte[] GetPrefix(byte[] buffer, int count)
        {
            byte[] result = new byte[count];
            Array.Copy(buffer, result, count);
            return result;
        }
        public void Run(TaskHandler callback)
        {
            System.Threading.Tasks.Task processingTask = new System.Threading.Tasks.Task(TaskProcessing, callback);
            processingTask.Start();
            while (!_taskProcessingToken.IsCancellationRequested)
            {
                int n = _connectionSocket.Receive(_buffer);
                LoadBalancer.Task recievedTask = JsonSerializer.Deserialize<LoadBalancer.Task>(Encoding.UTF8.GetString(GetPrefix(_buffer, n)));
                Console.WriteLine("Recieved task: " + recievedTask.Id);
                lock (queue)
                {
                    queue.Add(recievedTask);
                }
            }

        }
    }
}