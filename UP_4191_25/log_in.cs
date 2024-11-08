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
using QRCoder;
using System.IO;
using dbHelp;
using System.Drawing.Imaging;
//using UP_4191_25;

namespace UP_4191_25
{
    public partial class log_in : Form
    {
        private string text = String.Empty;
        Color main_color = Color.FromArgb(163, 187, 200);
        Color other_color = Color.FromArgb(39, 52, 61);
        Color accent_color = Color.FromArgb(222, 146, 146);
        Color dark_accent_color = Color.FromArgb(109, 50, 50);
        string connectionString = @"Data Source=ADCLG1;Initial Catalog=_УП_4191_25;Integrated Security=True";
        int k = 0, s = 59, m = 2;

        public log_in()
        {
            InitializeComponent();
            this.BackColor = main_color;
            panel1.BackColor = other_color;
            panel2.BackColor = other_color;
            panel3.BackColor = other_color;
            label6.ForeColor = other_color;
            textBox1.BackColor = other_color;
            textBox2.BackColor = other_color;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            button1.BackColor = accent_color;
            button1.ForeColor = dark_accent_color;
            panel2.Location = new Point(192, 196);
            panel3.Location = new Point(192, 263);
            button1.Location = new Point(325, 341);
            button2.Visible = false;
            textBox3.Visible = false;
            button2.BackColor = accent_color;
            button2.ForeColor = dark_accent_color;
            textBox3.BackColor = other_color;
            pictureBox1.Visible = false;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == text)
            {
                MessageBox.Show("Капча введена верно! Вы поможете снова попытаться авторизироваться.", "сообщение о правильном вводе капчи", MessageBoxButtons.OK, MessageBoxIcon.Information);                
                panel2.Location = new Point(192, 216-20);
                panel3.Location = new Point(192, 283-20);
                button1.Location = new Point(325, 361 - 20);
                button2.Visible = false;
                textBox3.Visible = false;
                pictureBox1.Visible = false;
                textBox3.Text = "";
                if (k == 1)
                {
                    textBox1.Enabled = true;
                    textBox2.Enabled = true;
                    button1.Enabled = true;
                    button1.BackColor = accent_color;
                    button1.ForeColor = dark_accent_color;
                }
                else if (k == 2)
                {
                    s = 59; 
                    m = 2;
                    timer1.Start();
                }

            }
            else
            {
                MessageBox.Show("Капча введена не верно. Попробуйте снова.", "сообщение о неправильном вводе капчи", MessageBoxButtons.OK, MessageBoxIcon.Information);
                pictureBox1.Image = CAPTCHA.CreateImage(pictureBox1.Width, pictureBox1.Height, out text);
                textBox3.Text = "";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {            
            s = s - 1;
            if (s == -1)
            {
                if (m == 0)
                {
                    textBox1.Enabled = true;
                    textBox2.Enabled = true;
                    button1.Enabled = true;
                    button1.BackColor = accent_color;
                    button1.ForeColor = dark_accent_color;
                    timer1.Stop();
                }
                else
                {
                    m = m - 1;
                    s = 59;
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.PasswordChar = '\0';
            }
            else
            {
                textBox2.PasswordChar = '*';
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            try
            {
                string login=textBox1.Text, password= textBox2.Text, fio="";
                int ID=0, type=0;
                bool result= false;

                string query = "SELECT COUNT(*), _password,fio,_type,userID FROM inputDateUsers WHERE _login = @Login group by _login,_password,fio,_type,userID";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Login", login);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int count = reader.GetInt32(0);
                            if (count == 0)
                            {
                                result = false;
                            }
                            else
                            {
                                string storedPassword = reader.GetString(1).Trim();
                                result = storedPassword == password; 
                                fio = reader.GetString(2).Trim();
                                type = reader.GetInt32(3);
                                ID = reader.GetInt32(4);
                            }
                        }
                    }

                }

                if (result)
                {
                    query = $"INSERT INTO logInHistory (logInData, _login, isSuccess) VALUES ('{DateTime.Now.ToString("yyyy-MM-dd")}','{login}',1)";
                    
                    string typeName="";
                    switch (type)
                    { 
                        case 1: typeName = "заказчик"; 
                            break;
                        case 2:
                            typeName = "оператор";
                            break;
                        case 3:
                            typeName = "специалист";
                            break;
                        case 4:
                            typeName = "менеджер";
                            break;

                    }
                    new user_main(ID,fio,typeName).Show();
                    this.Hide();
                }
                else
                {
                    query = $"INSERT INTO logInHistory (logInData, _login, isSuccess) VALUES ('{DateTime.Now.ToString("yyyy-MM-dd")}','{login}',0)";
                    k++;
                    if (k > 2) 
                    {
                        MessageBox.Show("Привышен лимит попыток авторизации. Перезапустите приложение и попробуйте снова.", "сообщение о привышении лимита попыток авторизации", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox1.Enabled = false;
                        textBox2.Enabled = false;
                        button1.Enabled = false;
                        button1.BackColor = other_color;
                        button1.ForeColor = Color.White;
                    }
                    else
                    {
                        MessageBox.Show("Введен не верный логин или пароль. Введите капчу для получения новой попытки", "сообщение о неуспешной авторизации", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox1.Enabled = false;
                        textBox2.Enabled = false;
                        button1.Enabled = false;
                        panel2.Location = new Point(33, 216 - 20);
                        panel3.Location = new Point(33, 283 - 20);
                        button1.Location = new Point(166, 361 - 20);
                        button2.Visible = true;
                        textBox3.Visible = true;
                        pictureBox1.Visible = true;
                        button1.BackColor = other_color;
                        button1.ForeColor = Color.White;
                        pictureBox1.Image = CAPTCHA.CreateImage(pictureBox1.Width, pictureBox1.Height, out text);
                    }
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        
    }
}
