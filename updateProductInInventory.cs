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
    public partial class updateProductInInventory : Form
    {
        public updateProductInInventory()
        {
            InitializeComponent();
        }

        private void updateProductInInventory_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\PUCIT\4th sem\DBS\PetrolPumpMGSystem\PetrolPumpMGSystem\PetrolPumpMGSystem\PetrolPump.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();

            if (string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Enter complete data");
            }
            else
            {
                int proid = Convert.ToInt32(textBox1.Text);

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from inventory where INV_PRODID ='" + proid + "'";
                cmd.ExecuteNonQuery();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Invalid Product ID");
                }

                else
                {
                    double quant = Convert.ToInt32(textBox3.Text);
                    string qury = "select INV_QUANTITY from inventory where  INV_PRODID ='"+proid+"'";
                    SqlDataAdapter sda1 = new SqlDataAdapter(qury, con);

                    DataTable dt1 = new DataTable();
                    sda1.Fill(dt1);
                    double oldQuant = Convert.ToDouble(dt1.Rows[0][0]);

                    qury = "update inventory set INV_QUANTITY ='" + (quant + oldQuant)+ "', INV_DATE ='" + DateTime.Now + "'where INV_PRODID='" + proid + "'";
                    SqlDataAdapter ad = new SqlDataAdapter(qury, con);
                    ad.SelectCommand.ExecuteNonQuery();
                    MessageBox.Show("Quantity updated successfully");

                    double pay = Convert.ToInt32(textBox2.Text);

                    qury = "insert into purchase values('" + pay + "','" + quant + "','" + DateTime.Now + "','" + proid + "')";
                    SqlDataAdapter ad1 = new SqlDataAdapter(qury, con);
                    ad1.SelectCommand.ExecuteNonQuery();
                    MessageBox.Show("Purchase invoice generated");

                    qury = "select * from inventory where INV_PRODID ='"+proid+"'";
                    ad1 = new SqlDataAdapter(qury, con);
                    dt1 = new DataTable();
                    ad1.Fill(dt1);
                    dataGridView1.DataSource = dt1;


                }
            }
            con.Close();
        }

        private void updateProductInInventory_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\PUCIT\4th sem\DBS\PetrolPumpMGSystem\PetrolPumpMGSystem\PetrolPumpMGSystem\PetrolPump.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            string query1 = "Select PRO_ID,PRO_TYPE from product order by PRO_ID";
            SqlDataAdapter ad2 = new SqlDataAdapter(query1, con);
            DataTable dt2 = new DataTable();
            ad2.Fill(dt2);
            dataGridView1.DataSource = dt2;
            con.Close();
        }
    }
}
