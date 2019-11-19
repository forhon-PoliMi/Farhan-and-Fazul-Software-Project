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
    public partial class UpdateProduct : Form
    {
        public UpdateProduct()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void UpdateProduct_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\PUCIT\4th sem\DBS\PetrolPumpMGSystem\PetrolPumpMGSystem\PetrolPumpMGSystem\PetrolPump.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            string query1 = "Select PRO_ID,PRO_TYPE from product order by PRO_ID asc ";
            SqlDataAdapter ad2 = new SqlDataAdapter(query1, con);
            DataTable dt2 = new DataTable();
            ad2.Fill(dt2);
            dataGridView1.DataSource = dt2;
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateProduct_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\PUCIT\4th sem\DBS\PetrolPumpMGSystem\PetrolPumpMGSystem\PetrolPumpMGSystem\PetrolPump.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();

            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Enter complete information");
            }
            else
            {
                int prodid = Convert.ToInt32(textBox1.Text);

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from product where PRO_ID ='" + prodid + "'";
                cmd.ExecuteNonQuery();

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Invalid product ID");
                }
                else
                {
                    double price = Convert.ToDouble(textBox3.Text);
                    string qury = "update product set PRO_PRICE ='" + price + "'where PRO_ID='" + prodid + "'";
                    SqlDataAdapter ad = new SqlDataAdapter(qury, con);
                    ad.SelectCommand.ExecuteNonQuery();
                    MessageBox.Show("PRICE updated successfully");
                }
            }
            con.Close();
        }
    }
}
