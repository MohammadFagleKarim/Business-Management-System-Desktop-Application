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
    public partial class PurchasessUI : Form
    {
        PurchaseManager _PurchaseManager = new PurchaseManager();

        int purchaseQuantity;
        //int availableQuantity;

        public PurchasessUI()
        {
            InitializeComponent();

            codeTextBox.ReadOnly = true;
            availableQuantityTextBox.ReadOnly = true;
            totalPriceTextBox.ReadOnly = true;
            previousUnitPriceTextBox.ReadOnly = true;
            previousMRPTextBox.ReadOnly = true;
        }

        List<PurchaseItems> purchaseItems;

        private void addButton_Click(object sender, EventArgs e)
        {
            //Set Category as Mandatory
            if (String.IsNullOrEmpty(categoryComboBox.Text))
            {
                MessageBox.Show("Category should not be empty!");
                return;
            }

            //Set Products as Mandatory
            if (String.IsNullOrEmpty(productsComboBox.Text))
            {
                MessageBox.Show("Products should not be empty!");
                return;
            }

            //Set Manufactured Date as Mandatory
            if (String.IsNullOrEmpty(manufactureDateTimePicker.Text))
            {
                MessageBox.Show("Manufactured Date should not be empty!");
                return;
            }

            //Set Expired Date as Mandatory
            if (String.IsNullOrEmpty(expireDateTimePicker.Text))
            {
                MessageBox.Show("Expired Date should not be empty!");
                return;
            }

            //Set Quantity as Mandatory
            if (String.IsNullOrEmpty(quantityTextBox.Text))
            {
                MessageBox.Show("Quantity should not be empty!");
                return;
            }

            //Set Unit Price as Mandatory
            if (String.IsNullOrEmpty(unitPriceTextBox.Text))
            {
                MessageBox.Show("Unit Price should not be empty!");
                return;
            }

            //Set MRP as Mandatory
            if (String.IsNullOrEmpty(mrpTextBox.Text))
            {
                MessageBox.Show("MRP should not be empty!");
                return;
            }

            if (categoryComboBox.Text == "-Select-")
            {
                MessageBox.Show("Select a category");
                return;
            }

            if (productsComboBox.Text == "-Select-")
            {
                MessageBox.Show("Select a product");
                return;
            }
            
            Purchase purchase = new Purchase();
            PurchaseItems purchaseItem = new PurchaseItems();

            purchaseItem.CategoryId = Convert.ToInt32(categoryComboBox.SelectedValue);
            purchaseItem.ProductId = Convert.ToInt32(productsComboBox.SelectedValue);
            purchaseItem.AvailableQuantity = Convert.ToInt32(availableQuantityTextBox.Text);
            purchaseItem.ManufacturedDate = (manufactureDateTimePicker.Text);
            purchaseItem.ExpireDate = (expireDateTimePicker.Text);
            purchaseItem.Quantity = Convert.ToInt32(quantityTextBox.Text);
            purchaseItem.UnitPrice = float.Parse(unitPriceTextBox.Text);
            purchaseItem.TotalPrice = float.Parse(totalPriceTextBox.Text);
            purchaseItem.PreviousUnitPrice = float.Parse(previousUnitPriceTextBox.Text);
            purchaseItem.PreviousMRP = float.Parse(previousMRPTextBox.Text);
            purchaseItem.MRP = float.Parse(mrpTextBox.Text);
            purchaseItem.Remarks = remarksTextBox.Text;

            //Check UNIQUE

            if (_PurchaseManager.IsInvoiceNoExists(purchase))
            {
                MessageBox.Show(billInvoiceNoTextBox.Text + " Already Exists!");
                return;
            }

            //Check UNIQUE

            if (_PurchaseManager.IsCodeExists(purchase))
            {
                MessageBox.Show(codeTextBox.Text + " Already Exists!");
                return;
            }

            if (purchaseItems == null)
            {
                purchaseItems = new List<PurchaseItems>();

            }

            purchaseItems.Add(purchaseItem);

            MessageBox.Show(" Saved");

            showDataGridView.DataSource = null;
            showDataGridView.DataSource = purchaseItems;
        }

        private void PurchasessUI_Load(object sender, EventArgs e)
        {
            supplierComboBox.DataSource = _PurchaseManager.SupplierComboLoad();
            supplierComboBox.Text = "-Select-";

            categoryComboBox.DataSource = _PurchaseManager.CategoryComboLoad();
            categoryComboBox.Text = "-Select-";

            productsComboBox.DataSource = _PurchaseManager.ProductComboLoad(Convert.ToInt32(categoryComboBox.SelectedValue));
            productsComboBox.Text = "-Select-";
        }

        private void supplierComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            supplierComboBox.DataSource = null;
            supplierComboBox.DataSource = _PurchaseManager.SupplierComboLoad();
            supplierComboBox.DisplayMember = "Name";
            supplierComboBox.ValueMember = "Id";
        }

        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            productsComboBox.DataSource = null;
            productsComboBox.DataSource = _PurchaseManager.ProductComboLoad(Convert.ToInt32(categoryComboBox.SelectedValue));
            productsComboBox.DisplayMember = "Name";
            productsComboBox.ValueMember = "Id";
        }


        private void CodeLoad()
        {
            Product product = new Product();
            product.Name = productsComboBox.Text;
            codeTextBox.Text = null;
            codeTextBox.Text = _PurchaseManager.LoadProductCode(product);
        }

        private int GetPurchaseQuantity()
        {
            PurchaseItems purchase_ = new PurchaseItems();

            purchase_.CategoryId = Convert.ToInt32(categoryComboBox.SelectedValue);
            purchase_.ProductId = Convert.ToInt32(productsComboBox.SelectedValue);

            purchaseQuantity = _PurchaseManager.LoadPurchaseQuantity(purchase_);

            return purchaseQuantity;
        }

        private void GetTotalAvailableQuantity()
        {
            //availableQuantityTextBox.Text = null;

            int quantity = GetPurchaseQuantity();

            PurchaseItems purchase_ = new PurchaseItems();

            purchase_.CategoryId = Convert.ToInt32(categoryComboBox.SelectedValue);
            purchase_.ProductId = Convert.ToInt32(productsComboBox.SelectedValue);

            int avail = _PurchaseManager.AvailableQuantity(purchase_);

            int totalQuantity = avail + quantity;

            //availableQuantity = availableQuantity + totalQuantity;

            availableQuantityTextBox.Text = totalQuantity.ToString();
        }

        private void PreviousUnitPriceLoad()
        {
            PurchaseItems purchaseItems = new PurchaseItems();
            purchaseItems.CategoryId = Convert.ToInt32(categoryComboBox.SelectedValue);
            purchaseItems.ProductId = Convert.ToInt32(productsComboBox.SelectedValue);
            previousUnitPriceTextBox.Text = null;
            previousUnitPriceTextBox.Text = _PurchaseManager.LoadPreviousUnitPrice(purchaseItems) + "";
        }

        private void PreviousMrpLoad()
        {
            PurchaseItems purchaseItems = new PurchaseItems();
            purchaseItems.CategoryId = Convert.ToInt32(categoryComboBox.SelectedValue);
            purchaseItems.ProductId = Convert.ToInt32(productsComboBox.SelectedValue);
            previousMRPTextBox.Text = null;
            previousMRPTextBox.Text = _PurchaseManager.LoadPreviousMrp(purchaseItems) + "";
        }

        private void productsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CodeLoad();
            GetTotalAvailableQuantity();
            PreviousUnitPriceLoad();
            PreviousMrpLoad();
        }

        private void purchaseDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            purchaseDateTimePicker.CustomFormat = "MM/dd/yyyy";
        }

        private void manufactureDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            manufactureDateTimePicker.CustomFormat = "MM/dd/yyyy";
        }

        private void expireDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            expireDateTimePicker.CustomFormat = "MM/dd/yyyy";
        }

        private void unitPriceTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(quantityTextBox.Text) && !String.IsNullOrEmpty(unitPriceTextBox.Text))
            {
                totalPriceTextBox.Text = (int.Parse(quantityTextBox.Text) * double.Parse(unitPriceTextBox.Text)) + "";
            }

            if (!String.IsNullOrEmpty(quantityTextBox.Text) && !String.IsNullOrEmpty(unitPriceTextBox.Text))
            {
                double unitPrice = double.Parse(unitPriceTextBox.Text);
                mrpTextBox.Text = (unitPrice + ((unitPrice * 25) / 100)) + "";
            }
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

        private void submitButton_Click(object sender, EventArgs e)
        {
            if (supplierComboBox.Text == "-Select-")
            {
                MessageBox.Show("Select a supplier.");
                return;
            }

            //Set Supplier Date as Mandatory
            if (String.IsNullOrEmpty(purchaseDateTimePicker.Text))
            {
                MessageBox.Show("Date should not be empty!");
                return;
            }

            //Set Bill/ Invoice No. as Mandatory
            if (String.IsNullOrEmpty(billInvoiceNoTextBox.Text))
            {
                MessageBox.Show("Bill/ Invoice No. should not be empty!");
                return;
            }

            //Set Supplier as Mandatory
            if (String.IsNullOrEmpty(supplierComboBox.Text))
            {
                MessageBox.Show("Supplier should not be empty!");
                return;
            }

            showDataGridView.DataSource = null;

            Purchase purchase = new Purchase();

            purchase.Date = purchaseDateTimePicker.Text;
            purchase.Bill = billInvoiceNoTextBox.Text;
            purchase.SupplierId = Convert.ToInt32(supplierComboBox.SelectedValue);
            purchase.Code = codeTextBox.Text;

            bool isSupplierSubmited = _PurchaseManager.SubmitSupplierInfo(purchase);

            if (isSupplierSubmited)
            {
                MessageBox.Show("Supplier Info Saved");

                billInvoiceNoTextBox.Clear();
                supplierComboBox.Text = "-Select-";
            }
            else
            {
                MessageBox.Show("Supplier Info Not Saved");
            }

            foreach (PurchaseItems purchaseItem in purchaseItems)
            {
                categoryComboBox.SelectedValue = purchaseItem.CategoryId;
                productsComboBox.SelectedValue = purchaseItem.ProductId;
                availableQuantityTextBox.Text = purchaseItem.AvailableQuantity.ToString();
                manufactureDateTimePicker.Text = purchaseItem.ManufacturedDate;
                expireDateTimePicker.Text = purchaseItem.ExpireDate;
                quantityTextBox.Text = purchaseItem.Quantity.ToString();
                unitPriceTextBox.Text = purchaseItem.UnitPrice.ToString();
                totalPriceTextBox.Text = purchaseItem.TotalPrice.ToString();
                previousUnitPriceTextBox.Text = purchaseItem.PreviousUnitPrice.ToString();
                previousMRPTextBox.Text = purchaseItem.PreviousMRP.ToString();
                mrpTextBox.Text = purchaseItem.MRP.ToString();
                remarksTextBox.Text = purchaseItem.Remarks;


                purchaseItem.CategoryId = Convert.ToInt32(categoryComboBox.SelectedValue);
                purchaseItem.ProductId = Convert.ToInt32(productsComboBox.SelectedValue);
                purchaseItem.PurchaseId = _PurchaseManager.SearchPurchaseId(purchase);
                purchaseItem.AvailableQuantity = Convert.ToInt32(availableQuantityTextBox.Text);
                purchaseItem.ManufacturedDate = (manufactureDateTimePicker.Text);
                purchaseItem.ExpireDate = (expireDateTimePicker.Text);
                purchaseItem.Quantity = Convert.ToInt32(quantityTextBox.Text);
                purchaseItem.UnitPrice = float.Parse(unitPriceTextBox.Text);
                purchaseItem.TotalPrice = float.Parse(totalPriceTextBox.Text);
                purchaseItem.PreviousUnitPrice = float.Parse(previousUnitPriceTextBox.Text);
                purchaseItem.PreviousMRP = float.Parse(previousMRPTextBox.Text);
                purchaseItem.MRP = float.Parse(mrpTextBox.Text);
                purchaseItem.Remarks = remarksTextBox.Text;

                bool isPurchaseSubmited = _PurchaseManager.SubmitPurchaseItemsInfo(purchaseItem);

                if (isPurchaseSubmited)
                {
                    MessageBox.Show("Purchase Items Info Saved");

                    categoryComboBox.Text = "-Select-";
                    productsComboBox.Text = "-Select-";
                    codeTextBox.Clear();
                    availableQuantityTextBox.Clear();
                    remarksTextBox.Clear();
                    quantityTextBox.Clear();
                    unitPriceTextBox.Clear();
                    totalPriceTextBox.Clear();
                    previousUnitPriceTextBox.Clear();
                    previousMRPTextBox.Clear();
                    mrpTextBox.Clear();
                }
                else
                {
                    MessageBox.Show("Purchase Items Info Not Saved");
                }

                showDataGridView.DataSource = _PurchaseManager.Display();
            }
        }

        private void showDataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            showDataGridView.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {

        }

        private void showDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PurchaseItems purchaseItems = new PurchaseItems();
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.showDataGridView.Rows[e.RowIndex];
                categoryComboBox.Text = row.Cells[1].Value.ToString();
                productsComboBox.Text = row.Cells[2].Value.ToString();
                manufactureDateTimePicker.Text = row.Cells[3].Value.ToString();
                expireDateTimePicker.Text = row.Cells[4].Value.ToString();
                quantityTextBox.Text = row.Cells[5].Value.ToString();
                unitPriceTextBox.Text = row.Cells[6].Value.ToString();
                remarksTextBox.Text = row.Cells[7].Value.ToString();
                addButton.Text = " Update ";
            }
            showDataGridView.DataSource = _PurchaseManager.Display();
        }
    }
}
