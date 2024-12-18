namespace WinFormsApp1
{
    partial class RegistrationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrationForm));
            registrationLabel = new Label();
            textBox1 = new TextBox();
            registrationPasswordTextbox = new TextBox();
            registrationNameLabel = new Label();
            registrationPasswordLabel = new Label();
            checkBox1 = new CheckBox();
            registrationAuthorizeTextLabel = new Label();
            registrationCreateAccountButton = new Button();
            registrationPictureBox = new PictureBox();
            attentionLoginPasswordEqual = new Label();
            ((System.ComponentModel.ISupportInitialize)registrationPictureBox).BeginInit();
            SuspendLayout();
            // 
            // registrationLabel
            // 
            registrationLabel.AutoSize = true;
            registrationLabel.BackColor = Color.White;
            registrationLabel.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            registrationLabel.Location = new Point(157, 108);
            registrationLabel.Margin = new Padding(10);
            registrationLabel.Name = "registrationLabel";
            registrationLabel.Padding = new Padding(50, 5, 50, 5);
            registrationLabel.Size = new Size(234, 40);
            registrationLabel.TabIndex = 0;
            registrationLabel.Text = "Регистрация";
            registrationLabel.Click += label1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(157, 188);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(234, 23);
            textBox1.TabIndex = 1;
            // 
            // registrationPasswordTextbox
            // 
            registrationPasswordTextbox.Location = new Point(157, 252);
            registrationPasswordTextbox.Name = "registrationPasswordTextbox";
            registrationPasswordTextbox.Size = new Size(234, 23);
            registrationPasswordTextbox.TabIndex = 2;
            registrationPasswordTextbox.TextChanged += registrationPasswordTextbox_TextChanged;
            // 
            // registrationNameLabel
            // 
            registrationNameLabel.AutoSize = true;
            registrationNameLabel.BackColor = Color.FromArgb(12, 22, 32);
            registrationNameLabel.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            registrationNameLabel.ForeColor = Color.Snow;
            registrationNameLabel.Location = new Point(157, 168);
            registrationNameLabel.Name = "registrationNameLabel";
            registrationNameLabel.Size = new Size(129, 16);
            registrationNameLabel.TabIndex = 3;
            registrationNameLabel.Text = "Имя пользователя";
            // 
            // registrationPasswordLabel
            // 
            registrationPasswordLabel.AutoSize = true;
            registrationPasswordLabel.BackColor = Color.FromArgb(12, 22, 32);
            registrationPasswordLabel.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            registrationPasswordLabel.ForeColor = Color.Snow;
            registrationPasswordLabel.Location = new Point(157, 232);
            registrationPasswordLabel.Name = "registrationPasswordLabel";
            registrationPasswordLabel.Size = new Size(56, 16);
            registrationPasswordLabel.TabIndex = 4;
            registrationPasswordLabel.Text = "Пароль";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(397, 256);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(15, 14);
            checkBox1.TabIndex = 5;
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // registrationAuthorizeTextLabel
            // 
            registrationAuthorizeTextLabel.AutoSize = true;
            registrationAuthorizeTextLabel.ForeColor = Color.DodgerBlue;
            registrationAuthorizeTextLabel.Location = new Point(157, 278);
            registrationAuthorizeTextLabel.Name = "registrationAuthorizeTextLabel";
            registrationAuthorizeTextLabel.Size = new Size(78, 15);
            registrationAuthorizeTextLabel.TabIndex = 6;
            registrationAuthorizeTextLabel.Text = "Авторизация";
            registrationAuthorizeTextLabel.Click += registrationAuthorizeTextLabel_Click;
            // 
            // registrationCreateAccountButton
            // 
            registrationCreateAccountButton.BackColor = Color.White;
            registrationCreateAccountButton.Font = new Font("Microsoft Sans Serif", 9.75F);
            registrationCreateAccountButton.Location = new Point(157, 331);
            registrationCreateAccountButton.Name = "registrationCreateAccountButton";
            registrationCreateAccountButton.Size = new Size(234, 39);
            registrationCreateAccountButton.TabIndex = 7;
            registrationCreateAccountButton.Text = "Создать аккаунт";
            registrationCreateAccountButton.UseVisualStyleBackColor = false;
            registrationCreateAccountButton.Click += registrationCreateAccountButton_Click;
            registrationCreateAccountButton.MouseEnter += registrationCreateAccountButton_MouseHover;
            registrationCreateAccountButton.MouseLeave += registrationCreateAccountButton_MouseHoverLeave;
            // 
            // registrationPictureBox
            // 
            registrationPictureBox.Image = (Image)resources.GetObject("registrationPictureBox.Image");
            registrationPictureBox.Location = new Point(221, 12);
            registrationPictureBox.Name = "registrationPictureBox";
            registrationPictureBox.Size = new Size(108, 94);
            registrationPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            registrationPictureBox.TabIndex = 0;
            registrationPictureBox.TabStop = false;
            // 
            // attentionLoginPasswordEqual
            // 
            attentionLoginPasswordEqual.AutoSize = true;
            attentionLoginPasswordEqual.ForeColor = Color.Red;
            attentionLoginPasswordEqual.Location = new Point(157, 373);
            attentionLoginPasswordEqual.Name = "attentionLoginPasswordEqual";
            attentionLoginPasswordEqual.Size = new Size(0, 15);
            attentionLoginPasswordEqual.TabIndex = 8;
            attentionLoginPasswordEqual.Visible = false;
            // 
            // RegistrationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(12, 22, 32);
            ClientSize = new Size(584, 461);
            Controls.Add(attentionLoginPasswordEqual);
            Controls.Add(registrationPictureBox);
            Controls.Add(registrationCreateAccountButton);
            Controls.Add(registrationAuthorizeTextLabel);
            Controls.Add(checkBox1);
            Controls.Add(registrationPasswordLabel);
            Controls.Add(registrationNameLabel);
            Controls.Add(registrationPasswordTextbox);
            Controls.Add(textBox1);
            Controls.Add(registrationLabel);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "RegistrationForm";
            Text = "Registration";
            ((System.ComponentModel.ISupportInitialize)registrationPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label registrationLabel;
        private TextBox textBox1;
        private TextBox registrationPasswordTextbox;
        private Label registrationNameLabel;
        private Label registrationPasswordLabel;
        private CheckBox checkBox1;
        private Label registrationAuthorizeTextLabel;
        private Button registrationCreateAccountButton;
        private PictureBox registrationPictureBox;
        private Label attentionLoginPasswordEqual;
    }
}
