namespace WinFormsApp
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            contextMenuStrip1 = new ContextMenuStrip(components);
            menuStrip1 = new MenuStrip();
            connectionMenuItem = new ToolStripMenuItem();
            connectionDataMenuItem = new ToolStripMenuItem();
            materialsToolStripMenuItem = new ToolStripMenuItem();
            createToolStripMenuItem = new ToolStripMenuItem();
            statusStrip = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            dataGridView = new DataGridView();
            nameSearchTextBox = new TextBox();
            nameSearchLabel = new Label();
            tableSelectBox = new ComboBox();
            tableSelectLabel = new Label();
            menuStrip1.SuspendLayout();
            statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { connectionMenuItem, materialsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(786, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // connectionMenuItem
            // 
            connectionMenuItem.DropDownItems.AddRange(new ToolStripItem[] { connectionDataMenuItem });
            connectionMenuItem.Name = "connectionMenuItem";
            connectionMenuItem.Size = new Size(86, 20);
            connectionMenuItem.Text = "Соединение";
            // 
            // connectionDataMenuItem
            // 
            connectionDataMenuItem.Name = "connectionDataMenuItem";
            connectionDataMenuItem.Size = new Size(185, 22);
            connectionDataMenuItem.Text = "Данные соединения";
            connectionDataMenuItem.Click += connectionDataMenuItem_Click;
            // 
            // materialsToolStripMenuItem
            // 
            materialsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { createToolStripMenuItem });
            materialsToolStripMenuItem.Name = "materialsToolStripMenuItem";
            materialsToolStripMenuItem.Size = new Size(83, 20);
            materialsToolStripMenuItem.Text = "Материалы";
            // 
            // createToolStripMenuItem
            // 
            createToolStripMenuItem.Name = "createToolStripMenuItem";
            createToolStripMenuItem.Size = new Size(117, 22);
            createToolStripMenuItem.Text = "Создать";
            createToolStripMenuItem.Click += createToolStripMenuItem_Click;
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new Size(20, 20);
            statusStrip.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip.Location = new Point(0, 432);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(786, 22);
            statusStrip.TabIndex = 2;
            statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(118, 17);
            toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(12, 60);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            dataGridView.RowTemplate.Height = 25;
            dataGridView.Size = new Size(762, 369);
            dataGridView.TabIndex = 4;
            dataGridView.CellClick += dataGridView_CellContentClick;
            // 
            // nameSearchTextBox
            // 
            nameSearchTextBox.Location = new Point(116, 31);
            nameSearchTextBox.Name = "nameSearchTextBox";
            nameSearchTextBox.Size = new Size(271, 23);
            nameSearchTextBox.TabIndex = 5;
            nameSearchTextBox.TextChanged += nameSearchTextBox_TextChanged;
            // 
            // nameSearchLabel
            // 
            nameSearchLabel.AutoSize = true;
            nameSearchLabel.Location = new Point(12, 34);
            nameSearchLabel.Name = "nameSearchLabel";
            nameSearchLabel.Size = new Size(98, 15);
            nameSearchLabel.TabIndex = 6;
            nameSearchLabel.Text = "Поиск по имени";
            // 
            // tableSelectBox
            // 
            tableSelectBox.DropDownStyle = ComboBoxStyle.DropDownList;
            tableSelectBox.Enabled = false;
            tableSelectBox.FormattingEnabled = true;
            tableSelectBox.Items.AddRange(new object[] { "Материалы", "Изотопы" });
            tableSelectBox.Location = new Point(594, 31);
            tableSelectBox.Name = "tableSelectBox";
            tableSelectBox.Size = new Size(180, 23);
            tableSelectBox.TabIndex = 7;
            tableSelectBox.SelectedIndexChanged += tableSelectBox_SelectedIndexChanged;
            // 
            // tableSelectLabel
            // 
            tableSelectLabel.AutoSize = true;
            tableSelectLabel.Location = new Point(535, 34);
            tableSelectLabel.Name = "tableSelectLabel";
            tableSelectLabel.Size = new Size(53, 15);
            tableSelectLabel.TabIndex = 8;
            tableSelectLabel.Text = "Таблица";
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(786, 454);
            Controls.Add(tableSelectLabel);
            Controls.Add(tableSelectBox);
            Controls.Add(nameSearchLabel);
            Controls.Add(nameSearchTextBox);
            Controls.Add(dataGridView);
            Controls.Add(statusStrip);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FormMain";
            Text = "MD2";
            Load += FormMain_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ContextMenuStrip contextMenuStrip1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem connectionMenuItem;
        private ToolStripMenuItem connectionDataMenuItem;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private DataGridView dataGridView;
        private TextBox nameSearchTextBox;
        private Label nameSearchLabel;
        private ToolStripMenuItem materialsToolStripMenuItem;
        private ToolStripMenuItem createToolStripMenuItem;
        private ComboBox tableSelectBox;
        private Label tableSelectLabel;
    }
}