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
    public partial class Stock : Form
    {
        StockManager _stockManager = new StockManager();
             
        public Stock()
        {
            InitializeComponent();
            stockDataGridView.DataSource = _stockManager.Display();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void homeButton_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            this.Hide();
            home.Show();
        }

        private void radioSearchButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(productTextBox.Text))
            {
                MessageBox.Show("product should not be empty!");
                stockDataGridView.DataSource = _stockManager.Display();
                return;
            }

            //Set Code as Mandatory
            if (String.IsNullOrEmpty(categoryTextBox.Text))
            {
                MessageBox.Show("category should not be empty!");
                stockDataGridView.DataSource = _stockManager.Display();
                return;
            }

            Stocks stock = new Stocks();

            stock.ProductName = productTextBox.Text;
            stock.CategoryName = categoryTextBox.Text;
            stock.StartDate = startDateTimePicker.Value;
            stock.EndDate = startDateTimePicker.Value;

            stockDataGridView.DataSource=_stockManager.Display();
        }

        private void stockDataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            stockDataGridView.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void productTextBox_TextChanged(object sender, EventArgs e)
        {
            Stocks stock = new Stocks();

            stock.ProductName = productTextBox.Text;
            stock.CategoryName = categoryTextBox.Text;
            stockDataGridView.DataSource = _stockManager.SearchByChar(stock);
        }

        private void categoryTextBox_TextChanged(object sender, EventArgs e)
        {
            Stocks stock = new Stocks();

            stock.ProductName = productTextBox.Text;
            stock.CategoryName = categoryTextBox.Text;
            stockDataGridView.DataSource = _stockManager.SearchByChar(stock);
        }
    }
}
