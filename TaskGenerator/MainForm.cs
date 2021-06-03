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
        private Socket _ServerSocket;

        private System.Threading.Tasks.Task _resultsListener;
        public MainForm()
        {
            InitializeComponent();
            _taskForm = new TaskForm();
            _tasks = new List<Task>();
            _serverForm = new ServerForm();
            _ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            SetupDataGridView();
        }

        private void SetupDataGridView()
        {
            MainDataGrid.ColumnCount = 3;
            MainDataGrid.Columns[0].Name = "Id";
            MainDataGrid.Columns[1].Name = "Status";
            MainDataGrid.Columns[2].Name = "Result";
        }

        private void AppendTask(Task task)
        {
            String[] row =
            {
                task.Command + task.Arguments,
                "Pending",
                "Null"
            };
            int ind = MainDataGrid.Rows.Add(row);
            MainDataGrid.Rows[ind].Tag = task;
        }

        private void UpdateTask(Task task)
        {
            MessageBox.Show("Result recieved: " + task.Id);
            for (int i = 0; i < MainDataGrid.Rows.Count; i++)
            {
                Task now = (MainDataGrid.Rows[i].Tag as Task);
                if (now != null && task.Id.Equals(now.Id))
                {
                    MainDataGrid.Rows[i].Cells[1].Value = "Completed";
                    MainDataGrid.Rows[i].Cells[2].Value = task.Result.ToString();
                    MainDataGrid.Rows[i].Tag = task;
                }
            }
        }
        private void AddtaskButton_Click(object sender, EventArgs e)
        {
            if (_taskForm.ShowDialog() == DialogResult.OK)
            {
                _tasks.Add(_taskForm.Task);
                AppendTask(_taskForm.Task);
                _ServerSocket.Send(JsonSerializer.SerializeToUtf8Bytes(_taskForm.Task));
            }
        }

        private void GetResults()
        {
            byte[] buffer = new byte[1024 * 1024];
            while (true)
            {
                // _ServerSocket.Receive(buffer, 4, SocketFlags.None);
                // int size = BitConverter.ToInt32(buffer, 0);
                int size = _ServerSocket.Receive(buffer, SocketFlags.None);
                MessageBox.Show(size.ToString());
                Task recievedTask = JsonSerializer.Deserialize<Task>(ArrayProcessing.GetPrefix(buffer, size));
                UpdateTask(recievedTask);
            }
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_serverForm.ShowDialog() == DialogResult.OK)
            {
                _ServerSocket.Connect(_serverForm.ServerEndPoint);
                _resultsListener = new System.Threading.Tasks.Task(GetResults);
                _resultsListener.Start();
            }
        }
    }
}