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
    public partial class ReportOnSales : Form
    {
        StockManager _stockManager = new StockManager();
        public ReportOnSales()
        {
            InitializeComponent();
            reportOnSaleDataGridView.DataSource = _stockManager.Display();
        }

        private void homeButton_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            this.Hide();
            home.Show();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void startEndSearchButton_Click(object sender, EventArgs e)
        {
            Stocks stock = new Stocks();

            
            stock.StartDate = startDateTimePicker.Value;
            stock.EndDate = startDateTimePicker.Value;

            reportOnSaleDataGridView.DataSource = _stockManager.Search(stock);
        }

        private void reportOnPurchaseDataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            reportOnSaleDataGridView.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }
    }
}
