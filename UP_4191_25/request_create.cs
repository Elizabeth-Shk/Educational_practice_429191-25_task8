using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UP_4191_25
{
    public partial class request_create : Form
    {
        Color main_color = Color.FromArgb(163, 187, 200);
        Color other_color = Color.FromArgb(39, 52, 61);
        Color accent_color = Color.FromArgb(222, 146, 146);
        Color dark_accent_color = Color.FromArgb(109, 50, 50);
        string connectionString = @"Data Source=ADCLG1;Initial Catalog=_УП_4191_25;Integrated Security=True";
        int id;
        public request_create(int ID)
        {
            InitializeComponent();
            this.BackColor = main_color;
            this.ForeColor = other_color;
            comboBox1.BackColor = main_color;
            comboBox1.ForeColor = other_color;
            comboBox2.BackColor = main_color;
            comboBox2.ForeColor = other_color;
            button2.BackColor = accent_color;
            button2.ForeColor = dark_accent_color;
            id = ID;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int tipeID = 0;
            if (comboBox1.Text != "" && comboBox1.Text != "Выбор модели оборудования")
            {
                string sql = $"select _type from climateTechModel where modelName = '{comboBox1.Text}'";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(sql, connection);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            tipeID = reader.GetInt32(0);
                        }
                    }

                }
                sql = $"select typeName from climateTechType where typeID={tipeID}";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(sql, connection);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            label8.Text = reader.GetString(0); 
                        }
                    }

                }
            }
            else 
            {
                label8.Text = "_______________________________________________________";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int climateTechModel=0, problemDescription =0;
            try
            {
                string sql = $"select modelID from climateTechModel where modelName = '{comboBox1.Text}'";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(sql, connection);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            climateTechModel = reader.GetInt32(0);
                        }
                    }

                }
                sql = $"select problemID from problemDescryption where problemlName = '{comboBox2.Text}'";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(sql, connection);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            problemDescription = reader.GetInt32(0);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            string query = "INSERT INTO inputDateRequests (startDate, climateTechModel, problemDescryption, requestStatus, clientID) " +
                       $"VALUES ('{DateTime.Now.ToString("yyyy-MM-dd")}', @ClimateTechModel, @ProblemDescription, 1, {id})";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@ClimateTechModel", climateTechModel);
                command.Parameters.AddWithValue("@ProblemDescription", problemDescription);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Запрос успешно добавлен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
