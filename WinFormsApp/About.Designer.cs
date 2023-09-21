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
            label1 = new Label();
            closeButton = new Button();
            sourceLink = new LinkLabel();
            infoLabel1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // nameMainLabel
            // 
            nameMainLabel.Dock = DockStyle.Top;
            nameMainLabel.Font = new Font("Segoe UI", 19F, FontStyle.Regular, GraphicsUnit.Point);
            nameMainLabel.Location = new Point(0, 0);
            nameMainLabel.Name = "nameMainLabel";
            nameMainLabel.Size = new Size(391, 79);
            nameMainLabel.TabIndex = 0;
            nameMainLabel.Text = "Material Database";
            nameMainLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(closeButton);
            panel1.Controls.Add(sourceLink);
            panel1.Controls.Add(infoLabel1);
            panel1.Controls.Add(nameMainLabel);
            panel1.Location = new Point(14, 16);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(391, 406);
            panel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Bottom;
            label1.Location = new Point(0, 348);
            label1.Name = "label1";
            label1.Size = new Size(391, 27);
            label1.TabIndex = 2;
            label1.Text = "v1.0 21.09.2023";
            label1.Click += label1_Click;
            // 
            // closeButton
            // 
            closeButton.Dock = DockStyle.Bottom;
            closeButton.Location = new Point(0, 375);
            closeButton.Margin = new Padding(3, 4, 3, 4);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(391, 31);
            closeButton.TabIndex = 10;
            closeButton.Text = "Закрыть";
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += closeButton_Click;
            // 
            // sourceLink
            // 
            sourceLink.Dock = DockStyle.Top;
            sourceLink.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            sourceLink.Location = new Point(0, 240);
            sourceLink.Name = "sourceLink";
            sourceLink.Size = new Size(391, 28);
            sourceLink.TabIndex = 20;
            sourceLink.TabStop = true;
            sourceLink.Text = "Репозиторий проекта";
            sourceLink.LinkClicked += sourceLink_LinkClicked;
            // 
            // infoLabel1
            // 
            infoLabel1.Dock = DockStyle.Top;
            infoLabel1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            infoLabel1.Location = new Point(0, 79);
            infoLabel1.Name = "infoLabel1";
            infoLabel1.RightToLeft = RightToLeft.No;
            infoLabel1.Size = new Size(391, 161);
            infoLabel1.TabIndex = 1;
            infoLabel1.Text = "Программа разработана в рамках тестового задания для НИЦ \"Курчатовский Институт\"\r\n\r\nРазработчик: Олег Ярославович Прошкин\r\n";
            // 
            // About
            // 
            AcceptButton = closeButton;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = closeButton;
            ClientSize = new Size(417, 435);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "About";
            Text = "О программе";
            panel1.ResumeLayout(false);
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