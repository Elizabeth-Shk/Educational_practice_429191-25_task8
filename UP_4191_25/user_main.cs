using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UP_4191_25
{
    public partial class user_main : Form
    {
        Color main_color = Color.FromArgb(163, 187, 200);
        Color other_color = Color.FromArgb(39, 52, 61);
        Color accent_color = Color.FromArgb(222, 146, 146);
        Color dark_accent_color = Color.FromArgb(109, 50, 50);
        string _type;
        int id;
        public user_main(int ID, string fio, string type)
        {
            InitializeComponent();
            this.BackColor = main_color;
            this.ForeColor = Color.White;
            label6.ForeColor = other_color;
            panel1.BackColor = other_color;
            button1.BackColor = other_color;
            button2.BackColor = accent_color;
            button2.ForeColor = dark_accent_color;
            button5.BackColor = accent_color;
            button5.ForeColor = dark_accent_color;
            string[] list = fio.Split(' ');
            label7.Text=list[0];
            label8.Text = list[1];
            label9.Text = type;
            _type = type;
            id = ID;
            if (type == "заказчик")
            {
                button1.Visible = true;
                button2.Visible = true;
                button1.Location = new Point(332, 49);
                button2.Location = new Point(332, 150);
            }
            //else if (type == "оператор")
            //{
            //    button1.Visible = true;
            //    button2.Visible = false;
            //    button1.Location = new Point(332, 161);
            //}
            //else if (type == "специалист")
            //{
            //    button1.Visible = true;
            //    button2.Visible = false;
            //    button1.Location = new Point(332, 161);
            //}
            else 
            {
                button1.Visible = true;
                button2.Visible = false;
                button1.Location = new Point(332, 150);
            }
            string qrtext = "https://owen-prom.ru";
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrtext, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            using (Bitmap bitMap = qrCode.GetGraphic(4))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    bitMap.Save(ms, ImageFormat.Png);
                    pictureBox2.Image = Image.FromStream(ms);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new request_list(_type,id).ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new request_create(id).ShowDialog();
        }

        private void user_main_FormClosed(object sender, FormClosedEventArgs e)
        {
            new log_in().Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new logIn_history().ShowDialog();
        }

    }
}
