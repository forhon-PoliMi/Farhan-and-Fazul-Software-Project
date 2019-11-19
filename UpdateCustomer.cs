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
    public partial class UpdateCustomer : Form
    {
        public UpdateCustomer()
        {
            InitializeComponent();
        }

        private void UpdateCustomer_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\PUCIT\4th sem\DBS\PetrolPumpMGSystem\PetrolPumpMGSystem\PetrolPumpMGSystem\PetrolPump.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();

            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Enter colmplete data");
            }
            else
            {
                int custid = Convert.ToInt32(textBox1.Text);
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from customer where CUST_ID ='" + custid + "'";
                cmd.ExecuteNonQuery();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Invalid customer ID");
                }
                else
                {
                    string qury = "update customer set CUST_VEHNO ='" + textBox2.Text + "'where CUST_ID='" + custid + "'";
                    SqlDataAdapter ad = new SqlDataAdapter(qury, con);
                    ad.SelectCommand.ExecuteNonQuery();
                    MessageBox.Show("vehicle number is updated");

                    qury= "select * from customer where CUST_ID = '"+custid+"'";
                    ad = new SqlDataAdapter(qury, con);
                    DataTable dt1 = new DataTable();
                    ad.Fill(dt1);

                    dataGridView1.DataSource = dt1;

                }
            }
            con.Close();

        }

        private void UpdateCustomer_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }
    }
}
