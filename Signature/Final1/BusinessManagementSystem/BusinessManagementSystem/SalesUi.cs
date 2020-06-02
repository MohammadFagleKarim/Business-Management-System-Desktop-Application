using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BusinessManagementSystem.Manager;
using BusinessManagementSystem.Model;

namespace BusinessManagementSystem
{
    public partial class SalesUi : Form
    {
        
        SalesManager _salesManager = new SalesManager();

        int loyality;
        double grandTotal;
        double availableQuantity;

        public SalesUi()
        {
            InitializeComponent();       
            //availableQuantityTextBox.ReadOnly = true;
            totalMrpTextBox.ReadOnly = true;
            grandTotalTextBox.ReadOnly = true;
            discountTextBox.ReadOnly = true;
            discountAmountTextBox.ReadOnly = true;
            payableAmountTextBox.ReadOnly = true;
            //loyalityPointTextBox.ReadOnly = true;

        }

        private List<SalesProduct> _salesProducts;

        private void addButton_Click(object sender, EventArgs e)
        {
           // Set as Mandatory

           if (String.IsNullOrEmpty(quantityTextBox.Text))
           {
               MessageBox.Show("Quantity Can not be Empty!!!");
               return;
           }
           
           if (String.IsNullOrEmpty(mrpTextBox.Text))
           {
               MessageBox.Show("MRP Can not be Empty!!!");
               return;
           }
           if (String.IsNullOrEmpty(availableQuantityTextBox.Text))
           {
               MessageBox.Show("Available Quantity Can not be Empty!!!");
               return;
           }


           if (String.IsNullOrEmpty(totalMrpTextBox.Text))
           {
               MessageBox.Show("Total MRP Can not be Empty!!!");
               return;
           }

           if (categoryComboBox.Text == "-Select-")
           {
               MessageBox.Show("Select a category");
               return;
           }

           if (productComboBox.Text == "-Select-")
           {
               MessageBox.Show("Select a product");
               return;
           }

            SalesProduct salesProduct = new SalesProduct();

           salesProduct.CategoryId = Convert.ToInt32(categoryComboBox.SelectedValue);
           salesProduct.ProductId = Convert.ToInt32(productComboBox.SelectedValue);
           salesProduct.AvailableQuantity = Convert.ToInt32(availableQuantityTextBox.Text);
           salesProduct.Quantity = Convert.ToInt32(quantityTextBox.Text);
           salesProduct.MRP = Convert.ToDouble(mrpTextBox.Text);
           salesProduct.TotalMRP = Convert.ToDouble(totalMrpTextBox.Text);
           salesProduct.ProductName = productComboBox.Text;

            if (_salesProducts == null)
            {
                _salesProducts = new List<SalesProduct>();

            }

            if (Convert.ToInt32(availableQuantityTextBox.Text) >= Convert.ToInt32(quantityTextBox.Text))
            {
                _salesProducts.Add(salesProduct);

                MessageBox.Show(" Saved");

                Sales _sale = new Sales();

                grandTotalTextBox.Text = GrandTotal(Convert.ToDouble(totalMrpTextBox.Text)).ToString();

                //loyalityPointTextBox.Text = Loyality(Convert.ToDouble(grandTotalTextBox.Text)).ToString();

                discountTextBox.Text = Discount(Convert.ToInt32(loyalityPointTextBox.Text)).ToString();
                discountAmountTextBox.Text = DiscountAmount(Convert.ToDouble(grandTotalTextBox.Text), Convert.ToDouble(discountTextBox.Text)).ToString();
                payableAmountTextBox.Text = PayableAmount(Convert.ToDouble(grandTotalTextBox.Text), Convert.ToDouble(discountAmountTextBox.Text)).ToString();
                //   availableQuantity = _salesManager.AvailableQuantity(salesProduct);
                availableQuantity = Convert.ToDouble(availableQuantityTextBox.Text);
                //availableQuantityTextBox.Text = availableQuantity.ToString();
                availableQuantityTextBox.Text = AvailableQuantity(Convert.ToInt32(quantityTextBox.Text)).ToString();

                salesDataGridView.DataSource = null;
                salesDataGridView.DataSource = _salesProducts;
            }
        }

