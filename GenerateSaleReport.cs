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
    public partial class GenerateSaleReport : Form
    {
        public GenerateSaleReport()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\PUCIT\4th sem\DBS\PetrolPumpMGSystem\PetrolPumpMGSystem\PetrolPumpMGSystem\PetrolPump.mdf;Integrated Security=True;Connect Timeout=30");
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Enter product id");
            }

            else
            {
                double pid = Convert.ToDouble(textBox1.Text);
                double total = 0;
                double q = 0;
                con.Open();
                string  query1 = "Select * from bill";
                SqlDataAdapter ad3 = new SqlDataAdapter(query1, con);
                DataTable dt3 = new DataTable();
                ad3.Fill(dt3);

                
                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    DateTime d1 = Convert.ToDateTime(dt3.Rows[i]["B_DATE"]);
                    DateTime d2 = dateTimePicker1.Value.Date;
                    
                    int prodid = Convert.ToInt32(dt3.Rows[i]["B_PRODID"]);
                    if ( prodid == pid && d1.Month == d2.Month && d1.Year == d2.Year)
                    {
                        total = total + Convert.ToDouble(dt3.Rows[i]["B_TOTAL"]);
                        q = q + Convert.ToDouble(dt3.Rows[i]["B_QUANTITY"]);
                    }
                }

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into sale values('" +pid+ "','" +q+ "','" + total + "','" + DateTime.Now + "')";
                cmd.ExecuteNonQuery();

                MessageBox.Show("Sales report created");

                con.Close();
            }
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GenerateSaleReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }

        private void GenerateSaleReport_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\PUCIT\4th sem\DBS\PetrolPumpMGSystem\PetrolPumpMGSystem\PetrolPumpMGSystem\PetrolPump.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            string query1 = "Select PRO_ID,PRO_TYPE from product order by PRO_ID asc";
            SqlDataAdapter ad2 = new SqlDataAdapter(query1, con);
            DataTable dt2 = new DataTable();
            ad2.Fill(dt2);
            dataGridView1.DataSource = dt2;
            con.Close();
        }
    }
}
