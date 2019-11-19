using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetrolPumpMGSystem
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Admin")
            {
                Admin ad = new Admin();
                ad.Owner = this;
                ad.Show();
                this.Hide();
            }
            else if (comboBox1.Text == "Cashier")
            {
                UserLogin usr = new UserLogin();
                usr.Owner = this;
                usr.Show();
                this.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
