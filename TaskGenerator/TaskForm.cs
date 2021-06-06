using System;
using System.Windows.Forms;
using LoadBalancer;

namespace TaskGenerator
{
    public partial class TaskForm : Form
    {
        public Task Task { get; set; }
        public int Count { get; set; }

        public TaskForm()
        {
            InitializeComponent();
        }

        public DialogResult ShowForm(Boolean showCount = false)
        {
            CommandTextBox.Text = "";
            ArgumentsTextBox.Text = "";
            CountLabel.Visible = showCount;
            CountTextBox.Visible = showCount;
            CountTextBox.Text = "0";
            return ShowDialog();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            Task = new Task();
            Task.Command = CommandTextBox.Text;
            Task.Arguments = ArgumentsTextBox.Text;
            Count = Int32.Parse(CountTextBox.Text);
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