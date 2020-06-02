using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusinessManagementSystem
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void categoryButton_Click(object sender, EventArgs e)
        {
            CategoryUI category = new CategoryUI();
            this.Hide();
            category.Show();
        }

        private void productButton_Click(object sender, EventArgs e)
        {
            ProductUI product = new ProductUI();
            this.Hide();
            product.Show();
        }

        private void customerButton_Click(object sender, EventArgs e)
        {
            CustomerUI customer = new CustomerUI();
            this.Hide();
            customer.Show();
        }

        private void supplierButton_Click(object sender, EventArgs e)
        {
            SupplierUi supplier = new SupplierUi();
            this.Hide();
            supplier.Show();
        }

        private void purchaseButton_Click(object sender, EventArgs e)
        {
            PurchasessUI purchase = new PurchasessUI();
            this.Hide();
           // purchase.Show();
        }

        private void salesButton_Click(object sender, EventArgs e)
        {
            SalesUi sales = new SalesUi();
            this.Hide();
            sales.Show();
        }

        private void reportStockButton_Click(object sender, EventArgs e)
        {
            Stock stock = new Stock();
            this.Hide();
            stock.Show();
        }

        private void reportSaleButton_Click(object sender, EventArgs e)
        {
            ReportOnSales reportOnSales = new ReportOnSales();
            this.Hide();
            reportOnSales.Show();
        }

        private void reportPurchaseButton_Click(object sender, EventArgs e)
        {
            ReportOnPurchase reportOnPurchase = new ReportOnPurchase();
            this.Hide();
            reportOnPurchase.Show();
        }

        

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Home_Load(object sender, EventArgs e)
        {
           UITimer.Start();
        }

        private void UITimer_Tick(object sender, EventArgs e)
        {
            timeLabel.Text = DateTime.Now.ToString("HH:mm");
            secLabel.Text = DateTime.Now.ToString("ss");
            dateLabel.Text = DateTime.Now.ToString("dd/mm/yyyy");
            dayLabel.Text = DateTime.Now.ToString("dddd");
        }
    }
}
