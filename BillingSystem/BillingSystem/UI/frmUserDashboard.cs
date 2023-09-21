using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BillingSystem.UI;

namespace BillingSystem
{
    public partial class frmUserDashboard : Form
    {
        public frmUserDashboard()
        {
            InitializeComponent();
        }

        private void frmUserDashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmLogin login = new frmLogin();
            login.Show();
            this.Hide();

        }

        private void frmUserDashboard_Load(object sender, EventArgs e)
        {
            lblUserloggedin.Text = frmLogin.loggedin;
        }
    }
}
