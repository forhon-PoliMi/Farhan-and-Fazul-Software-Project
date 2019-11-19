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
    public partial class UpdateBill : Form
    {
        public UpdateBill()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\PUCIT\4th sem\DBS\PetrolPumpMGSystem\PetrolPumpMGSystem\PetrolPumpMGSystem\PetrolPump.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();

            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Enter complete information");
            }
            else
            {
                int bid = Convert.ToInt32(textBox1.Text);
                int pid = Convert.ToInt32(textBox3.Text);
                double quantused = Convert.ToDouble(textBox4.Text);
                double total = 0;
                double price;
                double newQuant = Convert.ToDouble(textBox2.Text);

                string query1 = "Select * from product where PRO_ID ='" + pid + "'";
                SqlDataAdapter ad2 = new SqlDataAdapter(query1, con);
                DataTable dt2 = new DataTable();
                ad2.Fill(dt2);

                if (dt2.Rows.Count == 0)
                {
                    MessageBox.Show("Invalid prouct id");
                }

                else
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from bill where B_ID ='" + bid + "'";
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Invalid invoice ID");
                    }
                    else
                    {
                        query1 = "Select * from product where PRO_ID ='" + pid + "'";
                        SqlDataAdapter ad4 = new SqlDataAdapter(query1, con);
                        DataTable dt4 = new DataTable();
                        ad4.Fill(dt4);

                        price = Convert.ToDouble(dt4.Rows[0]["PRO_PRICE"]);

                        total = price * newQuant;


                        query1 = "Select * from inventory where INV_PRODID ='" + pid + "'";
                        SqlDataAdapter ad3 = new SqlDataAdapter(query1, con);
                        DataTable dt3 = new DataTable();
                        ad3.Fill(dt3);

                        double availableQuant = Convert.ToDouble(dt3.Rows[0]["INV_QUANTITY"]);

                        //if ((availableQuant + newQuant - prequantused) < prequantused)
                        //{
                        //    MessageBox.Show("Inventory does not conatain enough fuel");
                        //}
                        //else
                        //{
                            quantused = availableQuant + quantused - newQuant;
                            cmd.CommandText = "update bill set B_TOTAL ='" + total + "', B_QUANTITY ='" + newQuant + "',B_PRODID='" + pid+ "'where B_ID = '" + bid + "'";
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("INVOICE UPDATED");
                            cmd.CommandText = "update inventory set INV_QUANTITY ='" + quantused + "'where INV_PRODID='"+pid+"'";
                            cmd.ExecuteNonQuery();
                        //}
                    }
                }
            }
            con.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateBill_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }

        private void UpdateBill_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\PUCIT\4th sem\DBS\PetrolPumpMGSystem\PetrolPumpMGSystem\PetrolPumpMGSystem\PetrolPump.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            string query1 = "Select PRO_ID,PRO_TYPE from product order by PRO_ID asc"; ;
            SqlDataAdapter ad2 = new SqlDataAdapter(query1, con);
            DataTable dt2 = new DataTable();
            ad2.Fill(dt2);
            dataGridView1.DataSource = dt2;
            con.Close();
        }
    }
}
