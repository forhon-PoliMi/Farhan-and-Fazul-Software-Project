using System;
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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Admin_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\PUCIT\4th sem\DBS\PetrolPumpMGSystem\PetrolPumpMGSystem\PetrolPumpMGSystem\PetrolPump.mdf;Integrated Security=True;Connect Timeout=30");
            string qury = "select * from login where USER_NAME ='" + textBox2.Text + "'and USER_PASSWORD ='" + textBox3.Text + "'";
            SqlDataAdapter ad = new SqlDataAdapter(qury, con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                AdminFunctionality adf = new AdminFunctionality();
                adf.Owner = this;
                adf.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Check username and password");
            }
        }
    }
}
