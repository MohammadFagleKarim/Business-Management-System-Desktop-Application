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
    public partial class SupplierUi : Form
    {
        string Id;
        SupplierManager _supplierManager = new SupplierManager();
        public SupplierUi()
        {
            InitializeComponent();
            showDataGridView.DataSource = _supplierManager.Display();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Supplier supplier = new Supplier();

            //Set as Mandatory
            if (String.IsNullOrEmpty(codeTextBox.Text))
            {
                MessageBox.Show("Code Can not be Empty!!!");
                return;
            }

            if (String.IsNullOrEmpty(nameTextBox.Text))
            {
                MessageBox.Show("Name Can not be Empty!!!");
                return;

            }

            if (String.IsNullOrEmpty(contactTextBox.Text))
            {
                MessageBox.Show("Contact Can not be Empty!!!");
                return;

            }

            if (String.IsNullOrEmpty(emailTextBox.Text))
            {
                MessageBox.Show("Email Can not be Empty!!!");
                return;

            }

            //Length check
            if (codeTextBox.Text.Length != 4)
            {
                MessageBox.Show("Code must be 4 digit!!!");
                return;
            }

            supplier.Code = codeTextBox.Text;
            supplier.Name = nameTextBox.Text;
            supplier.Address = addressTextBox.Text;
            supplier.Email = emailTextBox.Text;
            supplier.Contact = contactTextBox.Text;
            supplier.ContactPerson = contactpersonTextBox.Text;

            if (saveButton.Text == "Save")
            {
                //Check UNIQUE

                if (_supplierManager.IsCodeExists(supplier))
                {
                    MessageBox.Show(codeTextBox.Text + " Already Exists!");
                    return;
                }

                if (_supplierManager.IsContactExists(supplier))
                {
                    MessageBox.Show(contactTextBox.Text + " Already Exists!");
                    return;
                }

                if (_supplierManager.IsEmailExists(supplier))
                {
                    MessageBox.Show(emailTextBox.Text + " Already Exists!");
                    return;
                }


                bool isAdded = _supplierManager.Add(supplier);

                if (isAdded)
                {
                    MessageBox.Show("Saved");
                    Clear();
                }
                else

                {
                    MessageBox.Show("Not Saved");
                }

                showDataGridView.DataSource = _supplierManager.Display();
            }

            

            else
            {
                supplier.Id = Convert.ToInt32(Id);
                bool isUpdated = _supplierManager.Edit(supplier);

                if (isUpdated)
                {
                    MessageBox.Show("Updated");

                    Clear();
                }
                else
                {
                    MessageBox.Show("Not Updated");
                }
                showDataGridView.DataSource = _supplierManager.Display();
                
            }

        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(searchTextBox.Text))
            {
                showDataGridView.DataSource = _supplierManager.Search(searchTextBox.Text);

            }
            else
            {
                showDataGridView.DataSource = _supplierManager.Search(searchTextBox.Text);
            }
            
        }


        public void Clear()
        {
            codeTextBox.Clear();
            nameTextBox.Clear();
            addressTextBox.Clear();
            emailTextBox.Clear();
            addressTextBox.Clear();
            contactTextBox.Clear();
            contactpersonTextBox.Clear();

        }

        private void ShowDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Supplier supplier = new Supplier();
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.showDataGridView.Rows[e.RowIndex];
                Id = row.Cells[1].Value.ToString();
                codeTextBox.Text = row.Cells[2].Value.ToString();
                nameTextBox.Text = row.Cells[3].Value.ToString();
                addressTextBox.Text = row.Cells[4].Value.ToString();
                emailTextBox.Text = row.Cells[5].Value.ToString();
                contactTextBox.Text = row.Cells[6].Value.ToString();
                contactpersonTextBox.Text = row.Cells[7].Value.ToString();
                saveButton.Text = " Update ";


            }
            showDataGridView.DataSource = _supplierManager.Display();
        }

        private void showDataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            showDataGridView.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            showDataGridView.DataSource = _supplierManager.SearchByChar(searchTextBox.Text);

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
    }
}
