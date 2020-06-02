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
    public partial class CategoryUI : Form
    {
        string Id;
        CategoryManager _categoryManager = new CategoryManager();

        public CategoryUI()
        {
            
            InitializeComponent();
            showDataGridView.DataSource = _categoryManager.Display();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Category category = new Category();

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

            //Length check
            if (codeTextBox.Text.Length != 4)
            {
                MessageBox.Show("Code must be 4 digit!!!");
                return;
            }

            category.Code = codeTextBox.Text;
            category.Name = nameTextBox.Text;
            
            if (saveButton.Text == "Save")
            {
                //Check UNIQUE
                if (_categoryManager.IsCodeExists(category))
                {
                    MessageBox.Show(codeTextBox.Text + " Already Exists!");
                    return;
                }

                if (_categoryManager.IsNameExists(category))
                {
                    MessageBox.Show(nameTextBox.Text + " Already Exists!");
                    return;
                }

                bool isAdded = _categoryManager.Add(category);

                if (isAdded)
                {
                    MessageBox.Show("Saved");
                    
                    Clear();
                }
                else

                {
                    MessageBox.Show("Not Saved");

                }

                showDataGridView.DataSource = _categoryManager.Display();
            }
            else
            {
                category.Id = Convert.ToInt32(Id);

                bool isUpdated = _categoryManager.Edit(category);

                if (isUpdated)
                {
                    MessageBox.Show("Updated");                    
                   
                    Clear();
                }
                else
                {
                    MessageBox.Show("Not Updated");
                }
                showDataGridView.DataSource = _categoryManager.Display();
            }
        }
        
        private void searchButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(searchTextBox.Text))
            {
                showDataGridView.DataSource = _categoryManager.Display();
                
            }
            else
            {
                showDataGridView.DataSource = _categoryManager.Search(searchTextBox.Text);
            }
        }

        private void ShowDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Category category = new Category();
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.showDataGridView.Rows[e.RowIndex];
                Id = row.Cells[1].Value.ToString();
                codeTextBox.Text = row.Cells[2].Value.ToString();
                nameTextBox.Text = row.Cells[3].Value.ToString();
                saveButton.Text = "Update";
            }
            showDataGridView.DataSource = _categoryManager.Display();
        }

        private void ShowDataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            showDataGridView.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        public void Clear()
        {
            codeTextBox.Clear();
            nameTextBox.Clear();
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {

            showDataGridView.DataSource = _categoryManager.SearchByChar(searchTextBox.Text);

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
    }
}
