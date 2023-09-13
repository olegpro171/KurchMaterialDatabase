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
            statusStrip = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            createButton = new Button();
            dataGridView = new DataGridView();
            nameSearchTextBox = new TextBox();
            nameSearchLabel = new Label();
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
            menuStrip1.Items.AddRange(new ToolStripItem[] { connectionMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 3, 0, 3);
            menuStrip1.Size = new Size(898, 30);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // connectionMenuItem
            // 
            connectionMenuItem.DropDownItems.AddRange(new ToolStripItem[] { connectionDataMenuItem });
            connectionMenuItem.Name = "connectionMenuItem";
            connectionMenuItem.Size = new Size(109, 24);
            connectionMenuItem.Text = "Соединение";
            // 
            // connectionDataMenuItem
            // 
            connectionDataMenuItem.Name = "connectionDataMenuItem";
            connectionDataMenuItem.Size = new Size(235, 26);
            connectionDataMenuItem.Text = "Данные соединения";
            connectionDataMenuItem.Click += connectionDataMenuItem_Click;
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new Size(20, 20);
            statusStrip.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip.Location = new Point(0, 485);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new Padding(1, 0, 16, 0);
            statusStrip.Size = new Size(898, 26);
            statusStrip.TabIndex = 2;
            statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(151, 20);
            toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // createButton
            // 
            createButton.Location = new Point(14, 80);
            createButton.Margin = new Padding(3, 4, 3, 4);
            createButton.Name = "createButton";
            createButton.Size = new Size(86, 31);
            createButton.TabIndex = 3;
            createButton.Text = "Создать";
            createButton.UseVisualStyleBackColor = true;
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(106, 80);
            dataGridView.Margin = new Padding(3, 4, 3, 4);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            dataGridView.RowTemplate.Height = 25;
            dataGridView.Size = new Size(778, 380);
            dataGridView.TabIndex = 4;
            dataGridView.CellContentClick += dataGridView_CellContentClick;
            // 
            // nameSearchTextBox
            // 
            nameSearchTextBox.Location = new Point(242, 41);
            nameSearchTextBox.Margin = new Padding(3, 4, 3, 4);
            nameSearchTextBox.Name = "nameSearchTextBox";
            nameSearchTextBox.Size = new Size(642, 27);
            nameSearchTextBox.TabIndex = 5;
            nameSearchTextBox.TextChanged += nameSearchTextBox_TextChanged;
            // 
            // nameSearchLabel
            // 
            nameSearchLabel.AutoSize = true;
            nameSearchLabel.Location = new Point(106, 45);
            nameSearchLabel.Name = "nameSearchLabel";
            nameSearchLabel.Size = new Size(118, 20);
            nameSearchLabel.TabIndex = 6;
            nameSearchLabel.Text = "Имя материала";
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(898, 511);
            Controls.Add(nameSearchLabel);
            Controls.Add(nameSearchTextBox);
            Controls.Add(dataGridView);
            Controls.Add(createButton);
            Controls.Add(statusStrip);
            Controls.Add(menuStrip1);
            Margin = new Padding(3, 4, 3, 4);
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
        private Button createButton;
        private DataGridView dataGridView;
        private TextBox nameSearchTextBox;
        private Label nameSearchLabel;
    }
}