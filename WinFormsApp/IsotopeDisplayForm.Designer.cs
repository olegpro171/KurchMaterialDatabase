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
            idLabel.Location = new Point(100, 12);
            idLabel.Name = "idLabel";
            idLabel.Size = new Size(18, 15);
            idLabel.TabIndex = 0;
            idLabel.Text = "ID";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(12, 53);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(106, 15);
            nameLabel.TabIndex = 1;
            nameLabel.Text = "Название изотопа";
            // 
            // idTextBox
            // 
            idTextBox.Location = new Point(124, 9);
            idTextBox.Name = "idTextBox";
            idTextBox.ReadOnly = true;
            idTextBox.Size = new Size(223, 23);
            idTextBox.TabIndex = 2;
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(124, 50);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(223, 23);
            nameTextBox.TabIndex = 3;
            nameTextBox.TextChanged += nameTextBox_TextChanged;
            // 
            // closeButton
            // 
            closeButton.Location = new Point(12, 349);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(115, 23);
            closeButton.TabIndex = 4;
            closeButton.Text = "Закрыть";
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += closeButton_Click;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(232, 349);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(115, 23);
            saveButton.TabIndex = 5;
            saveButton.Text = "Сохранить";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // deleteButton
            // 
            deleteButton.ForeColor = Color.IndianRed;
            deleteButton.Location = new Point(232, 320);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(115, 23);
            deleteButton.TabIndex = 6;
            deleteButton.Text = "Удалить изотоп";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click;
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { statusLabel });
            statusStrip.Location = new Point(0, 375);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(359, 22);
            statusStrip.SizingGrip = false;
            statusStrip.TabIndex = 7;
            statusStrip.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            statusLabel.ForeColor = Color.IndianRed;
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(66, 17);
            statusLabel.Text = "statusLabel";
            // 
            // cascadeLabel
            // 
            cascadeLabel.AutoSize = true;
            cascadeLabel.Location = new Point(12, 89);
            cascadeLabel.Name = "cascadeLabel";
            cascadeLabel.Size = new Size(108, 15);
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
            cascadeGridView.Location = new Point(12, 107);
            cascadeGridView.Name = "cascadeGridView";
            cascadeGridView.ReadOnly = true;
            cascadeGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            cascadeGridView.RowTemplate.Height = 25;
            cascadeGridView.Size = new Size(335, 207);
            cascadeGridView.TabIndex = 9;
            // 
            // emptyCascadeLabel
            // 
            emptyCascadeLabel.AutoSize = true;
            emptyCascadeLabel.Location = new Point(30, 203);
            emptyCascadeLabel.Name = "emptyCascadeLabel";
            emptyCascadeLabel.Size = new Size(301, 15);
            emptyCascadeLabel.TabIndex = 10;
            emptyCascadeLabel.Text = "Отсутсвтуют материалы, связанные с этим изотопом";
            // 
            // IsotopeDisplayForm
            // 
            AcceptButton = saveButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = closeButton;
            ClientSize = new Size(359, 397);
            Controls.Add(cascadeGridView);
            Controls.Add(cascadeLabel);
            Controls.Add(statusStrip);
            Controls.Add(deleteButton);
            Controls.Add(saveButton);
            Controls.Add(closeButton);
            Controls.Add(nameTextBox);
            Controls.Add(idTextBox);
            Controls.Add(nameLabel);
            Controls.Add(idLabel);
            Controls.Add(emptyCascadeLabel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
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