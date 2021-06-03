using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace LoadBalancer
{
    public class AgentShutdownException : Exception
    {
        public Agent DeadAgent
        {
            get;
            set;
        }

        AgentShutdownException(string msg, Agent agent) : base(msg)
        {
            DeadAgent = agent;
        }
    }
    public class AgentServer
    {
        public int Port { get; set; }
        public int MaxAgents { get; set; }
        public static int BufferSize = 1024 * 1024;

        private System.Threading.Tasks.Task _agentServerTask;
        private CancellationTokenSource _agentListenerTokenSource;
        private CancellationToken _agentListenerToken;
        
        
        private Socket _agentsSocket;
        public List<Agent> Agents;

        public AgentServer(int port = 7070, int maxAgents = 4)
        {
            Port = port;
            MaxAgents = maxAgents;
            _agentListenerTokenSource = new CancellationTokenSource();
            _agentListenerToken = _agentListenerTokenSource.Token;
            Agents = new List<Agent>();
        }
        
        private void AgentsListener()
        {
            using (_agentsSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                _agentsSocket.Bind(new IPEndPoint(IPAddress.Any, Port));
                _agentsSocket.Listen(MaxAgents);
                Console.WriteLine("Server is listening for agents...");
                while (!_agentListenerToken.IsCancellationRequested)
                {
                    var connection = _agentsSocket.Accept();
                    Agent currentAgent = new Agent(connection);
                    Console.WriteLine("Agent " + currentAgent.AgentId + " connected");
                    Agents.Add(currentAgent);
                }
            }
        }

        private void AgentsChecker()
        {
            
        }

        public void Start()
        {
            _agentServerTask = new System.Threading.Tasks.Task(AgentsListener);
            _agentServerTask.Start();
        }

        public void Wait()
        {
            _agentServerTask.Wait();
        }

        public void Stop()
        {
            _agentListenerTokenSource.Cancel();
        }
    }
}