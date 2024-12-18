using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class mainScreenForm : Form
    {
        private string userName;
        private int userId;
        private SqlConnection connection;

        public mainScreenForm(string userName)
        {
            InitializeComponent();
            this.userName = userName;
            this.StartPosition = FormStartPosition.CenterScreen;
            DisplayGreetings();
            connection = new SqlConnection("Server=LocalHost;Database=CarParkManager;Integrated Security=True;Trust Server Certificate=True;");
            userId = GetUserId(userName);
            LoadTables();

            if (userName == "Admin")
            {
                adminButton.Enabled = true;
                adminButton.Visible = true;
            }
        }

         private int GetUserId(string username)
         {
            int id = -1;
            string query = "SELECT Id FROM Users WHERE Login = @Login";

            try
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Login", username);
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        id = Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }

            return id;
         }

        private void LoadTables()
        {
            tablesComboBox.Items.Add("Vehicles");
            tablesComboBox.Items.Add("Services");
            tablesComboBox.Items.Add("MaintenanceRecords");
            tablesComboBox.Items.Add("InsurancePolicies");
            tablesComboBox.SelectedIndex = 0;

            LoadOrderByOptions();
        }

        private void activateButton_Click(object sender, EventArgs e)
        {
            if (radioButtonCreate.Checked)
            {
                CreateRecord();
            }
            else if (radioButtonRead.Checked)
            {
                ReadRecords();
            }
            else if (radioButtonUpdate.Checked)
            {
                UpdateRecord();
            }
            else if (radioButtonDelete.Checked)
            {
                DeleteRecord();
            }
        }

        private void CreateRecord()
        {
            string table = tablesComboBox.SelectedItem.ToString();
            string query = "";

            switch (table)
            {
                case "Vehicles":
                    query = "INSERT INTO Vehicles (UserId, Make, Model, Year, LicensePlate) VALUES (@UserId, @Make, @Model, @Year, @LicensePlate)";
                    break;
                case "Services":
                    query = "INSERT INTO Services (UserId, ServiceName, ServiceDate, Cost) VALUES (@UserId, @ServiceName, @ServiceDate, @Cost)";
                    break;
                case "MaintenanceRecords":
                    query = "INSERT INTO MaintenanceRecords (VehicleId, MaintenanceDate, Description) VALUES (@VehicleId, @MaintenanceDate, @Description)";
                    break;
                case "InsurancePolicies":
                    query = "INSERT INTO InsurancePolicies (VehicleId, Provider, PolicyNumber, ExpiryDate) VALUES (@VehicleId, @Provider, @PolicyNumber, @ExpiryDate)";
                    break;
            }

            try
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SetParameters(command, table);
                    command.Parameters.AddWithValue("@UserId", userId);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Запись создана!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }

        private void LoadOrderByOptions()
        {
            orderByComboBox.Items.Add("Id");
            orderByComboBox.Items.Add("Make");
            orderByComboBox.Items.Add("Model");
            orderByComboBox.Items.Add("Year");
            orderByComboBox.Items.Add("ServiceName");
            orderByComboBox.Items.Add("ServiceDate");
            orderByComboBox.Items.Add("Cost");
            orderByComboBox.Items.Add("MaintenanceDate");
            orderByComboBox.Items.Add("Provider");
            orderByComboBox.Items.Add("PolicyNumber");
            orderByComboBox.SelectedIndex = 0;
        }

        private void ReadRecords()
        {
            string table = tablesComboBox.SelectedItem.ToString();
            string query = "";
            string orderBy = orderByComboBox.SelectedItem?.ToString() ?? "Id";
            int limit = 100;

            if (!int.TryParse(limitTextBox.Text, out limit) || limit <= 0)
            {
                limit = 100;
            }

            if (table == "InsurancePolicies" || table == "MaintenanceRecords")
            {
                query = $"SELECT TOP {limit} * FROM {table} WHERE VehicleId IN (SELECT Id FROM Vehicles WHERE UserId = @UserId)";
            }
            else
            {
                query = $"SELECT TOP {limit} * FROM {table} WHERE UserId = @UserId";
            }

            query += $" ORDER BY {orderBy}";

            try
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);

                    SqlDataReader reader = command.ExecuteReader();
                    var result = new StringBuilder();

                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            result.Append($"{reader[i]} ");
                        }
                        result.AppendLine();
                    }

                    forEntriesRichTextBox.Text = result.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }

        private void UpdateRecord()
        {
            string table = tablesComboBox.SelectedItem.ToString();
            string query = "";

            switch (table)
            {
                case "Vehicles":
                    query = "UPDATE Vehicles SET Make = @Make, Model = @Model, Year = @Year, LicensePlate = @LicensePlate WHERE Id = @Id AND UserId = @UserId";
                    break;
                case "Services":
                    query = "UPDATE Services SET ServiceName = @ServiceName, ServiceDate = @ServiceDate, Cost = @Cost WHERE Id = @Id AND UserId = @UserId";
                    break;
                case "MaintenanceRecords":
                    query = "UPDATE MaintenanceRecords SET MaintenanceDate = @MaintenanceDate, Description = @Description WHERE Id = @Id";
                    break;
                case "InsurancePolicies":
                    query = "UPDATE InsurancePolicies SET Provider = @Provider, PolicyNumber = @PolicyNumber, ExpiryDate = @ExpiryDate WHERE Id = @Id";
                    break;
            }

            try
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SetParameters(command, table); 
                    if (table == "Vehicles" || table == "Services")
                    {
                        command.Parameters.AddWithValue("@UserId", userId);
                    }
                    command.ExecuteNonQuery();
                    MessageBox.Show("Запись обновлена!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }

        private void DeleteRecord()
        {
            string table = tablesComboBox.SelectedItem.ToString();
            string query = $"DELETE FROM {table} WHERE Id = @Id";

            if (table != "MaintenanceRecords" && table != "InsurancePolicies")
            {
                query += " AND UserId = @UserId";
            }

            try
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", GetIdFromInput());
                    if (table != "MaintenanceRecords" && table != "InsurancePolicies")
                    {
                        command.Parameters.AddWithValue("@UserId", userId);
                    }
                    command.ExecuteNonQuery();
                    MessageBox.Show("Запись удалена!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }

        private void SetParameters(SqlCommand command, string table)
        {
            string userInput = forEntriesRichTextBox.Text;
            string[] parameters = userInput.Split(',');

            switch (table)
            {
                case "Vehicles":
                    if (parameters.Length != 5)
                    {
                        throw new ArgumentException("Неверный формат ввода для ваших люксовых машин. Ожидается 5 параметров.");
                    }
                    command.Parameters.AddWithValue("@Id", userId);
                    command.Parameters.AddWithValue("@Make", parameters[1].Trim());
                    command.Parameters.AddWithValue("@Model", parameters[2].Trim());
                    command.Parameters.AddWithValue("@Year", int.Parse(parameters[3].Trim()));
                    command.Parameters.AddWithValue("@LicensePlate", parameters[4].Trim());
                    break;

                case "Services":
                    if (parameters.Length != 4)
                    {
                        throw new ArgumentException("Неверный формат ввода для сервисных услуг. Ожидается 4 параметра.");
                    }
                    command.Parameters.AddWithValue("@Id", int.Parse(parameters[0].Trim()));
                    command.Parameters.AddWithValue("@ServiceName", parameters[1].Trim());
                    command.Parameters.AddWithValue("@ServiceDate", DateTime.Parse(parameters[2].Trim()));
                    command.Parameters.AddWithValue("@Cost", decimal.Parse(parameters[3].Trim()));
                    break;

                case "MaintenanceRecords":
                    if (parameters.Length != 3)
                    {
                        throw new ArgumentException("Неверный формат ввода для записей о техническом обслуживании. Ожидается 3 параметра.");
                    }
                    command.Parameters.AddWithValue("@Id", int.Parse(parameters[0].Trim()));
                    command.Parameters.AddWithValue("@MaintenanceDate", DateTime.Parse(parameters[1].Trim()));
                    command.Parameters.AddWithValue("@Description", parameters[2].Trim());
                    break;

                case "InsurancePolicies":
                    if (parameters.Length != 4)
                    {
                        throw new ArgumentException("Неверный формат ввода для страховой политике. Ожидается 4 параметра.");
                    }
                    command.Parameters.AddWithValue("@Id", int.Parse(parameters[0].Trim()));
                    command.Parameters.AddWithValue("@Provider", parameters[1].Trim());
                    command.Parameters.AddWithValue("@PolicyNumber", parameters[2].Trim());
                    command.Parameters.AddWithValue("@ExpiryDate", DateTime.Parse(parameters[3].Trim()));
                    break;
            }
        }

        private int GetIdFromInput()
        {
            string idInput = forEntriesRichTextBox.Text;
            string[] inputs = idInput.Split(',');
            return int.Parse(inputs[0].Trim());
        }

        private void setColorRadioButton()
        {
            RadioButton[] radioButtons = { radioButtonCreate, radioButtonRead, radioButtonUpdate, radioButtonDelete };
            foreach (var radioButton in radioButtons)
            {
                radioButton.ForeColor = radioButton.Checked ? Color.Green : Color.White;
            }
        }

        private void DisplayGreetings()
        {
            string greeting = GetGreetingMessage();
            greetingLabel.Text = $"{greeting}, {userName}.";
        }

        private string GetGreetingMessage()
        {
            var hour = DateTime.Now.Hour;
            if (hour < 12) return "Доброе утро";
            else if (hour < 18) return "Добрый день";
            else return "Добрый вечер";
        }

        private void radioButtonCreate_CheckedChanged(object sender, EventArgs e)
        {
            setColorRadioButton();
        }

        private void radioButtonRead_CheckedChanged(object sender, EventArgs e)
        {
            setColorRadioButton();
        }

        private void radioButtonUpdate_CheckedChanged(object sender, EventArgs e)
        {
            setColorRadioButton();
        }

        private void radioButtonDelete_CheckedChanged(object sender, EventArgs e)
        {
            setColorRadioButton();
        }

        private void adminButton_Click(object sender, EventArgs e)
        {
            GenerateRecordsForAllTables();
        }

        private void GenerateRecordsForAllTables()
        {
            try
            {
                connection.Open();
                List<int> vehicleIds = new List<int>();

                for (int i = 0; i < 1000; i++)
                {
                    int vehicleId = InsertRandomVehicle(i);
                    vehicleIds.Add(vehicleId);
                    InsertRandomService(i);
                }

                for (int i = 0; i < vehicleIds.Count; i++)
                {
                    InsertRandomMaintenanceRecord(vehicleIds[i], i);
                    InsertRandomInsurancePolicy(vehicleIds[i], i);
                }

                MessageBox.Show("1000 записей успешно сгенерино для каждой таблицы");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errorka: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }

        private int InsertRandomVehicle(int index)
        {
            string[] makes = { "Toyota", "Ford", "Chevrolet", "Honda", "Nissan", "BMW", "Volkswagen", "Hyundai", "Kia", "Subaru" };
            string[] models = { "Седан", "Внедорожник", "Хэтчбэк", "Пикап", "Купэ" };

            string query = "INSERT INTO Vehicles (UserId, Make, Model, Year, LicensePlate) VALUES (@UserId, @Make, @Model, @Year, @LicensePlate); SELECT SCOPE_IDENTITY();";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@UserId", userId);
                command.Parameters.AddWithValue("@Make", makes[new Random().Next(makes.Length)]);
                command.Parameters.AddWithValue("@Model", models[new Random().Next(models.Length)]);
                command.Parameters.AddWithValue("@Year", 2000 + (index % 20));
                command.Parameters.AddWithValue("@LicensePlate", "LP" + index);
                int vehicleId = Convert.ToInt32(command.ExecuteScalar());
                return vehicleId;
            }
        }

        private void InsertRandomService(int index)
        {
            string[] services = { "Смена масла", "Ремонт двигателя", "Ремонт шин", "Заправка", "Замена тормозов",
                          "Проверка трансмиссии", "Сигнализация", "Кузовной ремонт", "Покраска", "Чистка салона" };

            string query = "INSERT INTO Services (UserId, ServiceName, ServiceDate, Cost) VALUES (@UserId, @ServiceName, @ServiceDate, @Cost)";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@UserId", userId);
                command.Parameters.AddWithValue("@ServiceName", services[new Random().Next(services.Length)]);
                command.Parameters.AddWithValue("@ServiceDate", DateTime.Now.AddDays(-index));
                command.Parameters.AddWithValue("@Cost", 100 + index);
                command.ExecuteNonQuery();
            }
        }

        private void InsertRandomMaintenanceRecord(int vehicleId, int index)
        {
            string query = "INSERT INTO MaintenanceRecords (VehicleId, MaintenanceDate, Description) VALUES (@VehicleId, @MaintenanceDate, @Description)";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@VehicleId", vehicleId);
                command.Parameters.AddWithValue("@MaintenanceDate", DateTime.Now.AddDays(-index));
                command.Parameters.AddWithValue("@Description", "Maintenance record for Vehicle ID " + vehicleId);
                command.ExecuteNonQuery();
            }
        }

        private void InsertRandomInsurancePolicy(int vehicleId, int index)
        {
            string query = "INSERT INTO InsurancePolicies (VehicleId, Provider, PolicyNumber, ExpiryDate) VALUES (@VehicleId, @Provider, @PolicyNumber, @ExpiryDate)";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@VehicleId", vehicleId); 
                command.Parameters.AddWithValue("@Provider", "Provider" + index);
                command.Parameters.AddWithValue("@PolicyNumber", "PN" + index);
                command.Parameters.AddWithValue("@ExpiryDate", DateTime.Now.AddYears(1));
                command.ExecuteNonQuery();
            }
        }
    }
}