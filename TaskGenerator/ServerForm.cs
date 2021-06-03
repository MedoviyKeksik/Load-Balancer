using System;
using System.Net;
using System.Windows.Forms;

namespace TaskGenerator
{
    public partial class ServerForm : Form
    {
        public IPEndPoint ServerEndPoint { get; set; }
        
        public ServerForm()
        {
            InitializeComponent();
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            ServerEndPoint = new IPEndPoint(IPAddress.Parse(IpTextBox.Text), Int32.Parse(PortTextBox.Text));
            DialogResult = DialogResult.OK;
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}