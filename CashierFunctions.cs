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
    public partial class CashierFunctions : Form
    {
        public CashierFunctions()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GenerateBill gn = new GenerateBill();
            gn.Owner = this;
            gn.Show();
            this.Hide();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            UpdateBill up = new UpdateBill();
            up.Owner = this;
            up.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ViewBill vb = new ViewBill();
            vb.Owner = this;
            vb.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UpdateCustomer uc = new UpdateCustomer();
            uc.Owner = this;
            uc.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ViewCustomers vb = new ViewCustomers();
            vb.Owner = this;
            vb.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CashierFunctions_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DeleteORViewCustomer c = new DeleteORViewCustomer();
            c.Owner = this;
            this.Hide();
            c.Show();
        }
    }
}
