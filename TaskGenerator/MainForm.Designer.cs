namespace TaskGenerator
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.AddtaskButton = new System.Windows.Forms.Button();
            this.CanceltaskButton = new System.Windows.Forms.Button();
            this.MainDataGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize) (this.MainDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // AddtaskButton
            // 
            this.AddtaskButton.Location = new System.Drawing.Point(629, 12);
            this.AddtaskButton.Name = "AddtaskButton";
            this.AddtaskButton.Size = new System.Drawing.Size(159, 35);
            this.AddtaskButton.TabIndex = 1;
            this.AddtaskButton.Text = "Add task";
            this.AddtaskButton.UseVisualStyleBackColor = true;
            this.AddtaskButton.Click += new System.EventHandler(this.AddtaskButton_Click);
            // 
            // CanceltaskButton
            // 
            this.CanceltaskButton.Location = new System.Drawing.Point(629, 53);
            this.CanceltaskButton.Name = "CanceltaskButton";
            this.CanceltaskButton.Size = new System.Drawing.Size(159, 35);
            this.CanceltaskButton.TabIndex = 2;
            this.CanceltaskButton.Text = "Cancel";
            this.CanceltaskButton.UseVisualStyleBackColor = true;
            // 
            // MainDataGrid
            // 
            this.MainDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MainDataGrid.Location = new System.Drawing.Point(12, 12);
            this.MainDataGrid.Name = "MainDataGrid";
            this.MainDataGrid.Size = new System.Drawing.Size(611, 426);
            this.MainDataGrid.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MainDataGrid);
            this.Controls.Add(this.CanceltaskButton);
            this.Controls.Add(this.AddtaskButton);
            this.Name = "MainForm";
            this.Text = "TaskGenerator";
            ((System.ComponentModel.ISupportInitialize) (this.MainDataGrid)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView MainDataGrid;


        private System.Windows.Forms.Button AddtaskButton;
        private System.Windows.Forms.Button CanceltaskButton;

        #endregion
    }
}