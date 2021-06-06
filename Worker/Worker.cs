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
        public delegate void TaskHandler(ref LoadBalancer.Task task);
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
            while (!_taskProcessingToken.IsCancellationRequested)
            {
                if (queue.Count == 0) Thread.Sleep(_delay);
                else
                {
                    LoadBalancer.Task currentTask = queue.Min;
                    queue.Remove(currentTask);
                    ((TaskHandler) callback)(ref currentTask);
                    Console.WriteLine("Send result: " + currentTask.Id);
                    lock (_connectionSocket)
                    {
                        LoadBalancer.TaskSender.SendTask(currentTask, _connectionSocket);
                    }
                }
            }
        }

        public void Run(TaskHandler callback)
        {
            System.Threading.Tasks.Task processingTask = new System.Threading.Tasks.Task(TaskProcessing, callback);
            processingTask.Start();
            while (!_taskProcessingToken.IsCancellationRequested)
            {
                LoadBalancer.Task recievedTask = LoadBalancer.TaskSender.RecieveTask(_connectionSocket);
                Console.WriteLine("Recieved task: " + recievedTask.Id);
                lock (queue)
                {
                    queue.Add(recievedTask);
                }
            }

        }
    }
}