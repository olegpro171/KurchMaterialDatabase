namespace WinFormsApp
{
    partial class ConnectionDataWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectionDataWindow));
            databaseTextBox = new TextBox();
            databaseLabel = new Label();
            hostLabel = new Label();
            usernameLabel = new Label();
            passwordLabel = new Label();
            hostTextBox = new TextBox();
            passwordTextBox = new TextBox();
            usernameTextBox = new TextBox();
            submitButton = new Button();
            cancelButton = new Button();
            statusStrip = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // databaseTextBox
            // 
            databaseTextBox.Location = new Point(12, 27);
            databaseTextBox.Name = "databaseTextBox";
            databaseTextBox.PlaceholderText = "postgres";
            databaseTextBox.Size = new Size(155, 23);
            databaseTextBox.TabIndex = 100;
            databaseTextBox.Text = "postgres";
            databaseTextBox.TextChanged += databaseTextBox_TextChanged;
            // 
            // databaseLabel
            // 
            databaseLabel.AutoSize = true;
            databaseLabel.Location = new Point(12, 9);
            databaseLabel.Name = "databaseLabel";
            databaseLabel.Size = new Size(55, 15);
            databaseLabel.TabIndex = 1;
            databaseLabel.Text = "Database";
            // 
            // hostLabel
            // 
            hostLabel.AutoSize = true;
            hostLabel.Location = new Point(12, 53);
            hostLabel.Name = "hostLabel";
            hostLabel.Size = new Size(32, 15);
            hostLabel.TabIndex = 2;
            hostLabel.Text = "Host";
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Location = new Point(173, 9);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(60, 15);
            usernameLabel.TabIndex = 3;
            usernameLabel.Text = "Username";
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new Point(173, 53);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(57, 15);
            passwordLabel.TabIndex = 4;
            passwordLabel.Text = "Password";
            // 
            // hostTextBox
            // 
            hostTextBox.Location = new Point(12, 71);
            hostTextBox.Name = "hostTextBox";
            hostTextBox.PlaceholderText = "localhost";
            hostTextBox.Size = new Size(155, 23);
            hostTextBox.TabIndex = 200;
            hostTextBox.Text = "localhost";
            hostTextBox.TextChanged += hostTextBox_TextChanged;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(173, 71);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PasswordChar = '*';
            passwordTextBox.Size = new Size(155, 23);
            passwordTextBox.TabIndex = 400;
            passwordTextBox.Text = "1";
            passwordTextBox.TextChanged += passwordTextChanged;
            // 
            // usernameTextBox
            // 
            usernameTextBox.Location = new Point(173, 27);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.PlaceholderText = "postgres";
            usernameTextBox.Size = new Size(155, 23);
            usernameTextBox.TabIndex = 300;
            usernameTextBox.Text = "postgres";
            usernameTextBox.TextChanged += usernameTextBox_TextChanged;
            // 
            // submitButton
            // 
            submitButton.Location = new Point(228, 112);
            submitButton.Name = "submitButton";
            submitButton.Size = new Size(100, 23);
            submitButton.TabIndex = 500;
            submitButton.Text = "Задать";
            submitButton.UseVisualStyleBackColor = true;
            submitButton.Click += submitButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(122, 112);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(100, 23);
            cancelButton.TabIndex = 600;
            cancelButton.Text = "Отмена";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip.Location = new Point(0, 148);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(341, 22);
            statusStrip.SizingGrip = false;
            statusStrip.TabIndex = 10;
            statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(0, 17);
            // 
            // ConnectionDataWindow
            // 
            AcceptButton = submitButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelButton;
            ClientSize = new Size(341, 170);
            Controls.Add(statusStrip);
            Controls.Add(cancelButton);
            Controls.Add(submitButton);
            Controls.Add(usernameTextBox);
            Controls.Add(passwordTextBox);
            Controls.Add(hostTextBox);
            Controls.Add(passwordLabel);
            Controls.Add(usernameLabel);
            Controls.Add(hostLabel);
            Controls.Add(databaseLabel);
            Controls.Add(databaseTextBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "ConnectionDataWindow";
            Text = "Параметры соединения";
            FormClosed += ConnectionDataWindow_FormClosed;
            Load += ConnectionDataWindow_Load;
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox databaseTextBox;
        private Label databaseLabel;
        private Label hostLabel;
        private Label usernameLabel;
        private Label passwordLabel;
        private TextBox hostTextBox;
        private TextBox passwordTextBox;
        private TextBox usernameTextBox;
        private Button submitButton;
        private Button cancelButton;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel toolStripStatusLabel1;
    }
}