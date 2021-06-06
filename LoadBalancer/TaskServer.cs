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
        public int Port { get; set; }
        public int MaxConnections { get; set; }
        public int BufferSize { get; set; }

        private System.Threading.Tasks.Task _taskServerTask;
        private CancellationTokenSource _taskListenerTokenSource;
        private CancellationToken _taskListenerToken;

        private Socket _taskListenerSocket;
        public SortedSet<Task> Tasks;
        private Dictionary<Guid, Socket> PendingTasks;
        
        public TaskServer(int port = 8080, int maxConnections = 4)
        {
            Port = port;
            MaxConnections = maxConnections;
            BufferSize = 1024 * 1024;
            _taskListenerTokenSource = new CancellationTokenSource();
            _taskListenerToken = _taskListenerTokenSource.Token;    
            Tasks = new SortedSet<Task>(new TaskComparer());
            PendingTasks = new Dictionary<Guid, Socket>();
        }

        private void TaskListener()
        {
            using (_taskListenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                _taskListenerSocket.Bind(new IPEndPoint(IPAddress.Any, Port));
                _taskListenerSocket.Listen(MaxConnections);
                Console.WriteLine("Server is running on port " + Port);
                while (!_taskListenerToken.IsCancellationRequested)
                {
                    var connectedSocket = _taskListenerSocket.Accept();
                    Console.WriteLine("Accepted connection from " + connectedSocket.RemoteEndPoint);
                    System.Threading.Tasks.Task recieve = new System.Threading.Tasks.Task(TaskReciever, connectedSocket);
                    recieve.Start();
                }
            }
        }
        
        private void TaskReciever(object socket)
        {
            byte[] buffer = new byte[BufferSize];
            try
            {
                while (true)
                {
                    Task recievedTask = TaskSender.RecieveTask((Socket) socket);
                    Console.WriteLine("Recieved task: " + recievedTask.Id);
                    recievedTask.Time = DateTime.Now;
                    PendingTasks.Add(recievedTask.Id, (Socket) socket);
                    lock (Tasks)
                    {
                        Tasks.Add(recievedTask);
                    }
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void SendResult(Task task)
        {
            try
            {
                Socket client = PendingTasks[task.Id];
                PendingTasks.Remove(task.Id);
                TaskSender.SendTask(task, client);
                Console.WriteLine("Send result to " + client.RemoteEndPoint + " of " + task.Id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
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