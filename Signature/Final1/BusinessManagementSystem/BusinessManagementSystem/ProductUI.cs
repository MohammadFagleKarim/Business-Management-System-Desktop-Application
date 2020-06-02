using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using BusinessManagementSystem.Model;
using BusinessManagementSystem.Manager;

namespace BusinessManagementSystem
{
    public partial class ProductUI : Form
    {
        string Id;
        ProductManager _ProductManager = new ProductManager();
        public ProductUI()
        {
            InitializeComponent();
            showDataGridView.DataSource = _ProductManager.Display();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            //Set Code as Mandatory
            if (String.IsNullOrEmpty(categoryComboBox.Text))
            {
                MessageBox.Show("Category should not be empty!");
                return;
            }

            //Set Code as Mandatory
            if (String.IsNullOrEmpty(codeTextBox.Text))
            {
                MessageBox.Show("Code should not be empty!");
                return;
            }

            //Set Name as Mandatory
            if (String.IsNullOrEmpty(nameTextBox.Text))
            {
                MessageBox.Show("Name should not be empty!");
                return;
            }

            //Set ReOrderLevel as Mandatory
            if (String.IsNullOrEmpty(reorderlevelTextBox.Text))
            {
                MessageBox.Show("ReOrderLevel should not be empty!");
                return;
            }

            //Set Description as Mandatory
            if (String.IsNullOrEmpty(descriptionTextBox.Text))
            {
                MessageBox.Show("Description should not be empty!");
                return;
            }

            //Length check
            if (codeTextBox.Text.Length != 4)
            {
                MessageBox.Show("Code must be 4 digit!!!");
                return;
            }

            
            product.Category = categoryComboBox.SelectedText;
            product.CategoryId = Convert.ToInt32(categoryComboBox.SelectedValue);
            product.Code = codeTextBox.Text;
            product.Name = nameTextBox.Text;
            product.ReorderLevel = reorderlevelTextBox.Text;
            product.Description = descriptionTextBox.Text;

            if (saveButton.Text == "Save")
            {
                //Check UNIQUE
                if (_ProductManager.IsCodeExists(product))
                {
                    MessageBox.Show(codeTextBox.Text + " already exists!");
                    return;
                }

                if (_ProductManager.IsNameExists(product))
                {
                    MessageBox.Show(codeTextBox.Text + " already exists!");
                    return;
                }
                if (Convert.ToInt32(reorderlevelTextBox.Text) < 0)
                {
                    MessageBox.Show(" Reorder Level should be Positive!");
                    return;
                }

                if (categoryComboBox.Text == "-Select-")
                {
                    MessageBox.Show("Select a category");
                    return;
                }

                bool added = _ProductManager.Add(product);

                if (added)
                {
                    MessageBox.Show("Saved");
                    Clear();
                }
                else
                {
                    MessageBox.Show("Not Saved");
                }

                showDataGridView.DataSource = _ProductManager.Display();

            }
            else
            {
                product.Id = Convert.ToInt32(Id);
                bool isUpdated = _ProductManager.Edit(product);

                if (isUpdated)
                {
                    MessageBox.Show("Updated");

                    Clear();
                }
                else
                {
                    MessageBox.Show("Not Updated");
                }
                showDataGridView.DataSource = _ProductManager.Display();
            }


           
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
          
            if (String.IsNullOrEmpty(searchTextBox.Text))
            {
                showDataGridView.DataSource = _ProductManager.Display();

            }
            else
            {
                showDataGridView.DataSource = _ProductManager.Search(searchTextBox.Text);
            }
        }

        private void ProductUI_Load(object sender, EventArgs e)
        {
            categoryComboBox.DataSource = _ProductManager.CategoryCombo();
            categoryComboBox.Text = "-Select-";
        }

        private void ShowDataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            showDataGridView.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        public void Clear()
        {
            categoryComboBox.Text = "-Select-";
            codeTextBox.Clear();
            nameTextBox.Clear();
            reorderlevelTextBox.Clear();
            descriptionTextBox.Clear();
        }

        private void showDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Product product = new Product();
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.showDataGridView.Rows[e.RowIndex];
                Id = row.Cells[0].Value.ToString();
                codeTextBox.Text = row.Cells[2].Value.ToString();
                nameTextBox.Text = row.Cells[3].Value.ToString();
                categoryComboBox.Text = row.Cells[4].Value.ToString();
                reorderlevelTextBox.Text = row.Cells[5].Value.ToString();
                descriptionTextBox.Text = row.Cells[6].Value.ToString();
                product.CategoryId = Convert.ToInt32(categoryComboBox.SelectedValue);
                saveButton.Text = "Update";


            }
            showDataGridView.DataSource = _ProductManager.Display();
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            showDataGridView.DataSource = _ProductManager.SearchByChar(searchTextBox.Text);

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
