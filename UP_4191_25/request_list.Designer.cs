﻿namespace UP_4191_25
{
    partial class request_list
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(request_list));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.AppWorkspace;
            this.dataGridView1.Location = new System.Drawing.Point(15, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(810, 426);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("NSimSun", 16.25F, System.Drawing.FontStyle.Underline);
            this.label6.Location = new System.Drawing.Point(853, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(230, 22);
            this.label6.TabIndex = 16;
            this.label6.Text = "фильтрация";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.comboBox2);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Location = new System.Drawing.Point(844, 69);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(252, 192);
            this.panel1.TabIndex = 17;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("NSimSun", 14.25F);
            this.button2.Location = new System.Drawing.Point(13, 137);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(226, 37);
            this.button2.TabIndex = 18;
            this.button2.Text = "ФИЛЬТРОВАТЬ";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.Font = new System.Drawing.Font("Segoe UI Light", 14.25F);
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(24, 67);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(201, 33);
            this.comboBox2.TabIndex = 1;
            this.comboBox2.Text = "Значение";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Segoe UI Light", 14.25F);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "дата создания",
            "модель",
            "причина обращения",
            "статус",
            "дата завершения",
            "запчасти"});
            this.comboBox1.Location = new System.Drawing.Point(24, 15);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(201, 33);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.Text = "Фильтровать по";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("NSimSun", 12.25F);
            this.button1.Location = new System.Drawing.Point(12, 444);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(559, 38);
            this.button1.TabIndex = 19;
            this.button1.Text = "РЕДАКТИРОВАТЬ ВЫБРАННУЮ ЗАЯВКУ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("NSimSun", 10.25F, System.Drawing.FontStyle.Underline);
            this.label1.Location = new System.Drawing.Point(848, 278);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 14);
            this.label1.TabIndex = 20;
            this.label1.Text = "количество заявок:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("NSimSun", 16.25F);
            this.label2.Location = new System.Drawing.Point(949, 312);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 22);
            this.label2.TabIndex = 21;
            this.label2.Text = "0/0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("NSimSun", 16.25F);
            this.label3.Location = new System.Drawing.Point(960, 395);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 22);
            this.label3.TabIndex = 22;
            this.label3.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("NSimSun", 10.25F, System.Drawing.FontStyle.Underline);
            this.label4.Location = new System.Drawing.Point(873, 372);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(196, 14);
            this.label4.TabIndex = 23;
            this.label4.Text = "Выбрана заявка";
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("NSimSun", 12.25F);
            this.button3.Location = new System.Drawing.Point(632, 444);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(473, 38);
            this.button3.TabIndex = 24;
            this.button3.Text = "УДАЛИТЬ ВЫБРАННУЮ ЗАЯВКУ";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // request_list
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1117, 495);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dataGridView1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "request_list";
            this.Text = "          список заявок";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button3;
    }
}