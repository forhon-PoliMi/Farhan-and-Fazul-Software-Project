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
    public partial class UpdateEmployee : Form
    {
        public UpdateEmployee()
        {
            InitializeComponent();
        }

        private void UpdateEmployee_Load(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateEmployee_FormClosed(object sender, FormClosedEventArgs e)
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
                int empid = Convert.ToInt32(textBox1.Text);
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from employee where EMP_ID ='" + empid + "'";
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
                    if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false &&
                         checkBox5.Checked == false)
                    {
                        MessageBox.Show("Select Data to be updated");
                    }
                    else
                    {

                        if (checkBox1.Checked == true && !string.IsNullOrEmpty(textBox2.Text))
                        {
                            double salary = Convert.ToDouble(textBox2.Text);

                            string qury = "update employee set EMP_SALARY ='" + salary + "'where EMP_ID='" + empid + "'";
                            SqlDataAdapter ad = new SqlDataAdapter(qury, con);
                            ad.SelectCommand.ExecuteNonQuery();
                            MessageBox.Show("Salary updated successfully");

                        }
                        else if (checkBox1.Checked == false && !string.IsNullOrEmpty(textBox2.Text))
                        {
                            MessageBox.Show("Select Salary if you want to update.");
                        }
                        if (checkBox5.Checked == true && !string.IsNullOrEmpty(textBox6.Text))
                        {
                            string qury = "update employee set EMP_NAME ='" + textBox6.Text + "'where EMP_ID='" + empid + "'";
                            SqlDataAdapter ad = new SqlDataAdapter(qury, con);
                            ad.SelectCommand.ExecuteNonQuery();
                            MessageBox.Show("Name updated successfully");
                        }
                        else if (checkBox5.Checked == false && !string.IsNullOrEmpty(textBox6.Text))
                        {
                            MessageBox.Show("Select Name if you want to update.");
                        }
                        if (checkBox2.Checked == true && !string.IsNullOrEmpty(textBox3.Text))
                        {
                            string qury = "update employee set EMP_POST ='" + textBox3.Text + "'where EMP_ID='" + empid + "'";
                            SqlDataAdapter ad = new SqlDataAdapter(qury, con);
                            ad.SelectCommand.ExecuteNonQuery();
                            MessageBox.Show("Post updated successfully");
                        }
                        else if (checkBox2.Checked == false && !string.IsNullOrEmpty(textBox3.Text))
                        {
                            MessageBox.Show("Select Post if you want to update.");
                        }
                        if (checkBox3.Checked == true && !string.IsNullOrEmpty(textBox4.Text))
                        {
                            string qury = "update employee set EMP_SHIFT ='" + textBox4.Text + "'where EMP_ID='" + empid + "'";
                            SqlDataAdapter ad = new SqlDataAdapter(qury, con);
                            ad.SelectCommand.ExecuteNonQuery();
                            MessageBox.Show("Shift updated successfully");
                        }
                        else if (checkBox3.Checked == false && !string.IsNullOrEmpty(textBox4.Text))
                        {
                            MessageBox.Show("Select Shift if you want to update.");
                        }
                        if (checkBox4.Checked == true && !string.IsNullOrEmpty(textBox5.Text))
                        {
                            string qury = "update employee set EMP_CONTACTNO ='" + textBox5.Text + "'where EMP_ID='" + empid + "'";
                            SqlDataAdapter ad = new SqlDataAdapter(qury, con);
                            ad.SelectCommand.ExecuteNonQuery();
                            MessageBox.Show("Contact number updated successfully");
                        }
                        else if (checkBox4.Checked == false && !string.IsNullOrEmpty(textBox5.Text))
                        {
                            MessageBox.Show("Select Contact Number if you want to update.");
                        }

                        string qury1 = "select * from employee where EMP_ID='" + empid + "'";
                        SqlDataAdapter ad1 = new SqlDataAdapter(qury1, con);
                        DataTable dt1 = new DataTable();
                        ad1.Fill(dt1);
                        dataGridView1.DataSource = dt1;
                    }
                }
            }
            con.Close();

        }
    }
}
