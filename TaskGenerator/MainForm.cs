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
using LoadBalancer;
using Task = LoadBalancer.Task;

namespace TaskGenerator
{
    public partial class MainForm : Form
    {

        private List<LoadBalancer.Task> _tasks;
        private TaskForm _taskForm;
        private ServerForm _serverForm;
        
        private Socket _serverSocket;

        private System.Threading.Tasks.Task _resultsListener;

        private const string HeaderText = "TaskGenerator"; 
        public MainForm()
        {
            InitializeComponent();
            _taskForm = new TaskForm();
            _tasks = new List<Task>();
            _serverForm = new ServerForm();
            
            SetupDataGridView();

            Text = HeaderText + " - [Disconnected]";
        }

        private void SetupDataGridView()
        {
            MainDataGrid.ColumnCount = 3;
            MainDataGrid.Columns[0].Name = "Name";
            MainDataGrid.Columns[1].Name = "Status";
            MainDataGrid.Columns[2].Name = "Result";
        }

        private void AppendTask(Task task)
        {
            String[] row =
            {
                task.Command + " " + task.Arguments,
                "Pending",
                "Null"
            };
            int ind = MainDataGrid.Rows.Add(row);
            MainDataGrid.Rows[ind].Tag = task;
        }

        private void UpdateTask(Task task)
        {
            for (int i = 0; i < MainDataGrid.Rows.Count; i++)
            {
                Task now = (MainDataGrid.Rows[i].Tag as Task);
                if (now != null && task.Id.Equals(now.Id))
                {
                    MainDataGrid.Rows[i].Cells[1].Value = "Completed";
                    MainDataGrid.Rows[i].Cells[2].Value = task.Result;
                    MainDataGrid.Rows[i].Tag = task;
                }
            }
        }
        private void AddtaskButton_Click(object sender, EventArgs e)
        {
            if (_serverSocket == null)
            {
                MessageBox.Show("First connect to the server", "Caution");
            } else if (_taskForm.ShowForm() == DialogResult.OK)
            {
                _tasks.Add(_taskForm.Task);
                AppendTask(_taskForm.Task);
                TaskSender.SendTask(_taskForm.Task, _serverSocket);
            }
        }

        private void GetResults()
        {
            byte[] buffer = new byte[1024 * 1024];
            try
            {
                while (_serverSocket.Connected)
                {
                    Task recievedTask = TaskSender.RecieveTask(_serverSocket);
                    UpdateTask(recievedTask);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error!");
                Text = HeaderText + " - [Disconnected]";
            }
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_serverForm.ShowForm() == DialogResult.OK)
            {
                try
                {
                    _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    _serverSocket.Connect(_serverForm.ServerEndPoint);
                    Text = HeaderText + " - [" + _serverForm.ServerEndPoint + "]";
                    _resultsListener = new System.Threading.Tasks.Task(GetResults);
                    _resultsListener.Start();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "Error!");
                }
            }
        }

        private void StressTestButton_Click(object sender, EventArgs e)
        {
            if (_serverSocket == null)
            {
                MessageBox.Show("First connect to the server", "Caution");
            } else if (_taskForm.ShowForm(true) == DialogResult.OK)
            {
                for (int i = 0; i < _taskForm.Count; i++)
                {
                    Task tmp = new Task();
                    tmp.Command = _taskForm.Task.Command;
                    tmp.Arguments = _taskForm.Task.Arguments;
                    _tasks.Add(tmp);
                    AppendTask(tmp);
                    TaskSender.SendTask(tmp, _serverSocket);
                }
            }
        }
    }
}