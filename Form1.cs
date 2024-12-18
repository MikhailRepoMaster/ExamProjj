using Microsoft.Data.SqlClient;
using Microsoft.SqlServer;
using System.Text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using Microsoft.IdentityModel.Tokens;

namespace WinFormsApp1
{
    public partial class RegistrationForm : Form
    {
        private SqlConnection connectionString = new SqlConnection("Server=LocalHost;Database=CarParkManager;Integrated Security=True;Trust Server Certificate=True;");

        public RegistrationForm()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // ничего
        }


        private void registrationPasswordTextbox_TextChanged(object sender, EventArgs e)
        {
            registrationPasswordTextbox.UseSystemPasswordChar = true;
            checkBox1.Checked = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                registrationPasswordTextbox.UseSystemPasswordChar = false;
            }
            else
            {
                registrationPasswordTextbox.UseSystemPasswordChar = true;
            }

        }
        private void registrationCreateAccountButton_Click(object sender, EventArgs e)
        {
            string registrationInsertUser = @"INSERT INTO dbo.Users (Login, Password) VALUES (@Login, @Password)";
            string registrationCheckUser = @"SELECT COUNT(*) FROM dbo.Users WHERE Login = @Login";

            try
            {
                using (SqlCommand checkCommand = new SqlCommand(registrationCheckUser, connectionString))
                {
                    connectionString.Open();

                    string login = textBox1.Text.Trim();
                    string password = registrationPasswordTextbox.Text.Trim();


                    byte[] passwordBytes = Encoding.UTF8.GetBytes(password); SHA256 sha256 = SHA256.Create();
                    byte[] hashedPasswordBytes = sha256.ComputeHash(passwordBytes);
                    string hashedPassword = BitConverter.ToString(hashedPasswordBytes).Replace("-", "").ToLower();


                    checkCommand.Parameters.AddWithValue("@Login", login);
                    int userCount = (int)checkCommand.ExecuteScalar();
                    if (textBox1.Text.Trim() == registrationPasswordTextbox.Text.Trim())
                    {
                        attentionLoginPasswordEqual.Text = "Логин и пароль должны отличаться";
                        attentionLoginPasswordEqual.Visible = true; attentionLoginPasswordEqual.ForeColor = Color.Red;
                    }
                    if (userCount > 0)
                    {
                        attentionLoginPasswordEqual.Text = "Пользователь с таким логином уже существует";
                        attentionLoginPasswordEqual.Visible = true; attentionLoginPasswordEqual.ForeColor = Color.Red;
                    }
                    if (textBox1.Text.IsNullOrEmpty() || registrationPasswordTextbox.Text.IsNullOrEmpty())
                    {
                        attentionLoginPasswordEqual.Text = "Заполните все поля";
                        attentionLoginPasswordEqual.Visible = true; attentionLoginPasswordEqual.ForeColor = Color.Red;
                    }
                    else if (userCount < 1 && textBox1.Text.Trim() != registrationPasswordTextbox.Text.Trim())
                    {
                        using (SqlCommand insertCommand = new SqlCommand(registrationInsertUser, connectionString))
                        {
                            insertCommand.Parameters.AddWithValue("@Login", login);
                            insertCommand.Parameters.AddWithValue("@Password", hashedPassword);
                            insertCommand.ExecuteNonQuery();
                        }
                        attentionLoginPasswordEqual.Text = "Успешная регистрация"; attentionLoginPasswordEqual.ForeColor = Color.Green; attentionLoginPasswordEqual.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}");
            }
            finally
            {
                connectionString.Close();
            }
        }

        private void registrationCreateAccountButton_MouseHover(object sender, EventArgs e)
        {
            registrationCreateAccountButton.BackColor = Color.RoyalBlue;
            registrationCreateAccountButton.ForeColor = Color.White;
        }

        private void registrationCreateAccountButton_MouseHoverLeave(object sender, EventArgs e)
        {
            registrationCreateAccountButton.BackColor = Color.White;
            registrationCreateAccountButton.ForeColor = Color.Black;
        }

        private void registrationAuthorizeTextLabel_Click(object sender, EventArgs e)
        {
            AuthorizeForm authorizeForm = new AuthorizeForm();
            this.Hide();
            authorizeForm.FormClosed += (sender, e) => this.Close();
            authorizeForm.ShowDialog();
        }
       
    }
}
