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
            statusStrip.SuspendLayout();
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
            idTextBox.Size = new Size(221, 23);
            idTextBox.TabIndex = 2;
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(124, 50);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(221, 23);
            nameTextBox.TabIndex = 3;
            // 
            // closeButton
            // 
            closeButton.Location = new Point(12, 191);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(115, 23);
            closeButton.TabIndex = 4;
            closeButton.Text = "Закрыть";
            closeButton.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(230, 191);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(115, 23);
            saveButton.TabIndex = 5;
            saveButton.Text = "Сохранить";
            saveButton.UseVisualStyleBackColor = true;
            // 
            // deleteButton
            // 
            deleteButton.ForeColor = Color.IndianRed;
            deleteButton.Location = new Point(230, 162);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(115, 23);
            deleteButton.TabIndex = 6;
            deleteButton.Text = "Удалить изотоп";
            deleteButton.UseVisualStyleBackColor = true;
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { statusLabel });
            statusStrip.Location = new Point(0, 217);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(357, 22);
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
            // IsotopeDisplayForm
            // 
            AcceptButton = saveButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = closeButton;
            ClientSize = new Size(357, 239);
            Controls.Add(statusStrip);
            Controls.Add(deleteButton);
            Controls.Add(saveButton);
            Controls.Add(closeButton);
            Controls.Add(nameTextBox);
            Controls.Add(idTextBox);
            Controls.Add(nameLabel);
            Controls.Add(idLabel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "IsotopeDisplayForm";
            Text = "Изотоп";
            Load += IsotopeDisplayForm_Load;
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
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
    }
}