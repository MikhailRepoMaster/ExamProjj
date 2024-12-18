namespace WinFormsApp1
{
    partial class mainScreenForm
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
            greetingLabel = new Label();
            radioButtonCreate = new RadioButton();
            radioButtonRead = new RadioButton();
            radioButtonUpdate = new RadioButton();
            radioButtonDelete = new RadioButton();
            activateButton = new Button();
            tablesComboBox = new ComboBox();
            forEntriesRichTextBox = new RichTextBox();
            adminButton = new Button();
            orderByComboBox = new ComboBox();
            limitTextBox = new TextBox();
            SuspendLayout();
            // 
            // greetingLabel
            // 
            greetingLabel.AutoSize = true;
            greetingLabel.ForeColor = SystemColors.Control;
            greetingLabel.Location = new Point(12, 9);
            greetingLabel.Name = "greetingLabel";
            greetingLabel.Size = new Size(38, 15);
            greetingLabel.TabIndex = 0;
            greetingLabel.Text = "label1";
            // 
            // radioButtonCreate
            // 
            radioButtonCreate.AutoSize = true;
            radioButtonCreate.ForeColor = SystemColors.Control;
            radioButtonCreate.Location = new Point(12, 107);
            radioButtonCreate.Name = "radioButtonCreate";
            radioButtonCreate.Size = new Size(118, 19);
            radioButtonCreate.TabIndex = 9;
            radioButtonCreate.TabStop = true;
            radioButtonCreate.Text = "Создание записи";
            radioButtonCreate.UseVisualStyleBackColor = true;
            radioButtonCreate.CheckedChanged += radioButtonCreate_CheckedChanged;
            // 
            // radioButtonRead
            // 
            radioButtonRead.AutoSize = true;
            radioButtonRead.ForeColor = SystemColors.Control;
            radioButtonRead.Location = new Point(12, 132);
            radioButtonRead.Name = "radioButtonRead";
            radioButtonRead.Size = new Size(112, 19);
            radioButtonRead.TabIndex = 10;
            radioButtonRead.TabStop = true;
            radioButtonRead.Text = "Вывести записи";
            radioButtonRead.UseVisualStyleBackColor = true;
            radioButtonRead.CheckedChanged += radioButtonRead_CheckedChanged;
            // 
            // radioButtonUpdate
            // 
            radioButtonUpdate.AutoSize = true;
            radioButtonUpdate.ForeColor = SystemColors.Control;
            radioButtonUpdate.Location = new Point(12, 157);
            radioButtonUpdate.Name = "radioButtonUpdate";
            radioButtonUpdate.Size = new Size(119, 19);
            radioButtonUpdate.TabIndex = 11;
            radioButtonUpdate.TabStop = true;
            radioButtonUpdate.Text = "Изменить запись";
            radioButtonUpdate.UseVisualStyleBackColor = true;
            radioButtonUpdate.CheckedChanged += radioButtonUpdate_CheckedChanged;
            // 
            // radioButtonDelete
            // 
            radioButtonDelete.AutoSize = true;
            radioButtonDelete.ForeColor = Color.White;
            radioButtonDelete.Location = new Point(12, 182);
            radioButtonDelete.Name = "radioButtonDelete";
            radioButtonDelete.Size = new Size(109, 19);
            radioButtonDelete.TabIndex = 12;
            radioButtonDelete.TabStop = true;
            radioButtonDelete.Text = "Удалить запись";
            radioButtonDelete.UseVisualStyleBackColor = true;
            radioButtonDelete.CheckedChanged += radioButtonDelete_CheckedChanged;
            // 
            // activateButton
            // 
            activateButton.BackColor = Color.Black;
            activateButton.ForeColor = SystemColors.Control;
            activateButton.Location = new Point(288, 378);
            activateButton.Name = "activateButton";
            activateButton.Size = new Size(284, 71);
            activateButton.TabIndex = 13;
            activateButton.Text = "Активировать";
            activateButton.UseVisualStyleBackColor = false;
            activateButton.Click += activateButton_Click;
            // 
            // tablesComboBox
            // 
            tablesComboBox.FormattingEnabled = true;
            tablesComboBox.Location = new Point(12, 207);
            tablesComboBox.Name = "tablesComboBox";
            tablesComboBox.Size = new Size(121, 23);
            tablesComboBox.TabIndex = 14;
            // 
            // forEntriesRichTextBox
            // 
            forEntriesRichTextBox.Location = new Point(235, 12);
            forEntriesRichTextBox.Name = "forEntriesRichTextBox";
            forEntriesRichTextBox.Size = new Size(337, 218);
            forEntriesRichTextBox.TabIndex = 15;
            forEntriesRichTextBox.Text = "";
            // 
            // adminButton
            // 
            adminButton.Enabled = false;
            adminButton.Location = new Point(288, 301);
            adminButton.Name = "adminButton";
            adminButton.Size = new Size(284, 71);
            adminButton.TabIndex = 16;
            adminButton.Text = "Кнопка админа";
            adminButton.UseVisualStyleBackColor = true;
            adminButton.Visible = false;
            adminButton.Click += adminButton_Click;
            // 
            // orderByComboBox
            // 
            orderByComboBox.FormattingEnabled = true;
            orderByComboBox.Location = new Point(12, 301);
            orderByComboBox.Name = "orderByComboBox";
            orderByComboBox.Size = new Size(121, 23);
            orderByComboBox.TabIndex = 18;
            // 
            // limitTextBox
            // 
            limitTextBox.Location = new Point(235, 236);
            limitTextBox.Name = "limitTextBox";
            limitTextBox.Size = new Size(100, 23);
            limitTextBox.TabIndex = 20;
            // 
            // mainScreenForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(12, 22, 32);
            ClientSize = new Size(584, 461);
            Controls.Add(limitTextBox);
            Controls.Add(orderByComboBox);
            Controls.Add(adminButton);
            Controls.Add(forEntriesRichTextBox);
            Controls.Add(tablesComboBox);
            Controls.Add(activateButton);
            Controls.Add(radioButtonDelete);
            Controls.Add(radioButtonUpdate);
            Controls.Add(radioButtonRead);
            Controls.Add(radioButtonCreate);
            Controls.Add(greetingLabel);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "mainScreenForm";
            Text = "Form3";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label greetingLabel;
        private RadioButton radioButtonCreate;
        private RadioButton radioButtonRead;
        private RadioButton radioButtonUpdate;
        private RadioButton radioButtonDelete;
        private Button activateButton;
        private ComboBox tablesComboBox;
        private RichTextBox forEntriesRichTextBox;
        private Button adminButton;
        private ComboBox orderByComboBox;
        private TextBox limitTextBox;
    }
}