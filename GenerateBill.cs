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
    public partial class GenerateBill : Form
    {
       
        public GenerateBill()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\PUCIT\4th sem\DBS\PetrolPumpMGSystem\PetrolPumpMGSystem\PetrolPumpMGSystem\PetrolPump.mdf;Integrated Security=True;Connect Timeout=30");
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Enter complete data");
            }

            else
            {
                double fu = Convert.ToDouble(textBox1.Text);
                int pid = Convert.ToInt32(textBox3.Text);
                double total = 0;

                con.Open();

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
                    query1 = "Select * from inventory where INV_PRODID ='" + pid + "'";

                    SqlDataAdapter ad3 = new SqlDataAdapter(query1, con);
                    DataTable dt3 = new DataTable();
                    ad3.Fill(dt3);

                    double availableQuant = Convert.ToDouble(dt3.Rows[0]["INV_QUANTITY"]);

                    if (availableQuant < fu)
                    {
                        MessageBox.Show("Inventory does not conatain enough fuel");

                    }

                    else
                    {
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "insert into customer values('" + textBox2.Text + "')";
                        cmd.ExecuteNonQuery();

                        query1 = "Select max(CUST_ID) from customer";
                        SqlDataAdapter ad1 = new SqlDataAdapter(query1, con);
                        DataTable dt1 = new DataTable();
                        ad1.Fill(dt1);

                        int custdid = Convert.ToInt32(dt1.Rows[0][0]);

                        query1 = "Select * from product where PRO_ID ='" + pid + "'";
                        SqlDataAdapter ad4 = new SqlDataAdapter(query1, con);
                        DataTable dt4 = new DataTable();
                        ad4.Fill(dt4);

                        double price = Convert.ToDouble(dt4.Rows[0]["PRO_PRICE"]);

                        total = price * fu;
                        
                        availableQuant = (availableQuant - fu);
                        cmd.CommandText = "insert into bill values('" + custdid + "','" + fu + "','" + pid + "','" + total + "','" + DateTime.Now + "')";
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("invoice generated");
                        cmd.CommandText = "update inventory set INV_QUANTITY ='" + availableQuant + "'where INV_PRODID ='" + pid + "'";
                        cmd.ExecuteNonQuery();

                        query1 = "Select max(B_ID) from bill";

                        ad3 = new SqlDataAdapter(query1, con);
                        dt3 = new DataTable();
                        ad3.Fill(dt3);

                        query1 = "Select * from customer where CUST_ID='" +custdid+ "'" ;

                        SqlDataAdapter ad = new SqlDataAdapter(query1, con);
                        DataTable dt = new DataTable();
                        ad.Fill(dt);

                        MessageBox.Show("Invoice No: " + dt3.Rows[0][0] + "\n--------------------------\nDate: " +DateTime.Now+ "\nCunstomer No: " +dt1.Rows[0][0] + 
                                        "\nVehicle No: " +dt.Rows[0]["CUST_VEHNO"].ToString().ToUpper()+  "\nFuel Quantity Used: " +fu+ "units\nProduct Used: "
                                            + dt4.Rows[0]["PRO_TYPE"].ToString().ToUpper() + "\nTotal Bill: " +total+ "Rs.");
                    }
                }
                con.Close();
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           this.Close();
        }

        private void GenerateBill_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Owner.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void GenerateBill_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\PUCIT\4th sem\DBS\PetrolPumpMGSystem\PetrolPumpMGSystem\PetrolPumpMGSystem\PetrolPump.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            string query1 = "Select PRO_ID,PRO_TYPE, PRO_PRICE from product order by PRO_ID asc"; 
            SqlDataAdapter ad2 = new SqlDataAdapter(query1, con);
            DataTable dt2 = new DataTable();
            ad2.Fill(dt2);
            dataGridView1.DataSource = dt2;
            con.Close();
        }
    }
}
