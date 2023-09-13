namespace WinFormsApp
{
    partial class FuelDisplayForm
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
            idTextBox = new TextBox();
            idLabel = new Label();
            nameLabel = new Label();
            descLabel = new Label();
            densLabel = new Label();
            isoLabel = new Label();
            nameTextBox = new TextBox();
            descTextBox = new TextBox();
            densTextBox = new TextBox();
            isoGrid = new DataGridView();
            saveButton = new Button();
            cancelButton = new Button();
            isoChangeButton = new Button();
            densErrorLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)isoGrid).BeginInit();
            SuspendLayout();
            // 
            // idTextBox
            // 
            idTextBox.Enabled = false;
            idTextBox.Location = new Point(36, 6);
            idTextBox.Name = "idTextBox";
            idTextBox.ReadOnly = true;
            idTextBox.Size = new Size(100, 23);
            idTextBox.TabIndex = 0;
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new Point(12, 9);
            idLabel.Name = "idLabel";
            idLabel.Size = new Size(18, 15);
            idLabel.TabIndex = 1;
            idLabel.Text = "ID";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(180, 9);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(31, 15);
            nameLabel.TabIndex = 2;
            nameLabel.Text = "Имя";
            // 
            // descLabel
            // 
            descLabel.AutoSize = true;
            descLabel.Location = new Point(12, 73);
            descLabel.Name = "descLabel";
            descLabel.Size = new Size(62, 15);
            descLabel.TabIndex = 3;
            descLabel.Text = "Описание";
            // 
            // densLabel
            // 
            densLabel.AutoSize = true;
            densLabel.Location = new Point(145, 38);
            densLabel.Name = "densLabel";
            densLabel.Size = new Size(66, 15);
            densLabel.TabIndex = 4;
            densLabel.Text = "Плотность";
            // 
            // isoLabel
            // 
            isoLabel.AutoSize = true;
            isoLabel.Location = new Point(12, 207);
            isoLabel.Name = "isoLabel";
            isoLabel.Size = new Size(130, 15);
            isoLabel.TabIndex = 5;
            isoLabel.Text = "Содержания изотопов";
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(217, 6);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(186, 23);
            nameTextBox.TabIndex = 6;
            nameTextBox.TextChanged += nameTextBox_TextChanged;
            // 
            // descTextBox
            // 
            descTextBox.Location = new Point(12, 91);
            descTextBox.Multiline = true;
            descTextBox.Name = "descTextBox";
            descTextBox.ScrollBars = ScrollBars.Vertical;
            descTextBox.Size = new Size(391, 101);
            descTextBox.TabIndex = 7;
            descTextBox.TextChanged += descTextBox_TextChanged;
            // 
            // densTextBox
            // 
            densTextBox.Location = new Point(217, 35);
            densTextBox.Name = "densTextBox";
            densTextBox.Size = new Size(186, 23);
            densTextBox.TabIndex = 8;
            densTextBox.TextChanged += densTextBox_TextChanged;
            // 
            // isoGrid
            // 
            isoGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            isoGrid.Location = new Point(12, 225);
            isoGrid.Name = "isoGrid";
            isoGrid.RowTemplate.Height = 25;
            isoGrid.Size = new Size(391, 213);
            isoGrid.TabIndex = 9;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(328, 444);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(75, 23);
            saveButton.TabIndex = 10;
            saveButton.Text = "Сохранить";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(260, 444);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(62, 23);
            cancelButton.TabIndex = 11;
            cancelButton.Text = "Отмена";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // isoChangeButton
            // 
            isoChangeButton.Location = new Point(12, 444);
            isoChangeButton.Name = "isoChangeButton";
            isoChangeButton.Size = new Size(222, 23);
            isoChangeButton.TabIndex = 12;
            isoChangeButton.Text = "Редактировать содержания изотопов";
            isoChangeButton.UseVisualStyleBackColor = true;
            isoChangeButton.Click += isoChangeButton_Click;
            // 
            // densErrorLabel
            // 
            densErrorLabel.AutoSize = true;
            densErrorLabel.Location = new Point(217, 61);
            densErrorLabel.Name = "densErrorLabel";
            densErrorLabel.Size = new Size(0, 15);
            densErrorLabel.TabIndex = 13;
            // 
            // FuelDisplayForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(415, 474);
            Controls.Add(densErrorLabel);
            Controls.Add(isoChangeButton);
            Controls.Add(cancelButton);
            Controls.Add(saveButton);
            Controls.Add(isoGrid);
            Controls.Add(densTextBox);
            Controls.Add(descTextBox);
            Controls.Add(nameTextBox);
            Controls.Add(isoLabel);
            Controls.Add(densLabel);
            Controls.Add(descLabel);
            Controls.Add(nameLabel);
            Controls.Add(idLabel);
            Controls.Add(idTextBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FuelDisplayForm";
            Text = "FuelDisplayForm";
            ((System.ComponentModel.ISupportInitialize)isoGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox idTextBox;
        private Label idLabel;
        private Label nameLabel;
        private Label descLabel;
        private Label densLabel;
        private Label isoLabel;
        private TextBox nameTextBox;
        private TextBox descTextBox;
        private TextBox densTextBox;
        private DataGridView isoGrid;
        private Button saveButton;
        private Button cancelButton;
        private Button isoChangeButton;
        private Label densErrorLabel;
    }
}