        private void SalesUi_Load(object sender, EventArgs e)
        {
            categoryComboBox.DataSource = _salesManager.CategoryCombo();
            categoryComboBox.Text = "-Select-";
            productComboBox.DataSource = _salesManager.ProductCombo();
            productComboBox.Text = "-Select-";
            customerComboBox.DataSource = _salesManager.CustomerCombo();
            customerComboBox.Text = "-Select-";
        }
        
        private void quantityTextBox_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void mrpTextBox_TextChanged(object sender, EventArgs e)
        {
            totalMrpTextBox.Text = TotalMRP().ToString();
        }
        
        private void submitButton_Click(object sender, EventArgs e)
        {
            if (customerComboBox.Text == "-Select-")
            {
                MessageBox.Show("Select a customer");
                return;
            }
            salesDataGridView.DataSource = null;

            Sales _sale = new Sales();

            _sale.CustomerId = Convert.ToInt32(customerComboBox.SelectedValue);
            _sale.Date = salesDateTimePicker.Value;
            _sale.LoyalityPoint = Convert.ToInt32(loyalityPointTextBox.Text);
            _sale.GrandTotal = Convert.ToDouble(grandTotalTextBox.Text);
            _sale.Discount = Convert.ToDouble(discountTextBox.Text);
            _sale.DiscountAmount = Convert.ToDouble(discountAmountTextBox.Text);
            _sale.PayableAmount = Convert.ToDouble(payableAmountTextBox.Text);
            
            bool isSubmited = _salesManager.Submit(_sale);

            if (isSubmited)
            {
                MessageBox.Show("Saved");
            }
            else
            {
                MessageBox.Show("Not Saved");
            }

            SalesProduct salesProduct = new SalesProduct();
            salesProduct.CategoryId = Convert.ToInt32(categoryComboBox.SelectedValue);
            salesProduct.ProductId = Convert.ToInt32(productComboBox.SelectedValue);
            availableQuantityTextBox.Text = _salesManager.AvailableQuantity(salesProduct).ToString();
            loyalityPointTextBox.Text = Loyality(Convert.ToDouble(grandTotalTextBox.Text)).ToString();
        }

        private void productComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
         

        }

        private void salesDataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            salesDataGridView.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void salesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            categoryComboBox.DataSource = _salesManager.CategoryCombo();
            productComboBox.DataSource = _salesManager.ProductCombo();
            customerComboBox.DataSource = _salesManager.CustomerCombo();
        }
        public double AvailableQuantity(int quantity)
        {
            availableQuantity = availableQuantity - quantity;
            return availableQuantity;
        }

        public double TotalMRP()
        {
            double totalMRP = Convert.ToDouble(quantityTextBox.Text) * Convert.ToDouble(mrpTextBox.Text);
            return totalMRP;
        }
        public double GrandTotal(double totalMRP)
        {
            grandTotal = grandTotal + totalMRP;
            return grandTotal;
        }
        public int Loyality(double grandTotal)
        {

            if (grandTotal > 1000)
            {
                loyality = Convert.ToInt32(grandTotal / 1000);
            }

            return loyality;
        }
        public double Discount(int loyality)
        {
            double discount = loyality / 10;

            loyalityPointTextBox.Text = (loyality - (loyality / 10)).ToString();

            return discount;
        }
        public double DiscountAmount(double grandTotal, double discount)
        {
            double discountAmount = (grandTotal * discount) / 100;

            return discountAmount;
        }

        public double PayableAmount(double grandTotal, double discountAmount)
        {
            double payableAmount = (grandTotal - discountAmount);
            
            return payableAmount;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            this.Hide();
            home.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }
    }
}
