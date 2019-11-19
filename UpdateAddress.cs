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
    public partial class UpdateAddress : Form
    {
        public UpdateAddress()
        {
            InitializeComponent();
        }

        private void UpdateAddress_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\PUCIT\4th sem\DBS\PetrolPumpMGSystem\PetrolPumpMGSystem\PetrolPumpMGSystem\PetrolPump.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();

            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Enter employee id");
            }
            else
            {
                int empid = Convert.ToInt32(textBox1.Text);

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from address where A_USERID ='" + empid + "'";
                cmd.ExecuteNonQuery();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Invalid Employee ID");
                }
                else
                {

                    if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false)
                    {
                        MessageBox.Show("Select Data to be updated");
                    }
                    else
                    {

                        if (checkBox1.Checked == true && !string.IsNullOrEmpty(textBox2.Text))
                        {
                            string qury = "update address set A_COUNTRY ='"+ textBox2.Text + "'where A_USERID='" + textBox1.Text +"'";
                            SqlDataAdapter ad = new SqlDataAdapter(qury, con);
                            ad.SelectCommand.ExecuteNonQuery();
                            MessageBox.Show("COUNTRY updated successfully");

                        }
                        if (checkBox2.Checked == true && !string.IsNullOrEmpty(textBox3.Text))
                        {
                            string qury = "update address set A_CITY ='" + textBox3.Text + "'where A_USERID='" + textBox1.Text + "'";
                            SqlDataAdapter ad = new SqlDataAdapter(qury, con);
                            ad.SelectCommand.ExecuteNonQuery();
                            MessageBox.Show("CITY updated successfully");
                        }
                        if (checkBox3.Checked == true && !string.IsNullOrEmpty(textBox4.Text))
                        {
                            int zip = Convert.ToInt32(textBox4.Text);

                            string qury = "update address set A_ZIPCODE ='" + zip + "'where A_USERID='" + textBox1.Text + "'";
                            SqlDataAdapter ad = new SqlDataAdapter(qury, con);
                            ad.SelectCommand.ExecuteNonQuery();
                            MessageBox.Show("ZIPCODE updated successfully");
                        }
                        if (checkBox4.Checked == true && !string.IsNullOrEmpty(textBox5.Text))
                        {
                            SqlCommand cmd1 = con.CreateCommand();
                            cmd1.CommandType = CommandType.Text;
                            cmd1.CommandText = "select * from address where A_RESIDENCENO='" + textBox5.Text + "'";
                            cmd1.ExecuteNonQuery();
                            SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);

                            DataTable dt1 = new DataTable();
                            sda1.Fill(dt1);
                            if (dt1.Rows.Count == 1)
                            {
                                MessageBox.Show("Residence location already exists.\nEnter the location again with some more details.");
                            }
                            else
                            {
                                string qury = "update address set A_RESIDENCENO ='" + textBox5.Text + "'where A_USERID='" + textBox1.Text + "'";
                                SqlDataAdapter ad = new SqlDataAdapter(qury, con);
                                ad.SelectCommand.ExecuteNonQuery();
                                MessageBox.Show("Residence updated successfully");
                            }
                            string qury1 = "select * from address where A_USERID='"+ empid +"'";
                            SqlDataAdapter ad1 = new SqlDataAdapter(qury1, con);
                            DataTable dt2 = new DataTable();

                            ad1.Fill(dt2);
                            dataGridView1.DataSource = dt2;
                        }
                    }
                }
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateAddress_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }
    }
}
