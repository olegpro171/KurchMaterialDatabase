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
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { connectionMenuItem });
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
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip.Location = new Point(0, 428);
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
            // createButton
            // 
            createButton.Location = new Point(12, 60);
            createButton.Name = "createButton";
            createButton.Size = new Size(75, 23);
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
            dataGridView.Location = new Point(93, 60);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            dataGridView.RowTemplate.Height = 25;
            dataGridView.Size = new Size(681, 285);
            dataGridView.TabIndex = 4;
            dataGridView.CellContentClick += dataGridView_CellContentClick;
            // 
            // nameSearchTextBox
            // 
            nameSearchTextBox.Location = new Point(192, 31);
            nameSearchTextBox.Name = "nameSearchTextBox";
            nameSearchTextBox.Size = new Size(582, 23);
            nameSearchTextBox.TabIndex = 5;
            nameSearchTextBox.TextChanged += nameSearchTextBox_TextChanged;
            // 
            // nameSearchLabel
            // 
            nameSearchLabel.AutoSize = true;
            nameSearchLabel.Location = new Point(93, 34);
            nameSearchLabel.Name = "nameSearchLabel";
            nameSearchLabel.Size = new Size(93, 15);
            nameSearchLabel.TabIndex = 6;
            nameSearchLabel.Text = "Имя материала";
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(786, 450);
            Controls.Add(nameSearchLabel);
            Controls.Add(nameSearchTextBox);
            Controls.Add(dataGridView);
            Controls.Add(createButton);
            Controls.Add(statusStrip);
            Controls.Add(menuStrip1);
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