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
    public partial class LoadingUI : Form
    {
        public LoadingUI()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();
            loadingProgressBar.Increment(1);
            if (loadingProgressBar.Value == 100)
            {
                timer1.Stop();
                LoginUI Login = new LoginUI();
                this.Hide();
                Login.Show();
            }
        }
    }
}
