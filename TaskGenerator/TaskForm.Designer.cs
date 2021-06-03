using System.ComponentModel;

namespace TaskGenerator
{
    partial class TaskForm
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
            this.CommandTextBox = new System.Windows.Forms.TextBox();
            this.LabelCommand = new System.Windows.Forms.Label();
            this.OkButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.LabelArguments = new System.Windows.Forms.Label();
            this.ArgumentsTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // CommandTextBox
            // 
            this.CommandTextBox.Location = new System.Drawing.Point(12, 33);
            this.CommandTextBox.Name = "CommandTextBox";
            this.CommandTextBox.Size = new System.Drawing.Size(209, 20);
            this.CommandTextBox.TabIndex = 0;
            // 
            // LabelCommand
            // 
            this.LabelCommand.Location = new System.Drawing.Point(12, 9);
            this.LabelCommand.Name = "LabelCommand";
            this.LabelCommand.Size = new System.Drawing.Size(100, 21);
            this.LabelCommand.TabIndex = 1;
            this.LabelCommand.Text = "Command:";
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(21, 339);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 2;
            this.OkButton.Text = "Ok";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(139, 339);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 3;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // LabelArguments
            // 
            this.LabelArguments.Location = new System.Drawing.Point(15, 71);
            this.LabelArguments.Name = "LabelArguments";
            this.LabelArguments.Size = new System.Drawing.Size(100, 23);
            this.LabelArguments.TabIndex = 4;
            this.LabelArguments.Text = "Arguments:";
            // 
            // ArgumentsTextBox
            // 
            this.ArgumentsTextBox.Location = new System.Drawing.Point(12, 97);
            this.ArgumentsTextBox.Name = "ArgumentsTextBox";
            this.ArgumentsTextBox.Size = new System.Drawing.Size(209, 20);
            this.ArgumentsTextBox.TabIndex = 5;
            // 
            // TaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(233, 370);
            this.Controls.Add(this.ArgumentsTextBox);
            this.Controls.Add(this.LabelArguments);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.LabelCommand);
            this.Controls.Add(this.CommandTextBox);
            this.Name = "TaskForm";
            this.Text = "TaskForm";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox ArgumentsTextBox;

        private System.Windows.Forms.Label LabelArguments;

        private new System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Label LabelCommand;
        private System.Windows.Forms.Button OkButton;

        private System.Windows.Forms.TextBox CommandTextBox;

        #endregion
    }
}