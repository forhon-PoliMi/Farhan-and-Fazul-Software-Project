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
    public partial class ViewOrDeleteEmployee : Form
    {
        public ViewOrDeleteEmployee()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ViewOrDeleteEmployee_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
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
                int id = Convert.ToInt32(textBox1.Text);

                if (radioButton1.Checked == true)
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from employee where EMP_ID ='" + id + "'";
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter ad = new SqlDataAdapter(cmd);

                    DataTable dt = new DataTable();
                    ad.Fill(dt);
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Invalid Employee ID");
                    }
                    else
                    {
                        string qury = "delete from employee where EMP_ID ='" + id + "'";
                        SqlDataAdapter sda1 = new SqlDataAdapter(qury, con);
                        DataTable dta1 = new DataTable();
                        sda1.Fill(dta1);
                        sda1.SelectCommand.ExecuteNonQuery();

                        MessageBox.Show("Data deleted successfully");

                    }

                }
                else if (radioButton2.Checked == true)
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from employee where EMP_ID ='" + id + "'";
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter ad = new SqlDataAdapter(cmd);

                    DataTable dt = new DataTable();
                    ad.Fill(dt);
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Employee ID does not exists.");
                    }
                    else
                    {
                        dataGridView1.DataSource = dt;
                    }
                }
                else
                {
                    MessageBox.Show("Select a function to be performed!");
                }
            }
            con.Close();
        }
    }
}
