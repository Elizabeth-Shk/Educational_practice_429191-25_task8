using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UP_4191_25
{
    public partial class request_list : Form
    {
        Color main_color = Color.FromArgb(163, 187, 200);
        Color other_color = Color.FromArgb(39, 52, 61);
        Color accent_color = Color.FromArgb(222, 146, 146);
        Color dark_accent_color = Color.FromArgb(109, 50, 50);
        string _type;
        int id, countRows;
        string name;
        string connectionString = @"Data Source=ADCLG1;Initial Catalog=_УП_4191_25;Integrated Security=True";
        public request_list(string type, int id)
        {
            InitializeComponent();
            this.BackColor = main_color;
            this.ForeColor = other_color;
            panel1.BackColor = other_color;
            comboBox1.BackColor = main_color;
            comboBox1.ForeColor = other_color;
            comboBox2.BackColor = main_color;
            comboBox2.ForeColor = other_color;
            button2.BackColor = main_color;
            button1.BackColor = accent_color;
            button1.ForeColor = dark_accent_color;
            button3.BackColor = accent_color;
            button3.ForeColor = dark_accent_color;
            dataGridView1.BackgroundColor = main_color;
            dataGridView1.GridColor = other_color;
            dataGridView1.RowsDefaultCellStyle.BackColor = main_color;
            dataGridView1.RowsDefaultCellStyle.ForeColor = other_color;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = other_color;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = main_color;
            label2.Text = "0/" + dataGridView1.RowCount;
            _type = type;
            this.id = id;
            if (type == "заказчик")
            {
                string query = $"SELECT requestID, startDate, modelName, problemlName, statuslName, completionDate, repairParts, fio  FROM inputDateRequests LEFT JOIN inputDateUsers on masterID=userID, climateTechModel,problemDescryption,requestStatus where clientID={id} and climateTechModel=modelID and problemDescryption=problemID and requestStatus=statusID;";
                try
                {
                    SqlConnection MyConnection = new SqlConnection(connectionString);
                    MyConnection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, MyConnection);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    MyConnection.Close();
                    dataGridView1.DataSource = ds.Tables[0];
                    dataGridView1.Columns["requestID"].HeaderText = "ID";
                    dataGridView1.Columns["startDate"].HeaderText = "дата создания";
                    dataGridView1.Columns["modelName"].HeaderText = "модель";
                    dataGridView1.Columns["problemlName"].HeaderText = "причина обращения";
                    dataGridView1.Columns["statuslName"].HeaderText = "статус";
                    dataGridView1.Columns["completionDate"].HeaderText = "дата завершения";
                    dataGridView1.Columns["repairParts"].HeaderText = "запчасти";
                    dataGridView1.Columns["fio"].HeaderText = "специалист";
                    countRows = dataGridView1.Rows.Count - 1;
                    label2.Text = countRows.ToString() + "/" + countRows.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (type == "специалист")
            {
                string query = $"SELECT requestID, startDate, modelName, problemlName, statuslName, completionDate, repairParts, fio  FROM inputDateRequests LEFT JOIN inputDateUsers on clientID=userID, climateTechModel,problemDescryption,requestStatus where masterID={id} and climateTechModel=modelID and problemDescryption=problemID and requestStatus=statusID;";
                try
                {
                    SqlConnection MyConnection = new SqlConnection(connectionString);
                    MyConnection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, MyConnection);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    MyConnection.Close();
                    dataGridView1.DataSource = ds.Tables[0];
                    dataGridView1.Columns["requestID"].HeaderText = "ID";
                    dataGridView1.Columns["startDate"].HeaderText = "дата создания";
                    dataGridView1.Columns["modelName"].HeaderText = "модель";
                    dataGridView1.Columns["problemlName"].HeaderText = "причина обращения";
                    dataGridView1.Columns["statuslName"].HeaderText = "статус";
                    dataGridView1.Columns["completionDate"].HeaderText = "дата завершения";
                    dataGridView1.Columns["repairParts"].HeaderText = "запчасти";
                    dataGridView1.Columns["fio"].HeaderText = "заказчик";
                    countRows = dataGridView1.Rows.Count - 1;
                    label2.Text = countRows.ToString() + "/" + countRows.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (type == "оператор" || type== "менеджер")
            {
                string query = $"SELECT requestID, startDate, modelName, problemlName, statuslName, completionDate, repairParts, _master.fio as _master, client.fio as client  FROM inputDateRequests LEFT JOIN inputDateUsers as client on clientID=userID LEFT JOIN inputDateUsers as _master on inputDateRequests.masterID=_master.userID, climateTechModel,problemDescryption,requestStatus where climateTechModel=modelID and problemDescryption=problemID and requestStatus=statusID;";
                try
                {
                    SqlConnection MyConnection = new SqlConnection(connectionString);
                    MyConnection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, MyConnection);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    MyConnection.Close();
                    dataGridView1.DataSource = ds.Tables[0];
                    dataGridView1.Columns["requestID"].HeaderText = "ID";
                    dataGridView1.Columns["startDate"].HeaderText = "дата создания";
                    dataGridView1.Columns["modelName"].HeaderText = "модель";
                    dataGridView1.Columns["problemlName"].HeaderText = "причина обращения";
                    dataGridView1.Columns["statuslName"].HeaderText = "статус";
                    dataGridView1.Columns["completionDate"].HeaderText = "дата завершения";
                    dataGridView1.Columns["repairParts"].HeaderText = "запчасти";
                    dataGridView1.Columns["_master"].HeaderText = "специалист";
                    dataGridView1.Columns["client"].HeaderText = "заказчик";
                    countRows = dataGridView1.Rows.Count - 1;
                    label2.Text = countRows.ToString() + "/" + countRows.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }                  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new request_edit(_type, id, Convert.ToInt32(label3.Text)).ShowDialog();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            string sql="";

            switch (comboBox1.Text) {
                case "дата создания": name = "startDate"; sql = $"SELECT startDate as Name FROM inputDateRequests"; break;
                case "модель": name = "climateTechModel"; sql = $"SELECT modelName as Name FROM climateTechModel";  break;
                case "причина обращения": name = "problemDescryption"; sql = $"SELECT problemlName as Name FROM problemDescryption";  break;
                case "статус": name = "requestStatus"; sql = $"SELECT statuslName as Name FROM requestStatus";  break;
                case "дата завершения": name = "completionDate"; sql = $"SELECT completionDate as Name FROM inputDateRequests";  break;
                case "запчасти": name = "repairParts"; sql = $"SELECT repairParts as Name FROM inputDateRequests";  break;
            }
            try
            {
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

        private void button2_Click(object sender, EventArgs e)
        {
            string sql="";
            if (_type == "заказчик")
            {
                sql = $"SELECT requestID, startDate, modelName, problemlName, statuslName, completionDate, repairParts, fio  FROM inputDateRequests LEFT JOIN inputDateUsers on masterID=userID, climateTechModel,problemDescryption,requestStatus where clientID={id} and";
            }
            else if (_type == "специалист" || _type== "менеджер")
            {
                sql = $"SELECT requestID, startDate, modelName, problemlName, statuslName, completionDate, repairParts, fio  FROM inputDateRequests LEFT JOIN inputDateUsers on clientID=userID, climateTechModel,problemDescryption,requestStatus where masterID={id} and";
            }
            else if (_type == "оператор")
            {
                sql = $"SELECT requestID, startDate, modelName, problemlName, statuslName, completionDate, repairParts, _master.fio as _master, client.fio as client  FROM inputDateRequests LEFT JOIN inputDateUsers as client on clientID=userID LEFT JOIN inputDateUsers as _master on inputDateRequests.masterID=_master.userID, climateTechModel,problemDescryption,requestStatus where ";
            }
           
            switch (name)
            {
                case "startDate": sql = sql + $" startDate='{comboBox2.Text}' and climateTechModel=modelID and problemDescryption=problemID and requestStatus=statusID;"; break;
                case "climateTechModel": sql = sql + $" modelName ='{comboBox2.Text}' and climateTechModel=modelID and problemDescryption=problemID and requestStatus=statusID;"; break;
                case "problemDescryption": sql = sql + $" problemlName ='{comboBox2.Text}' and climateTechModel=modelID and problemDescryption=problemID and requestStatus=statusID;"; break;
                case "requestStatus": sql = sql + $" statuslName ='{comboBox2.Text}' and climateTechModel=modelID and problemDescryption=problemID and requestStatus=statusID;"; break;
                case "completionDate": sql = sql + $" completionDate ='{comboBox2.Text}' and climateTechModel=modelID and problemDescryption=problemID and requestStatus=statusID;"; break;
                case "repairParts": sql = sql + $" repairParts ='{comboBox2.Text}' and climateTechModel=modelID and problemDescryption=problemID and requestStatus=statusID;"; break;
            }
            if (comboBox2.Text == "") 
            {
                if (_type == "заказчик")
                {
                    sql = $"SELECT requestID, startDate, modelName, problemlName, statuslName, completionDate, repairParts, fio  FROM inputDateRequests LEFT JOIN inputDateUsers on masterID=userID, climateTechModel,problemDescryption,requestStatus where clientID={id} and climateTechModel=modelID and problemDescryption=problemID and requestStatus=statusID;";
                }
                else if (_type == "специалист")
                {
                    sql = $"SELECT requestID, startDate, modelName, problemlName, statuslName, completionDate, repairParts, fio  FROM inputDateRequests LEFT JOIN inputDateUsers on clientID=userID, climateTechModel,problemDescryption,requestStatus where masterID={id} and climateTechModel=modelID and problemDescryption=problemID and requestStatus=statusID;";
                }
                else if (_type == "оператор" || _type == "менеджер")
                {
                    sql = $"SELECT requestID, startDate, modelName, problemlName, statuslName, completionDate, repairParts, _master.fio as _master, client.fio as client  FROM inputDateRequests LEFT JOIN inputDateUsers as client on clientID=userID LEFT JOIN inputDateUsers as _master on inputDateRequests.masterID=_master.userID, climateTechModel,problemDescryption,requestStatus where climateTechModel=modelID and problemDescryption=problemID and requestStatus=statusID;";
                }
            }
            try
            {
                SqlConnection MyConnection = new SqlConnection(connectionString);
                MyConnection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, MyConnection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                MyConnection.Close();
                if (_type == "заказчик")
                {
                    dataGridView1.DataSource = ds.Tables[0];
                    dataGridView1.Columns["requestID"].HeaderText = "ID";
                    dataGridView1.Columns["startDate"].HeaderText = "дата создания";
                    dataGridView1.Columns["modelName"].HeaderText = "модель";
                    dataGridView1.Columns["problemlName"].HeaderText = "причина обращения";
                    dataGridView1.Columns["statuslName"].HeaderText = "статус";
                    dataGridView1.Columns["completionDate"].HeaderText = "дата завершения";
                    dataGridView1.Columns["repairParts"].HeaderText = "запчасти";
                    dataGridView1.Columns["fio"].HeaderText = "специалист";
                }
                else if (_type == "специалист")
                {
                    dataGridView1.DataSource = ds.Tables[0];
                    dataGridView1.Columns["requestID"].HeaderText = "ID";
                    dataGridView1.Columns["startDate"].HeaderText = "дата создания";
                    dataGridView1.Columns["modelName"].HeaderText = "модель";
                    dataGridView1.Columns["problemlName"].HeaderText = "причина обращения";
                    dataGridView1.Columns["statuslName"].HeaderText = "статус";
                    dataGridView1.Columns["completionDate"].HeaderText = "дата завершения";
                    dataGridView1.Columns["repairParts"].HeaderText = "запчасти";
                    dataGridView1.Columns["fio"].HeaderText = "заказчик";
                }
                else if (_type == "оператор" || _type== "менеджер")
                {
                    dataGridView1.DataSource = ds.Tables[0];
                    dataGridView1.Columns["requestID"].HeaderText = "ID";
                    dataGridView1.Columns["startDate"].HeaderText = "дата создания";
                    dataGridView1.Columns["modelName"].HeaderText = "модель";
                    dataGridView1.Columns["problemlName"].HeaderText = "причина обращения";
                    dataGridView1.Columns["statuslName"].HeaderText = "статус";
                    dataGridView1.Columns["completionDate"].HeaderText = "дата завершения";
                    dataGridView1.Columns["repairParts"].HeaderText = "запчасти";
                    dataGridView1.Columns["_master"].HeaderText = "специалист";
                    dataGridView1.Columns["client"].HeaderText = "заказчик";
                }
                
                label2.Text = (dataGridView1.Rows.Count -1).ToString() + "/" + countRows.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            label3.Text= dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Вы действительно хотите удалить заявку?", "Подтверждение удаления", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (res == DialogResult.OK)
            {

                MessageBox.Show("удаление прошло успешно");
                string query = "DELETE FROM inputDateRequests WHERE requestID = @RequestID";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@RequestID", Convert.ToInt32(label3.Text));

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Запрос успешно удалён.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            if (res == DialogResult.Cancel)
            {
                MessageBox.Show("удаление отменено", "Отмена", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }          
        }        
    }
}
