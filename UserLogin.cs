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
    public partial class UserLogin : Form
    {
        public UserLogin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\PUCIT\4th sem\DBS\PetrolPumpMGSystem\PetrolPumpMGSystem\PetrolPumpMGSystem\PetrolPump.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "Select * from login where USER_NAME ='" + textBox2.Text.Trim() + "'and USER_PASSWORD ='" + textBox3.Text.Trim() + "'";
            SqlDataAdapter ad = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                CashierFunctions cf = new CashierFunctions();
                cf.Owner = this;
                cf.Show();
                this.Hide();
               
            }
            else
            {
                MessageBox.Show("Check username and password");
            }

           
        }

        private void button1_Click(object sender, EventArgs e)
        {
           this.Close();
        }

        private void UserLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }

    }
}
