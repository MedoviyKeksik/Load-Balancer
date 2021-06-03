using System;
using System.Windows.Forms;
using LoadBalancer;

namespace TaskGenerator
{
    public partial class TaskForm : Form
    {
        public Task Task { get; set; }

        public TaskForm()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            Task = new Task();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}