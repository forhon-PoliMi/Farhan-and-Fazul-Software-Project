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
    public partial class ViewProfitAndLoss : Form
    {
        public ViewProfitAndLoss()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void ViewProfitAndLoss_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }

        private void ViewProfitAndLoss_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\PUCIT\4th sem\DBS\PetrolPumpMGSystem\PetrolPumpMGSystem\PetrolPumpMGSystem\PetrolPump.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            string query1 = "Select PRO_ID, PRO_TYPE from product order by PRO_ID asc";
            SqlDataAdapter ad2 = new SqlDataAdapter(query1, con);
            DataTable dt2 = new DataTable();
            ad2.Fill(dt2);
            dataGridView1.DataSource = dt2;
            con.Close();
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
                double totalSale = 0;
                double qs = 0;
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;

                string query1 = "Select * from bill where B_PRODID='"+pid+"'";
                //string query1 ="select to_char(B_DATE, 'fm mm')"
                SqlDataAdapter ad3 = new SqlDataAdapter(query1, con);
                DataTable dt3 = new DataTable();
                ad3.Fill(dt3);

                if (dt3.Rows.Count != 0)
                {
                    for (int i = 0; i < dt3.Rows.Count; i++)
                    {
                        DateTime d1 = Convert.ToDateTime(dt3.Rows[i]["B_DATE"]);
                        DateTime d2 = dateTimePicker1.Value.Date;

                        // int prodid = Convert.ToInt32(dt3.Rows[i]["B_PRODID"]);
                        /*prodid == pid &&*/
                        if (d1.Month == d2.Month && d1.Year == d2.Year)
                        {
                            totalSale = totalSale + Convert.ToDouble(dt3.Rows[i]["B_TOTAL"]);
                            qs = qs + Convert.ToDouble(dt3.Rows[i]["B_QUANTITY"]);
                        }
                    }
                    if (totalSale > 0 && qs > 0)
                    {
                        cmd.CommandText = "insert into sale values('" + pid + "','" + qs + "','" + totalSale + "','" + DateTime.Now + "')";
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        MessageBox.Show("No Sales record for this month exists");
                    }
                }
                else
                {
                    MessageBox.Show("No Sales record for this month exists");
                }

                //Purchase:

                double totalPurchase = 0;
                double qp = 0;
                query1 = "Select * from purchase where P_PRODID ='" + pid + "'";
                SqlDataAdapter ad = new SqlDataAdapter(query1, con);
                DataTable dt = new DataTable();
                ad.Fill(dt);

                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DateTime d1 = Convert.ToDateTime(dt.Rows[i]["P_DATE"]);
                        DateTime d2 = dateTimePicker1.Value.Date;

                        //  int prodid = Convert.ToInt32(dt.Rows[i]["P_PRODID"]);
                     
                        if (d1.Month == d2.Month && d1.Year == d2.Year)
                        {
                            totalPurchase = totalPurchase + Convert.ToDouble(dt.Rows[i]["P_PAYMENT"]);
                            qp = qp + Convert.ToDouble(dt.Rows[i]["P_QUANTITY"]);
                        }
                    }
                    if (totalPurchase > 0 && qp > 0)
                    {
                        cmd.CommandText = "insert into totalpurchase values('" + totalPurchase + "','" + qp + "','" + DateTime.Now + "','" + pid + "')";
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        MessageBox.Show("No Purchase record for this month exists");
                    }
                }
                else
                {
                    MessageBox.Show("No Purchase record for this month exists");
                }
                query1 = "Select PRO_TYPE from product where PRO_ID='" + pid + "'";
                
                ad3 = new SqlDataAdapter(query1, con);
                dt3 = new DataTable();
                ad3.Fill(dt3);

                double result = totalSale - totalPurchase;
                if(result == 0)
                {
                    
                    MessageBox.Show("Monthly Report\n----------------------------------------\n\nProduct: "+dt3.Rows[0][0].ToString()+ "\nQuantity Purchased : "+qp+"\nQuantity Sold : " +qs+"\nSale : "+totalSale+"Rs.\nPurchase : "+totalPurchase+"Rs.\nNo Profit or loss");
                }
                else if (result > 0)
                {
                    MessageBox.Show("Monthly Report\n----------------------------------------\n\nProduct: " + dt3.Rows[0][0].ToString() + "\nQuantity Purchased : " + qp + "\nQuantity Sold : " + qs + "\nSale : " + totalSale + "Rs.\nPurchase : " + totalPurchase + "Rs.\nProfit : " + result.ToString() +"Rs.");
                }
                else if (result < 0)
                {
                    result = result * (-1);
                    MessageBox.Show("Monthly Report\n----------------------------------------\n\nProduct: " + dt3.Rows[0][0].ToString() + "\nQuantity Purchased : " + qp + "\nQuantity Sold : " + qs + "\nSale : " + totalSale + "Rs.\nPurchase : " + totalPurchase + "Rs.\nLoss : " + result.ToString() + "Rs.");
                }
            }
            con.Close();
        }
    }
}
