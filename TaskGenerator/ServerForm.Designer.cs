using System.ComponentModel;

namespace TaskGenerator
{
    partial class ServerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ButtonOk = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.IpTextBox = new System.Windows.Forms.TextBox();
            this.PortTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ButtonOk
            // 
            this.ButtonOk.Location = new System.Drawing.Point(12, 62);
            this.ButtonOk.Name = "ButtonOk";
            this.ButtonOk.Size = new System.Drawing.Size(93, 23);
            this.ButtonOk.TabIndex = 5;
            this.ButtonOk.Text = "Ok";
            this.ButtonOk.UseVisualStyleBackColor = true;
            this.ButtonOk.Click += new System.EventHandler(this.ButtonOk_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Location = new System.Drawing.Point(114, 62);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(93, 23);
            this.ButtonCancel.TabIndex = 6;
            this.ButtonCancel.Text = "Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // IpTextBox
            // 
            this.IpTextBox.Location = new System.Drawing.Point(12, 27);
            this.IpTextBox.Name = "IpTextBox";
            this.IpTextBox.Size = new System.Drawing.Size(113, 20);
            this.IpTextBox.TabIndex = 0;
            // 
            // PortTextBox
            // 
            this.PortTextBox.Location = new System.Drawing.Point(141, 27);
            this.PortTextBox.Name = "PortTextBox";
            this.PortTextBox.Size = new System.Drawing.Size(66, 20);
            this.PortTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(128, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = ":";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ip address:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(141, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Port:";
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(219, 98);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonOk);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PortTextBox);
            this.Controls.Add(this.IpTextBox);
            this.Name = "ServerForm";
            this.Text = "ServerForm";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox IpTextBox;
        private System.Windows.Forms.TextBox PortTextBox;

        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Button ButtonOk;

        #endregion
    }
}