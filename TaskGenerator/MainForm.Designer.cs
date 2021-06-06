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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.AddtaskButton = new System.Windows.Forms.Button();
            this.MainDataGrid = new System.Windows.Forms.DataGridView();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.serverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.StressTestButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize) (this.MainDataGrid)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddtaskButton
            // 
            this.AddtaskButton.Location = new System.Drawing.Point(6, 3);
            this.AddtaskButton.Name = "AddtaskButton";
            this.AddtaskButton.Size = new System.Drawing.Size(159, 35);
            this.AddtaskButton.TabIndex = 1;
            this.AddtaskButton.Text = "Add task";
            this.AddtaskButton.UseVisualStyleBackColor = true;
            this.AddtaskButton.Click += new System.EventHandler(this.AddtaskButton_Click);
            // 
            // MainDataGrid
            // 
            this.MainDataGrid.AllowUserToAddRows = false;
            this.MainDataGrid.AllowUserToDeleteRows = false;
            this.MainDataGrid.AllowUserToResizeRows = false;
            this.MainDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.MainDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MainDataGrid.Dock = System.Windows.Forms.DockStyle.Left;
            this.MainDataGrid.Location = new System.Drawing.Point(0, 24);
            this.MainDataGrid.Name = "MainDataGrid";
            this.MainDataGrid.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.MainDataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.MainDataGrid.RowTemplate.ReadOnly = true;
            this.MainDataGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.MainDataGrid.Size = new System.Drawing.Size(629, 426);
            this.MainDataGrid.TabIndex = 4;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.serverToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(800, 24);
            this.menuStrip.TabIndex = 5;
            this.menuStrip.Text = "menuStrip1";
            // 
            // serverToolStripMenuItem
            // 
            this.serverToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.connectToolStripMenuItem});
            this.serverToolStripMenuItem.Name = "serverToolStripMenuItem";
            this.serverToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.serverToolStripMenuItem.Text = "Server";
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.connectToolStripMenuItem.Text = "Connect";
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.StressTestButton);
            this.panel1.Controls.Add(this.AddtaskButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(629, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(171, 426);
            this.panel1.TabIndex = 6;
            // 
            // StressTestButton
            // 
            this.StressTestButton.Location = new System.Drawing.Point(6, 44);
            this.StressTestButton.Name = "StressTestButton";
            this.StressTestButton.Size = new System.Drawing.Size(159, 35);
            this.StressTestButton.TabIndex = 1;
            this.StressTestButton.Text = "Stress test";
            this.StressTestButton.UseVisualStyleBackColor = true;
            this.StressTestButton.Click += new System.EventHandler(this.StressTestButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.MainDataGrid);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            ((System.ComponentModel.ISupportInitialize) (this.MainDataGrid)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button StressTestButton;

        private System.Windows.Forms.Panel panel1;

        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serverToolStripMenuItem;

        private System.Windows.Forms.DataGridView MainDataGrid;
        private System.Windows.Forms.MenuStrip menuStrip;

        private System.Windows.Forms.Button AddtaskButton;

        #endregion
    }
}