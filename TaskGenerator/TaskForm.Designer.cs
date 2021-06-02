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
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.LabelTaskName = new System.Windows.Forms.Label();
            this.OkButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(12, 33);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(214, 20);
            this.NameTextBox.TabIndex = 0;
            // 
            // LabelTaskName
            // 
            this.LabelTaskName.Location = new System.Drawing.Point(12, 9);
            this.LabelTaskName.Name = "LabelTaskName";
            this.LabelTaskName.Size = new System.Drawing.Size(100, 21);
            this.LabelTaskName.TabIndex = 1;
            this.LabelTaskName.Text = "Name";
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
            // TaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(245, 368);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.LabelTaskName);
            this.Controls.Add(this.NameTextBox);
            this.Name = "TaskForm";
            this.Text = "TaskForm";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private new System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Label LabelTaskName;
        private System.Windows.Forms.Button OkButton;

        private System.Windows.Forms.TextBox NameTextBox;

        #endregion
    }
}