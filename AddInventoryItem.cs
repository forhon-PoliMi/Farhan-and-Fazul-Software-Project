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
    public partial class AddInventoryItem : Form
    {
        public AddInventoryItem()
        {
            InitializeComponent();
        }

        private void AddInventoryItem_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\PUCIT\4th sem\DBS\PetrolPumpMGSystem\PetrolPumpMGSystem\PetrolPumpMGSystem\PetrolPump.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();


            string q = "select PRO_ID,PRO_TYPE,PRO_PRICE from product";
            SqlDataAdapter sda1 = new SqlDataAdapter(q,con);

            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);

            dataGridView1.DataSource = dt1;

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
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

        private void AddInventoryItem_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\PUCIT\4th sem\DBS\PetrolPumpMGSystem\PetrolPumpMGSystem\PetrolPumpMGSystem\PetrolPump.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();


            if (string.IsNullOrEmpty(textBox6.Text) || string.IsNullOrEmpty(textBox3.Text) ||
                string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox5.Text))
            {
                MessageBox.Show("Enter complete information");
            }
            else
            {

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from product where PRO_TYPE ='" + textBox4.Text + "'";
                cmd.ExecuteNonQuery();
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd);

                DataTable dt1 = new DataTable();
                sda1.Fill(dt1);
                if (dt1.Rows.Count == 1)
                {
                    MessageBox.Show("Item already exists.");
                }
                else
                {

                    double quant = Convert.ToDouble(textBox5.Text);
                    double price = Convert.ToDouble(textBox6.Text);

                    cmd.CommandText = "insert into product values('" + textBox4.Text + "','" + price + "','" + quant + "')";
                    cmd.ExecuteNonQuery();

                    string query = "Select max(PRO_ID) from product";
                    SqlDataAdapter ad = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    ad.Fill(dt);

                    int prodid = Convert.ToInt32(dt.Rows[0][0]);

                    cmd.CommandText = "insert into inventory values('" + prodid + "','" + quant + "','" + DateTime.Now + "')";
                    cmd.ExecuteNonQuery();

                    double pay = Convert.ToDouble(textBox3.Text);

                    cmd.CommandText = "insert into purchase values('" + pay + "','" + quant + "','" + DateTime.Now + "','" + prodid + "')";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data inserted successfully");

                    query = "Select * from product";
                    ad = new SqlDataAdapter(query, con);
                    dt = new DataTable();
                    ad.Fill(dt);

                    dataGridView1.DataSource = dt;
                    con.Close();
                }
            }
        }
    }
}
