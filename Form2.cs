using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace WinFormsApp1
{
    public partial class AuthorizeForm : Form
    {
        private SqlConnection connectionString = new SqlConnection("Server=LocalHost;Database=CarParkManager;Integrated Security=True;Trust Server Certificate=True;");

        public AuthorizeForm()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void AuthorizeComplete(SqlConnection connectionString)
        {
            string authorizeLoginAndPassword = @"SELECT COUNT(*) FROM dbo.Users WHERE Login = @Login AND Password = @Password";

            try
            {
                using (SqlCommand command = new SqlCommand(authorizeLoginAndPassword, connectionString))
                {
                    connectionString.Open();

                    string login = authorizeTextBoxName.Text.Trim();
                    string password = authorizePasswordTextbox.Text.Trim();

                    byte[] passwordBytes = Encoding.UTF8.GetBytes(password); SHA256 sha256 = SHA256.Create();
                    byte[] hashedPasswordBytes = sha256.ComputeHash(passwordBytes);
                    string hashedPassword = BitConverter.ToString(hashedPasswordBytes).Replace("-", "").ToLower();


                    command.Parameters.AddWithValue("@Login", Convert.ToString(login));
                    command.Parameters.AddWithValue("@Password", Convert.ToString(hashedPassword));

                    int userCount = (int)command.ExecuteScalar();

                    if (userCount > 0)
                    {
                        string userName = login;

                        connectionString.Close();

                        mainScreenForm mScreenForm = new mainScreenForm(userName);
                        this.Hide();
                        mScreenForm.FormClosed += (sender, e) => this.Close();
                        mScreenForm.ShowDialog();

                    }
                    else attentionPasswordLoginEquals.Text = "Неверный логин или пароль"; attentionPasswordLoginEquals.Visible = true; connectionString.Close();

                    
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Произошла ошибка: {ex}");
                connectionString.Close();
            }
        }



        private void authorizeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (authorizeCheckBox.Checked)
            {
                authorizePasswordTextbox.UseSystemPasswordChar = false;
            }
            else
            {
                authorizePasswordTextbox.UseSystemPasswordChar = true;
            }
        }

        private void authorizePasswordTextbox_TextChanged(object sender, EventArgs e)
        {
            authorizePasswordTextbox.UseSystemPasswordChar = true;
            authorizeCheckBox.Checked = false;
        }

        private void authorizeEnterAccountButton_MouseEnter(object sender, EventArgs e)
        {
            authorizeEnterAccountButton.BackColor = Color.RoyalBlue;
            authorizeEnterAccountButton.ForeColor = Color.White;
        }

        private void authorizeEnterAccountButton_MouseLeave(object sender, EventArgs e)
        {
            authorizeEnterAccountButton.BackColor = Color.White;
            authorizeEnterAccountButton.ForeColor = Color.Black;
        }

        private void authorizeRegistrationTextLabel_Click(object sender, EventArgs e)
        {
            //RegistrationForm registrationForm = new RegistrationForm();

            //registrationForm.Show();
            //this.Close();

            RegistrationForm registrationForm = new RegistrationForm();
            this.Hide();
            registrationForm.FormClosed += (sender, e) => this.Close();
            registrationForm.ShowDialog();
        }

        private void authorizeEnterAccountButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(authorizePasswordTextbox.Text) && !string.IsNullOrEmpty(authorizeTextBoxName.Text))
            {
                AuthorizeComplete(connectionString);
            }
            else attentionPasswordLoginEquals.Text = "Заполните все поля"; attentionPasswordLoginEquals.Visible = true;
        }

        private void AuthorizeForm_Load(object sender, EventArgs e)
        {
            //не трогать ничего
        }
    }
}
