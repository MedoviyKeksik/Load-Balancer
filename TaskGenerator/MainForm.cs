using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Task = LoadBalancer.Task;

namespace TaskGenerator
{
    public partial class MainForm : Form
    {
        private List<LoadBalancer.Task> _tasks;
        private BindingSource _bindingSource;
        private TaskForm _taskForm;
        private Socket _loadBalancerSocket;
        public MainForm()
        {
            InitializeComponent();
            _taskForm = new TaskForm();
            _tasks = new List<Task>();
            _bindingSource = new BindingSource();
            _bindingSource.DataSource = _tasks; 
            MainDataGrid.DataSource = _bindingSource;
            MainDataGrid.AutoGenerateColumns = true;
            
            // Initialize Socket
            _loadBalancerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _loadBalancerSocket.Connect(IPAddress.Parse("127.0.0.1"), 8080);
        }

        private void AddtaskButton_Click(object sender, EventArgs e)
        {
            if (_taskForm.ShowDialog() == DialogResult.OK)
            {
                _tasks.Add(_taskForm.Task);
                _loadBalancerSocket.Send(JsonSerializer.SerializeToUtf8Bytes(_taskForm.Task));
                _loadBalancerSocket.Shutdown(SocketShutdown.Send);
            }
        }
    }
}