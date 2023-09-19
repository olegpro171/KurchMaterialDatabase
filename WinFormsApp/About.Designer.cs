namespace WinFormsApp
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            nameMainLabel = new Label();
            panel1 = new Panel();
            closeButton = new Button();
            sourceLink = new LinkLabel();
            infoLabel1 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // nameMainLabel
            // 
            nameMainLabel.AutoSize = true;
            nameMainLabel.Font = new Font("Segoe UI", 19F, FontStyle.Regular, GraphicsUnit.Point);
            nameMainLabel.Location = new Point(0, 0);
            nameMainLabel.Name = "nameMainLabel";
            nameMainLabel.Size = new Size(221, 36);
            nameMainLabel.TabIndex = 0;
            nameMainLabel.Text = "Material Database";
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(closeButton);
            panel1.Controls.Add(sourceLink);
            panel1.Controls.Add(infoLabel1);
            panel1.Controls.Add(nameMainLabel);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(341, 302);
            panel1.TabIndex = 1;
            // 
            // closeButton
            // 
            closeButton.Location = new Point(236, 279);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(105, 23);
            closeButton.TabIndex = 4;
            closeButton.Text = "Закрыть";
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += closeButton_Click;
            // 
            // sourceLink
            // 
            sourceLink.AutoSize = true;
            sourceLink.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            sourceLink.Location = new Point(0, 167);
            sourceLink.Name = "sourceLink";
            sourceLink.Size = new Size(147, 19);
            sourceLink.TabIndex = 2;
            sourceLink.TabStop = true;
            sourceLink.Text = "Репозиторий проекта";
            sourceLink.LinkClicked += sourceLink_LinkClicked;
            // 
            // infoLabel1
            // 
            infoLabel1.AutoSize = true;
            infoLabel1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            infoLabel1.Location = new Point(0, 60);
            infoLabel1.Name = "infoLabel1";
            infoLabel1.RightToLeft = RightToLeft.No;
            infoLabel1.Size = new Size(328, 84);
            infoLabel1.TabIndex = 1;
            infoLabel1.Text = "Программа разработана в рамках тестового\r\nзадания для НИЦ \"Курчатовский Институт\"\r\n\r\nРазработчик: Олег Ярославович Прошкин\r\n";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(0, 287);
            label1.Name = "label1";
            label1.Size = new Size(85, 15);
            label1.TabIndex = 2;
            label1.Text = "v1.0 19.09.2023";
            // 
            // About
            // 
            AcceptButton = closeButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = closeButton;
            ClientSize = new Size(365, 326);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "About";
            Text = "О программе";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label nameMainLabel;
        private Panel panel1;
        private LinkLabel sourceLink;
        private Label infoLabel1;
        private Button closeButton;
        private Label label1;
    }
}