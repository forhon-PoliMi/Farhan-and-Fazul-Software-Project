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
    public partial class DeleteORViewCustomer : Form
    {
        public DeleteORViewCustomer()
        {
            InitializeComponent();
        }

        private void DeleteORViewCustomer_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\PUCIT\4th sem\DBS\PetrolPumpMGSystem\PetrolPumpMGSystem\PetrolPumpMGSystem\PetrolPump.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();

            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Enter Customer ID.");
            }
            else
            {
                int pid = Convert.ToInt32(textBox1.Text);
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from customer where CUST_ID ='" + pid + "'";
                cmd.ExecuteNonQuery();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                
                DataTable dt = new DataTable();
                ad.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Invalid Customer ID");
                }
                else
                {
                    dataGridView1.DataSource = dt;
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DeleteORViewCustomer_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }
    }
}
