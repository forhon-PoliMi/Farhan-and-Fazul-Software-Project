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
    public partial class AdminFunctionality : Form
    {
        public AdminFunctionality()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked == true)
            {
                AddEmployee emp = new AddEmployee();
                emp.Owner = this;
                emp.Show();
                this.Hide();
            }
            if (radioButton2.Checked == true)
            {
                UpdateEmployee up = new UpdateEmployee();
                up.Owner = this;
                up.Show();
                this.Hide();
            }
            if (radioButton3.Checked == true)
            {
                ViewOrDeleteEmployee vd = new ViewOrDeleteEmployee();
                vd.Owner = this;
                vd.Show();
                this.Hide();

            }
            if (radioButton4.Checked == true)
            {
                ViewEmployeesInfo vp = new ViewEmployeesInfo();
                vp.Owner = this;
                vp.Show();
                this.Hide();

            }
            if (radioButton5.Checked == true)
            {
                UpdateAddress up = new UpdateAddress();
                up.Owner = this;
                up.Show();
                this.Hide();

            }
            if (radioButton6.Checked == true)
            {
                ViewAddress up = new ViewAddress();
                up.Owner = this;
                up.Show();
                this.Hide();

            }
            if (radioButton7.Checked == true)
            {
                SearchAddress ad = new SearchAddress();
                ad.Owner = this;
                ad.Show();
                this.Hide();

            }
            if (radioButton8.Checked == true)
            {
                AddInventoryItem up = new AddInventoryItem();
                up.Owner = this;
                up.Show();
                this.Hide();

            }
            if (radioButton9.Checked == true)
            {
                UpdateProduct up = new UpdateProduct();
                up.Owner = this;
                up.Show();
                this.Hide();
            }
            if (radioButton10.Checked == true)
            {
                ViewProducts up = new ViewProducts();
                up.Owner = this;
                up.Show();
                this.Hide();

            }
            if (radioButton11.Checked == true)
            {
                DeleteOrViewProduct up = new DeleteOrViewProduct();
                up.Owner = this;
                up.Show();
                this.Hide();

            }
            if (radioButton12.Checked == true)
            {
                ViewBill up = new ViewBill();
                up.Owner = this;
                up.Show();
                this.Hide();

            }
            if (radioButton13.Checked == true)
            {
                ViewInventory v = new ViewInventory();
                v.Owner = this;
                v.Show();
                this.Hide();

            }
            if (radioButton14.Checked == true)
            {
                updateProductInInventory up = new updateProductInInventory();
                up.Owner = this;
                up.Show();
                this.Hide();

            }
            if (radioButton15.Checked == true)
            {
                ViewSales up = new ViewSales();
                up.Owner = this;
                up.Show();
                this.Hide();
            }
            //if (radioButton16.Checked == true)
            //{
            //    GenerateSaleReport up = new GenerateSaleReport();
            //    up.Owner = this;
            //    up.Show();
            //    this.Hide();

            //}
            if (radioButton17.Checked == true)
            {
                ViewPurchase v = new ViewPurchase();
                v.Owner = this;
                v.Show();
                this.Hide();

            }
            //if (radioButton18.Checked == true)
            //{
            //    GeneratePurchaseReport gn = new GeneratePurchaseReport();
            //    gn.Owner = this;
            //    gn.Show();
            //    this.Hide();

            //}
            if (radioButton19.Checked == true)
            {
                ViewPurchaseReport v = new ViewPurchaseReport();
                v.Owner = this;
                v.Show();
                this.Hide();
            }
            if (radioButton20.Checked == true)
            {
                ViewProfitAndLoss v = new ViewProfitAndLoss();
                v.Owner = this;
                v.Show();
                this.Hide();
            }

        }

        private void AdminFunctionality_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }
    }
}
