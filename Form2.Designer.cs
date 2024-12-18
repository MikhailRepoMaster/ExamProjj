namespace WinFormsApp1
{
    partial class AuthorizeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuthorizeForm));
            authorizeLabel = new Label();
            authorizePasswordLabel = new Label();
            authorizeNameLabel = new Label();
            authorizePasswordTextbox = new TextBox();
            authorizeTextBoxName = new TextBox();
            authorizeCheckBox = new CheckBox();
            authorizeEnterAccountButton = new Button();
            authorizeRegistrationTextLabel = new Label();
            registrationPictureBox = new PictureBox();
            attentionPasswordLoginEquals = new Label();
            ((System.ComponentModel.ISupportInitialize)registrationPictureBox).BeginInit();
            SuspendLayout();
            // 
            // authorizeLabel
            // 
            authorizeLabel.AutoSize = true;
            authorizeLabel.BackColor = Color.White;
            authorizeLabel.Font = new Font("Yu Gothic UI", 15.75F);
            authorizeLabel.Location = new Point(157, 108);
            authorizeLabel.Margin = new Padding(10);
            authorizeLabel.Name = "authorizeLabel";
            authorizeLabel.Padding = new Padding(50, 5, 50, 5);
            authorizeLabel.Size = new Size(239, 40);
            authorizeLabel.TabIndex = 0;
            authorizeLabel.Text = "Авторизация";
            // 
            // authorizePasswordLabel
            // 
            authorizePasswordLabel.AutoSize = true;
            authorizePasswordLabel.BackColor = Color.FromArgb(12, 22, 32);
            authorizePasswordLabel.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            authorizePasswordLabel.ForeColor = Color.Snow;
            authorizePasswordLabel.Location = new Point(157, 232);
            authorizePasswordLabel.Name = "authorizePasswordLabel";
            authorizePasswordLabel.Size = new Size(56, 16);
            authorizePasswordLabel.TabIndex = 8;
            authorizePasswordLabel.Text = "Пароль";
            // 
            // authorizeNameLabel
            // 
            authorizeNameLabel.AutoSize = true;
            authorizeNameLabel.BackColor = Color.FromArgb(12, 22, 32);
            authorizeNameLabel.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            authorizeNameLabel.ForeColor = Color.Snow;
            authorizeNameLabel.Location = new Point(157, 168);
            authorizeNameLabel.Name = "authorizeNameLabel";
            authorizeNameLabel.Size = new Size(129, 16);
            authorizeNameLabel.TabIndex = 7;
            authorizeNameLabel.Text = "Имя пользователя";
            // 
            // authorizePasswordTextbox
            // 
            authorizePasswordTextbox.Location = new Point(157, 252);
            authorizePasswordTextbox.Name = "authorizePasswordTextbox";
            authorizePasswordTextbox.Size = new Size(234, 23);
            authorizePasswordTextbox.TabIndex = 6;
            authorizePasswordTextbox.TextChanged += authorizePasswordTextbox_TextChanged;
            // 
            // authorizeTextBoxName
            // 
            authorizeTextBoxName.Location = new Point(157, 188);
            authorizeTextBoxName.Name = "authorizeTextBoxName";
            authorizeTextBoxName.Size = new Size(234, 23);
            authorizeTextBoxName.TabIndex = 5;
            // 
            // authorizeCheckBox
            // 
            authorizeCheckBox.AutoSize = true;
            authorizeCheckBox.Location = new Point(397, 256);
            authorizeCheckBox.Name = "authorizeCheckBox";
            authorizeCheckBox.Size = new Size(15, 14);
            authorizeCheckBox.TabIndex = 9;
            authorizeCheckBox.UseVisualStyleBackColor = true;
            authorizeCheckBox.CheckedChanged += authorizeCheckBox_CheckedChanged;
            // 
            // authorizeEnterAccountButton
            // 
            authorizeEnterAccountButton.BackColor = Color.White;
            authorizeEnterAccountButton.Font = new Font("Microsoft Sans Serif", 9.75F);
            authorizeEnterAccountButton.Location = new Point(157, 331);
            authorizeEnterAccountButton.Name = "authorizeEnterAccountButton";
            authorizeEnterAccountButton.Size = new Size(234, 39);
            authorizeEnterAccountButton.TabIndex = 11;
            authorizeEnterAccountButton.Text = "Войти в аккаунт";
            authorizeEnterAccountButton.UseVisualStyleBackColor = false;
            authorizeEnterAccountButton.Click += authorizeEnterAccountButton_Click;
            // 
            // authorizeRegistrationTextLabel
            // 
            authorizeRegistrationTextLabel.AutoSize = true;
            authorizeRegistrationTextLabel.ForeColor = Color.DodgerBlue;
            authorizeRegistrationTextLabel.Location = new Point(157, 278);
            authorizeRegistrationTextLabel.Name = "authorizeRegistrationTextLabel";
            authorizeRegistrationTextLabel.Size = new Size(76, 15);
            authorizeRegistrationTextLabel.TabIndex = 10;
            authorizeRegistrationTextLabel.Text = "Регистрация";
            authorizeRegistrationTextLabel.Click += authorizeRegistrationTextLabel_Click;
            // 
            // registrationPictureBox
            // 
            registrationPictureBox.Image = (Image)resources.GetObject("registrationPictureBox.Image");
            registrationPictureBox.Location = new Point(221, 12);
            registrationPictureBox.Name = "registrationPictureBox";
            registrationPictureBox.Size = new Size(108, 94);
            registrationPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            registrationPictureBox.TabIndex = 12;
            registrationPictureBox.TabStop = false;
            // 
            // attentionPasswordLoginEquals
            // 
            attentionPasswordLoginEquals.AutoSize = true;
            attentionPasswordLoginEquals.ForeColor = Color.Red;
            attentionPasswordLoginEquals.Location = new Point(157, 373);
            attentionPasswordLoginEquals.Name = "attentionPasswordLoginEquals";
            attentionPasswordLoginEquals.Size = new Size(0, 15);
            attentionPasswordLoginEquals.TabIndex = 13;
            // 
            // AuthorizeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(12, 22, 32);
            ClientSize = new Size(584, 461);
            Controls.Add(attentionPasswordLoginEquals);
            Controls.Add(registrationPictureBox);
            Controls.Add(authorizeEnterAccountButton);
            Controls.Add(authorizeRegistrationTextLabel);
            Controls.Add(authorizeCheckBox);
            Controls.Add(authorizePasswordLabel);
            Controls.Add(authorizeNameLabel);
            Controls.Add(authorizePasswordTextbox);
            Controls.Add(authorizeTextBoxName);
            Controls.Add(authorizeLabel);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "AuthorizeForm";
            Text = "Authorize";
            ((System.ComponentModel.ISupportInitialize)registrationPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label authorizeLabel;
        private Label authorizePasswordLabel;
        private Label authorizeNameLabel;
        private TextBox authorizePasswordTextbox;
        private TextBox authorizeTextBoxName;
        private CheckBox authorizeCheckBox;
        private Button authorizeEnterAccountButton;
        private Label authorizeRegistrationTextLabel;
        private PictureBox registrationPictureBox;
        private Label attentionPasswordLoginEquals;
    }
}