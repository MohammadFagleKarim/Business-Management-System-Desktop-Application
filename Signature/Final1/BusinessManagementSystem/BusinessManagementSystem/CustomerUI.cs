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
    public partial class CustomerUI : Form
    {
        string Id;
        CustomerManager _customerManager = new CustomerManager();
        public CustomerUI()
        {
            InitializeComponent();
            loyalityTextBox.ReadOnly = true;
            showDataGridView.DataSource = _customerManager.Display();
        }

      

        private void saveButton_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();

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
            if (String.IsNullOrEmpty(addressTextBox.Text))
            {
                MessageBox.Show("Address Can not be Empty!!!");
                return;
            }
            if (String.IsNullOrEmpty(emailTextBox.Text))
            {
                MessageBox.Show("Email Can not be Empty!!!");
                return;
            }
            if (String.IsNullOrEmpty(contactTextBox.Text))
            {
                MessageBox.Show("Contact Can not be Empty!!!");
                return;
            }


            //Length check
            if (codeTextBox.Text.Length != 4)
            {
                MessageBox.Show("Code must be 4 digit!!!");
                return;
            }

            customer.Code = codeTextBox.Text;
            customer.Name = nameTextBox.Text;
            customer.Address = addressTextBox.Text;
            customer.Email = emailTextBox.Text;
            customer.Contact = contactTextBox.Text;
            customer.LoyalityPoint = 0;
            
            if (saveButton.Text == "Save")
            {
                if (_customerManager.IsCodeExists(customer))
                {
                    MessageBox.Show(codeTextBox.Text + " Already Exists!");
                    return;
                }

                if (_customerManager.IsNameExists(customer))
                {
                    MessageBox.Show(nameTextBox.Text + " Already Exists!");
                    return;
                }
                if (_customerManager.IsContactExists(customer))
                {
                    MessageBox.Show(contactTextBox.Text + " Already Exists!");
                    return;
                }

                if (_customerManager.IsEmailExists(customer))
                {
                    MessageBox.Show(emailTextBox.Text + " Already Exists!");
                    return;
                }

                bool isAdded = _customerManager.Add(customer);

                if (isAdded)
                {
                    MessageBox.Show("Saved");
                    Clear();
                }
                else
                {
                    MessageBox.Show("Not Saved");
                }
                showDataGridView.DataSource = _customerManager.Display();

            }
            else
            {
                customer.Id = Convert.ToInt32(Id);
                bool isUpdated = _customerManager.Edit(customer);

                if (isUpdated)
                {
                    MessageBox.Show("Updated");
                    Clear();
                }
                else
                {
                    MessageBox.Show("Not Updated");
                }

                showDataGridView.DataSource = _customerManager.Display();
            }
        }

        private void ShowDataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            showDataGridView.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void showDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Customer customer = new Customer();
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.showDataGridView.Rows[e.RowIndex];
                Id = row.Cells[1].Value.ToString();
                codeTextBox.Text = row.Cells[2].Value.ToString();
                nameTextBox.Text = row.Cells[3].Value.ToString();
                addressTextBox.Text = row.Cells[4].Value.ToString();
                emailTextBox.Text = row.Cells[5].Value.ToString();
                contactTextBox.Text = row.Cells[6].Value.ToString();
                saveButton.Text = " Update ";
            }
            showDataGridView.DataSource = _customerManager.Display();
        }
        public void Clear()
        {
            codeTextBox.Clear();
            nameTextBox.Clear();
            addressTextBox.Clear();
            emailTextBox.Clear();
            contactTextBox.Clear();
            loyalityTextBox.Clear();
        }

        

        private void backwardButton_Click(object sender, EventArgs e)
        {

        }

        private void searchButton_Click_1(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(searchTextBox.Text))
            {
                showDataGridView.DataSource = _customerManager.Display();

            }
            else
            {
                showDataGridView.DataSource = _customerManager.Search(searchTextBox.Text);
            }
        }

        private void searchTextBox_TextChanged_1(object sender, EventArgs e)
        {
            showDataGridView.DataSource = _customerManager.SearchByChar(searchTextBox.Text);
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
