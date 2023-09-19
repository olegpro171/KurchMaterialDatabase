﻿namespace WinFormsApp
{
    partial class NewIsotopeRelationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewIsotopeRelationForm));
            idLabel = new Label();
            materialNameLabel = new Label();
            materialIdTextBox = new TextBox();
            materialNameTextBox = new TextBox();
            isotopeBox = new ComboBox();
            isotopeLabel = new Label();
            densityBox = new TextBox();
            concLabel = new Label();
            closeButton = new Button();
            addButton = new Button();
            densErrorLabel = new Label();
            deleteButton = new Button();
            SuspendLayout();
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new Point(12, 9);
            idLabel.Name = "idLabel";
            idLabel.Size = new Size(18, 15);
            idLabel.TabIndex = 0;
            idLabel.Text = "ID";
            // 
            // materialNameLabel
            // 
            materialNameLabel.AutoSize = true;
            materialNameLabel.Location = new Point(118, 9);
            materialNameLabel.Name = "materialNameLabel";
            materialNameLabel.Size = new Size(62, 15);
            materialNameLabel.TabIndex = 1;
            materialNameLabel.Text = "Материал";
            // 
            // materialIdTextBox
            // 
            materialIdTextBox.Location = new Point(12, 27);
            materialIdTextBox.Name = "materialIdTextBox";
            materialIdTextBox.ReadOnly = true;
            materialIdTextBox.Size = new Size(100, 23);
            materialIdTextBox.TabIndex = 100;
            // 
            // materialNameTextBox
            // 
            materialNameTextBox.Location = new Point(118, 27);
            materialNameTextBox.Name = "materialNameTextBox";
            materialNameTextBox.ReadOnly = true;
            materialNameTextBox.Size = new Size(164, 23);
            materialNameTextBox.TabIndex = 200;
            materialNameTextBox.TextChanged += materialNameTextBox_TextChanged;
            // 
            // isotopeBox
            // 
            isotopeBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            isotopeBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            isotopeBox.FormattingEnabled = true;
            isotopeBox.Location = new Point(12, 81);
            isotopeBox.Name = "isotopeBox";
            isotopeBox.Size = new Size(270, 23);
            isotopeBox.TabIndex = 300;
            isotopeBox.SelectedIndexChanged += isotopeBox_SelectedIndexChanged;
            // 
            // isotopeLabel
            // 
            isotopeLabel.AutoSize = true;
            isotopeLabel.Location = new Point(12, 63);
            isotopeLabel.Name = "isotopeLabel";
            isotopeLabel.Size = new Size(47, 15);
            isotopeLabel.TabIndex = 5;
            isotopeLabel.Text = "Изотоп";
            // 
            // densityBox
            // 
            densityBox.Location = new Point(94, 110);
            densityBox.Name = "densityBox";
            densityBox.Size = new Size(189, 23);
            densityBox.TabIndex = 400;
            densityBox.TextChanged += densityBox_TextChanged;
            // 
            // concLabel
            // 
            concLabel.AutoSize = true;
            concLabel.Location = new Point(12, 113);
            concLabel.Name = "concLabel";
            concLabel.Size = new Size(76, 15);
            concLabel.TabIndex = 7;
            concLabel.Text = "Содержание";
            // 
            // closeButton
            // 
            closeButton.Location = new Point(12, 188);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(100, 23);
            closeButton.TabIndex = 600;
            closeButton.Text = "Закрыть";
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += closeButton_Click;
            // 
            // addButton
            // 
            addButton.Location = new Point(185, 188);
            addButton.Name = "addButton";
            addButton.Size = new Size(95, 23);
            addButton.TabIndex = 500;
            addButton.Text = "Добавить";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // densErrorLabel
            // 
            densErrorLabel.Anchor = AnchorStyles.Right;
            densErrorLabel.AutoSize = true;
            densErrorLabel.ForeColor = Color.Red;
            densErrorLabel.Location = new Point(96, 134);
            densErrorLabel.Name = "densErrorLabel";
            densErrorLabel.Size = new Size(165, 15);
            densErrorLabel.TabIndex = 10;
            densErrorLabel.Text = "Ведите корректное значение";
            densErrorLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // deleteButton
            // 
            deleteButton.ForeColor = Color.IndianRed;
            deleteButton.Location = new Point(185, 159);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(97, 23);
            deleteButton.TabIndex = 700;
            deleteButton.Text = "Удалить";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click;
            // 
            // NewIsotopeRelationForm
            // 
            AcceptButton = addButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = closeButton;
            ClientSize = new Size(296, 221);
            Controls.Add(deleteButton);
            Controls.Add(densErrorLabel);
            Controls.Add(addButton);
            Controls.Add(closeButton);
            Controls.Add(concLabel);
            Controls.Add(densityBox);
            Controls.Add(isotopeLabel);
            Controls.Add(isotopeBox);
            Controls.Add(materialNameTextBox);
            Controls.Add(materialIdTextBox);
            Controls.Add(materialNameLabel);
            Controls.Add(idLabel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "NewIsotopeRelationForm";
            Text = "Изотоп";
            Load += NewIsotopeRelationForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label idLabel;
        private Label materialNameLabel;
        private TextBox materialIdTextBox;
        private TextBox materialNameTextBox;
        private ComboBox isotopeBox;
        private Label isotopeLabel;
        private TextBox densityBox;
        private Label concLabel;
        private Button closeButton;
        private Button addButton;
        private Label densErrorLabel;
        private Button deleteButton;
    }
}