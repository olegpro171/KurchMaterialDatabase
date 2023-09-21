namespace WinFormsApp
{
    partial class IsotopeDisplayForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IsotopeDisplayForm));
            idLabel = new Label();
            nameLabel = new Label();
            idTextBox = new TextBox();
            nameTextBox = new TextBox();
            closeButton = new Button();
            saveButton = new Button();
            deleteButton = new Button();
            statusStrip = new StatusStrip();
            statusLabel = new ToolStripStatusLabel();
            cascadeLabel = new Label();
            cascadeGridView = new DataGridView();
            emptyCascadeLabel = new Label();
            statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cascadeGridView).BeginInit();
            SuspendLayout();
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new Point(114, 16);
            idLabel.Name = "idLabel";
            idLabel.Size = new Size(24, 20);
            idLabel.TabIndex = 0;
            idLabel.Text = "ID";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(14, 71);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(138, 20);
            nameLabel.TabIndex = 1;
            nameLabel.Text = "Название изотопа";
            // 
            // idTextBox
            // 
            idTextBox.Location = new Point(170, 12);
            idTextBox.Margin = new Padding(3, 4, 3, 4);
            idTextBox.Name = "idTextBox";
            idTextBox.ReadOnly = true;
            idTextBox.Size = new Size(226, 27);
            idTextBox.TabIndex = 2;
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(170, 67);
            nameTextBox.Margin = new Padding(3, 4, 3, 4);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(226, 27);
            nameTextBox.TabIndex = 3;
            nameTextBox.TextChanged += nameTextBox_TextChanged;
            // 
            // closeButton
            // 
            closeButton.Location = new Point(14, 465);
            closeButton.Margin = new Padding(3, 4, 3, 4);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(131, 31);
            closeButton.TabIndex = 4;
            closeButton.Text = "Закрыть";
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += closeButton_Click;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(265, 465);
            saveButton.Margin = new Padding(3, 4, 3, 4);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(131, 31);
            saveButton.TabIndex = 5;
            saveButton.Text = "Сохранить";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // deleteButton
            // 
            deleteButton.ForeColor = Color.IndianRed;
            deleteButton.Location = new Point(265, 427);
            deleteButton.Margin = new Padding(3, 4, 3, 4);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(131, 31);
            deleteButton.TabIndex = 6;
            deleteButton.Text = "Удалить изотоп";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click;
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new Size(20, 20);
            statusStrip.Items.AddRange(new ToolStripItem[] { statusLabel });
            statusStrip.Location = new Point(0, 503);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new Padding(1, 0, 16, 0);
            statusStrip.Size = new Size(410, 26);
            statusStrip.SizingGrip = false;
            statusStrip.TabIndex = 7;
            statusStrip.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            statusLabel.ForeColor = Color.IndianRed;
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(83, 20);
            statusLabel.Text = "statusLabel";
            // 
            // cascadeLabel
            // 
            cascadeLabel.AutoSize = true;
            cascadeLabel.Location = new Point(14, 119);
            cascadeLabel.Name = "cascadeLabel";
            cascadeLabel.Size = new Size(139, 20);
            cascadeLabel.TabIndex = 8;
            cascadeLabel.Text = "Каскад изменений";
            // 
            // cascadeGridView
            // 
            cascadeGridView.AllowUserToAddRows = false;
            cascadeGridView.AllowUserToDeleteRows = false;
            cascadeGridView.AllowUserToResizeRows = false;
            cascadeGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            cascadeGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            cascadeGridView.Location = new Point(14, 143);
            cascadeGridView.Margin = new Padding(3, 4, 3, 4);
            cascadeGridView.Name = "cascadeGridView";
            cascadeGridView.ReadOnly = true;
            cascadeGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            cascadeGridView.RowTemplate.Height = 25;
            cascadeGridView.Size = new Size(383, 276);
            cascadeGridView.TabIndex = 9;
            // 
            // emptyCascadeLabel
            // 
            emptyCascadeLabel.Dock = DockStyle.Fill;
            emptyCascadeLabel.Location = new Point(0, 0);
            emptyCascadeLabel.Name = "emptyCascadeLabel";
            emptyCascadeLabel.Size = new Size(410, 529);
            emptyCascadeLabel.TabIndex = 10;
            emptyCascadeLabel.Text = "Отсутсвтуют материалы, связанные с этим изотопом";
            emptyCascadeLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // IsotopeDisplayForm
            // 
            AcceptButton = saveButton;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = closeButton;
            ClientSize = new Size(410, 529);
            Controls.Add(cascadeLabel);
            Controls.Add(statusStrip);
            Controls.Add(deleteButton);
            Controls.Add(saveButton);
            Controls.Add(closeButton);
            Controls.Add(nameTextBox);
            Controls.Add(idTextBox);
            Controls.Add(nameLabel);
            Controls.Add(idLabel);
            Controls.Add(cascadeGridView);
            Controls.Add(emptyCascadeLabel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "IsotopeDisplayForm";
            Text = "Изотоп";
            Load += IsotopeDisplayForm_Load;
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)cascadeGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label idLabel;
        private Label nameLabel;
        private TextBox idTextBox;
        private TextBox nameTextBox;
        private Button closeButton;
        private Button saveButton;
        private Button deleteButton;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel statusLabel;
        private Label cascadeLabel;
        private DataGridView cascadeGridView;
        private Label emptyCascadeLabel;
    }
}