using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UP_4191_25
{
    public partial class request_edit : Form
    {
        string connectionString = @"Data Source=ADCLG1;Initial Catalog=_УП_4191_25;Integrated Security=True";
        Color main_color = Color.FromArgb(163, 187, 200);
        Color other_color = Color.FromArgb(39, 52, 61);
        Color accent_color = Color.FromArgb(222, 146, 146);
        Color dark_accent_color = Color.FromArgb(109, 50, 50);
        string type;
        int id,idQ;
        public request_edit(string type, int id, int idQ)
        {
            InitializeComponent();
            this.BackColor = main_color;
            this.ForeColor = other_color;
            panel1.BackColor = main_color;
            textBox1.BackColor = other_color;
            textBox3.BackColor = other_color;
            button1.BackColor = accent_color;
            button1.ForeColor = dark_accent_color;
            maskedTextBox1.ForeColor = other_color;
            string sql;
            this.type = type;
            this.id = id;
            this.idQ = idQ;
            if (type == "заказчик")
            {
                panel1.Visible = true;
                panel2.Visible = false;
                panel3.Visible = false;
                panel1.Location = new Point(12, 12);
                try
                {
                    sql = $"SELECT modelName as Name FROM climateTechModel";
                    SqlConnection MyConnection = new SqlConnection(connectionString);
                    MyConnection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, MyConnection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    MyConnection.Close();
                    DataRow row = dt.NewRow();
                    comboBox1.DataSource = dt;
                    comboBox1.DisplayMember = "Name";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                try
                {
                    sql = $"SELECT problemlName as Name FROM problemDescryption";
                    SqlConnection MyConnection = new SqlConnection(connectionString);
                    MyConnection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, MyConnection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    MyConnection.Close();
                    DataRow row = dt.NewRow();
                    comboBox2.DataSource = dt;
                    comboBox2.DisplayMember = "Name";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (type == "специалист")
            {
                panel1.Visible = false;
                panel2.Visible = false;
                panel3.Visible = true;
                panel3.Location = new Point(50, 12);
                
                try
                {
                    sql = $"SELECT statuslName as Name FROM requestStatus";
                    SqlConnection MyConnection = new SqlConnection(connectionString);
                    MyConnection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, MyConnection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    MyConnection.Close();
                    DataRow row = dt.NewRow();
                    comboBox5.DataSource = dt;
                    comboBox5.DisplayMember = "Name";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (type == "оператор")
            {
                panel1.Visible = false;
                panel2.Visible = true;
                panel3.Visible = false;
                panel2.Location = new Point(50, 40);
                try
                {
                    sql = "SELECT fio as Name FROM inputDateUsers where _type = 3";
                    SqlConnection MyConnection = new SqlConnection(connectionString);
                    MyConnection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, MyConnection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    MyConnection.Close();
                    DataRow row = dt.NewRow();
                    comboBox4.DataSource = dt;
                    comboBox4.DisplayMember = "Name";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                try
                {
                    sql = $"SELECT statuslName as Name FROM requestStatus";
                    SqlConnection MyConnection = new SqlConnection(connectionString);
                    MyConnection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, MyConnection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    MyConnection.Close();
                    DataRow row = dt.NewRow();
                    comboBox3.DataSource = dt;
                    comboBox3.DisplayMember = "Name";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                panel1.Visible = false;
                panel2.Visible = false;
                panel3.Visible = false;
                panel4.Location = new Point(50, 40);
                try
                {
                    sql = "SELECT fio as Name FROM inputDateUsers where _type = 3";
                    SqlConnection MyConnection = new SqlConnection(connectionString);
                    MyConnection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, MyConnection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    MyConnection.Close();
                    DataRow row = dt.NewRow();
                    comboBox7.DataSource = dt;
                    comboBox7.DisplayMember = "Name";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Вы уверены, что хотите изменить данные?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                MessageBox.Show("Изменение отменено.", "Отмена", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string query="";            
            if (type == "заказчик")
            {
                int modelID=0, problemID=0;
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
                                modelID = reader.GetInt32(0);
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
                                problemID = reader.GetInt32(0);
                            }
                        }

                    }
                    query = $"UPDATE inputDateRequests SET ClimateTechModel=@ClimateTechModel, problemDescryption=@ProblemDescription  WHERE requestID = {idQ}";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand command = new SqlCommand(query, connection);

                        command.Parameters.AddWithValue("@ClimateTechModel", modelID);
                        command.Parameters.AddWithValue("@ProblemDescription", problemID);

                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Запрос успешно изменен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }               
            }
            else if (type == "оператор")
            {
                int masterID = 0, StatusID = 0;
                try
                {
                    string sql = $"select userID from inputDateUsers where fio = '{comboBox4.Text}'";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand command = new SqlCommand(sql, connection);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                masterID = reader.GetInt32(0);
                            }
                        }

                    }
                    sql = $"select statusID from requestStatus where statuslName = '{comboBox3.Text}'";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand command = new SqlCommand(sql, connection);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                StatusID = reader.GetInt32(0);
                            }
                        }

                    }
                    query = $"UPDATE inputDateRequests SET requestStatus=@requestStatus, masterID=@masterID  WHERE requestID = {idQ}";
                    if (comboBox3.Text == "Готова к выдаче")
                    {
                        query = $"UPDATE inputDateRequests SET requestStatus=@requestStatus, masterID=@masterID, completionDate='{DateTime.Now.ToString("yyyy-MM-dd")}' WHERE requestID = {idQ}";
                    }
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand command = new SqlCommand(query, connection);

                        command.Parameters.AddWithValue("@requestStatus", StatusID);
                        command.Parameters.AddWithValue("@masterID", masterID);

                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Запрос успешно изменен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (type == "специалист")
            {
                int StatusID = 0;

                try
                {
                    
                    string sql = $"select statusID from requestStatus where statuslName = '{comboBox5.Text}'";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand command = new SqlCommand(sql, connection);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                StatusID = reader.GetInt32(0);
                            }
                        }

                    }
                    query = $"UPDATE inputDateRequests SET requestStatus=@requestStatus,repairParts=@repairParts WHERE requestID = {idQ}";
                    if (comboBox5.Text== "Готова к выдаче")
                    {
                        query = $"UPDATE inputDateRequests SET requestStatus=@requestStatus, repairParts=@repairParts, completionDate='{DateTime.Now.ToString("yyyy-MM-dd")}' WHERE requestID = {idQ}";
                    }
                    
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand command = new SqlCommand(query, connection);

                        command.Parameters.AddWithValue("@requestStatus", StatusID);
                        command.Parameters.AddWithValue("@repairParts", textBox1.Text);

                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Запрос успешно изменен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    query = $"insert into inputDateComments(massege,masterID,requestID)VALUES('{textBox3}',{id},{idQ})";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                int masterID = 0;
                string newDate = "false";
                try
                {
                    string sql = $"select userID from inputDateUsers where fio = '{comboBox7.Text}'";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand command = new SqlCommand(sql, connection);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                masterID = reader.GetInt32(0);
                            }
                        }

                    }
                    sql = $"select 'true' from inputDateRequests where requestID = {idQ} and completionDate < '{maskedTextBox1.Text}' union select 'false' from inputDateRequests where requestID = {idQ} and completionDate >= '{maskedTextBox1.Text}'";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand command = new SqlCommand(sql, connection);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                newDate = reader.GetString(0);
                            }
                        }

                    }
                    
                    query = $"UPDATE inputDateRequests SET masterID=@masterID WHERE requestID = {idQ}";
                    if (newDate=="true")
                    {
                        query = $"UPDATE inputDateRequests SET masterID=@masterID, completionDate='{maskedTextBox1.Text}' WHERE requestID = {idQ}";
                    }
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand command = new SqlCommand(query, connection);

                        command.Parameters.AddWithValue("@masterID", masterID);

                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Запрос успешно изменен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}
