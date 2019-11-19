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
    public partial class AdminFunctions : Form
    {
        public AdminFunctions()
        {
            InitializeComponent();
        }

        private void AdminFunctions_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            AddEmployee emp = new AddEmployee();
            emp.Owner = this;
            emp.Show();
            this.Hide();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            UpdateEmployee up = new UpdateEmployee();
            up.Owner = this;
            up.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ViewOrDeleteEmployee vd = new ViewOrDeleteEmployee();
            vd.Owner = this;
            vd.Show();
            this.Hide();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            ViewEmployeesInfo vp = new ViewEmployeesInfo();
            vp.Owner = this;
            vp.Show();
            this.Hide();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            UpdateAddress up = new UpdateAddress();
            up.Owner = this;
            up.Show();
            this.Hide();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            DeleteOrViewProduct up = new DeleteOrViewProduct();
            up.Owner = this;
            up.Show();
            this.Hide();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ViewAddress up = new ViewAddress();
            up.Owner = this;
            up.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AddInventoryItem up = new AddInventoryItem();
            up.Owner = this;
            up.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            UpdateProduct up = new UpdateProduct();
            up.Owner = this;
            up.Show();
            this.Hide();
        }

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            ViewProducts up = new ViewProducts();
            up.Owner = this;
            up.Show();
            this.Hide();

        }

        private void button9_Click(object sender, EventArgs e)
        {
            GenerateSaleReport up = new GenerateSaleReport();
            up.Owner = this;
            up.Show();
            this.Hide();

        }

        private void button10_Click(object sender, EventArgs e)
        {
            ViewBill up = new ViewBill();
            up.Owner = this;
            up.Show();
            this.Hide();

        }

        private void button11_Click(object sender, EventArgs e)
        {
            ViewSales up = new ViewSales();
            up.Owner = this;
            up.Show();
            this.Hide();

        }

        private void button15_Click_1(object sender, EventArgs e)
        {
            SearchAddress ad = new SearchAddress();
            ad.Owner = this;
            ad.Show();
            this.Hide();

        }

        private void button16_Click(object sender, EventArgs e)
        {
            ViewInventory v = new ViewInventory();
            v.Owner = this;
            v.Show();
            this.Hide();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            ViewPurchase v = new ViewPurchase();
            v.Owner = this;
            v.Show();
            this.Hide();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            updateProductInInventory up = new updateProductInInventory();
            up.Owner = this;
            up.Show();
            this.Hide();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            GeneratePurchaseReport gn = new GeneratePurchaseReport();
            gn.Owner = this;
            gn.Show();
            this.Hide();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            ViewPurchaseReport v = new ViewPurchaseReport();
            v.Owner = this;
            v.Show();
            this.Hide();
        }
    }
}
