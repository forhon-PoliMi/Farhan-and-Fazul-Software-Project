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
    public partial class AddEmployee : Form
    {
        public AddEmployee()
        {
            InitializeComponent();
        }

        private void AddEmployee_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void AddEmployee_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\PUCIT\4th sem\DBS\PetrolPumpMGSystem\PetrolPumpMGSystem\PetrolPumpMGSystem\PetrolPump.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();

            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox6.Text) || string.IsNullOrEmpty(textBox3.Text) ||
                string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox5.Text) || string.IsNullOrEmpty(textBox7.Text) ||
                string.IsNullOrEmpty(textBox8.Text) || string.IsNullOrEmpty(textBox9.Text) || string.IsNullOrEmpty(textBox10.Text))
            {
                MessageBox.Show("Enter complete information of employee");
            }
            else
            {
                SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "select * from address where A_RESIDENCENO='"+ textBox9.Text + "'" ;
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
                    double salary = Convert.ToDouble(textBox10.Text);

                    cmd1.CommandText = "insert into employee values('" + textBox1.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + salary + "','" + textBox5.Text + "')";
                    cmd1.ExecuteNonQuery();

                    string query = "Select max(EMP_ID) from employee";
                    SqlDataAdapter ad = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    ad.Fill(dt);

                    int id = Convert.ToInt32(dt.Rows[0][0]);
                    int zipcode = Convert.ToInt32(textBox8.Text);

                    cmd1.CommandText = "insert into address values('" + textBox6.Text + "','" + textBox7.Text + "','" + zipcode + "','" + textBox9.Text + "','" + id + "')";
                    cmd1.ExecuteNonQuery();
                    MessageBox.Show("Data inserted successfully");

                    query = "Select * from employee where EMP_ID = '" +id+ "'";
                    ad = new SqlDataAdapter(query, con);
                    dt = new DataTable();
                    ad.Fill(dt);

                    dataGridView1.DataSource = dt;

                }

            }
            con.Close();
            
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
