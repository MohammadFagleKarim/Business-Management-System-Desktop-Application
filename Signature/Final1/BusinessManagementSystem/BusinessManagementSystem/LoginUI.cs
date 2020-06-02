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
    public partial class LoginUI : Form
    {
        static int attempt = 2;
        LoginManager _loginManager = new LoginManager();

        public LoginUI()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (attempt <= 0)
            {
                Application.Exit();

            }

            if (String.IsNullOrEmpty(usernameTextBox.Text))
            {
                MessageBox.Show("Enter an username");
                return;
            }

            if (String.IsNullOrEmpty(passwordTextBox.Text))
            {
                MessageBox.Show("Enter an password");
                return;
            }

            Login login = new Login();

            login.Username = usernameTextBox.Text;
            login.Password = passwordTextBox.Text;


            if (_loginManager.Login(login))
            {
                Home home = new Home();
                this.Hide();
                home.Show();
            }
            else

            {

                noteLabel.Text = ("You Have Only " + Convert.ToString(attempt) + " Attempt Left To Try");
                --attempt;
                usernameTextBox.Clear();
                passwordTextBox.Clear();
            }

        }

        private void hideCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (hideCheckBox.Checked == true)
            {
                passwordTextBox.UseSystemPasswordChar = true;
            }
            else
            {
                passwordTextBox.UseSystemPasswordChar = false;
            }
        }
    }
}
