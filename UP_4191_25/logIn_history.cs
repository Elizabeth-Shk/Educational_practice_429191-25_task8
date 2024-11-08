using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UP_4191_25
{
    public partial class logIn_history : Form
    {
        Color main_color = Color.FromArgb(163, 187, 200);
        Color other_color = Color.FromArgb(39, 52, 61);
        Color accent_color = Color.FromArgb(222, 146, 146);
        Color dark_accent_color = Color.FromArgb(109, 50, 50);
        string connectionString = @"Data Source=ADCLG1;Initial Catalog=_УП_4191_25;Integrated Security=True";
        string query = $"SELECT logInData, _login, isSuccess FROM logInHistory";
        public logIn_history()
        {
            InitializeComponent();
            this.BackColor = main_color;
            this.ForeColor = other_color;
            panel1.BackColor = other_color;
            panel2.BackColor = other_color;
            textBox3.BackColor = main_color;
            textBox3.Text = "";
            button2.BackColor = main_color;
            button1.BackColor = main_color;
            dataGridView1.BackgroundColor = main_color;
            dataGridView1.GridColor = other_color;
            dataGridView1.RowsDefaultCellStyle.BackColor = main_color;
            dataGridView1.RowsDefaultCellStyle.ForeColor = other_color;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = other_color;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = main_color;
            
            try
            {
                SqlConnection MyConnection = new SqlConnection(connectionString);
                MyConnection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, MyConnection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                MyConnection.Close();
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns["logInData"].HeaderText = "дата входа";
                dataGridView1.Columns["_login"].HeaderText = "логин";
                dataGridView1.Columns["isSuccess"].HeaderText = "успешен ли вход";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                query = $"SELECT logInData, _login, isSuccess FROM logInHistory where _login='{textBox3.Text}'";
            }
            else
            {
                query = $"SELECT logInData, _login, isSuccess FROM logInHistory";
            }

            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                connection.Close();
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns["logInData"].HeaderText = "дата входа";
                dataGridView1.Columns["_login"].HeaderText = "логин";
                dataGridView1.Columns["isSuccess"].HeaderText = "успешен ли вход";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = this.query, SQuery = "";
            if (query == "")
            {
                SQuery = query + "ORDER BY logInData DESC";
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(SQuery, connection);
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                connection.Close();
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns["logInData"].HeaderText = "дата входа";
                dataGridView1.Columns["_login"].HeaderText = "логин";
                dataGridView1.Columns["isSuccess"].HeaderText = "успешен ли вход";
            }
            else 
            {
                SQuery = "";
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                connection.Close();
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns["logInData"].HeaderText = "дата входа";
                dataGridView1.Columns["_login"].HeaderText = "логин";
                dataGridView1.Columns["isSuccess"].HeaderText = "успешен ли вход";
            }
        }
    }
}
