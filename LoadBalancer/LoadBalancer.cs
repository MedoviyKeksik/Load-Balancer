using System.Text;
using System.Threading;

namespace LoadBalancer
{
    public class LoadBalancer
    {
        public int Delay { get; set; }
        
        private AgentServer _agentServer;
        private TaskServer _taskServer;
        private System.Threading.Tasks.Task _balanceTask;

        public LoadBalancer()
        {
            Delay = 30;
            _agentServer = new AgentServer();
            _taskServer = new TaskServer();
        }
        private void BalanceLoad()
        {
            int currentId = 0;
            while (true)
            {
                if (_taskServer.Tasks.Count > 0 && _agentServer.Agents.Count > 0)
                {
                    if (currentId < _agentServer.Agents.Count) currentId = 0;
                    _agentServer.Agents[currentId++].AddTask(_taskServer.Tasks.Dequeue(), task => _taskServer.SendResult(task));
                }
                else Thread.Sleep(Delay);
            }
        }

        public void Run()
        {
            _taskServer.Start();
            _agentServer.Start();
            _balanceTask = new System.Threading.Tasks.Task(BalanceLoad);
            _balanceTask.Start();
            _balanceTask.Wait();
        }
    }
}