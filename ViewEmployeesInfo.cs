﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PetrolPumpMGSystem
{
    public partial class ViewEmployeesInfo : Form
    {
        public ViewEmployeesInfo()
        {
            InitializeComponent();
        }

        private void ViewEmployeesInfo_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\PUCIT\4th sem\DBS\PetrolPumpMGSystem\PetrolPumpMGSystem\PetrolPumpMGSystem\PetrolPump.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
           
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from employee order by EMP_ID asc";
            cmd.ExecuteNonQuery();
            SqlDataAdapter ad = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            ad.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ViewEmployeesInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }
    }
}
