using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BillingSystem.BLL;
using BillingSystem.DAL;

namespace BillingSystem.UI
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        LoginBLL lb = new LoginBLL();
        LoginDAL dal = new LoginDAL();
        public static String loggedin;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //Get the credentials from text filed
            lb.Username = textBoxUserName.Text.Trim();
            lb.Password = textBoxPassword.Text.Trim();
            lb.UserType = comboBoxUserType.Text.Trim();

            //Checking the login credentials
            bool success = dal.loginCheck(lb);

            if (success == true)
            {
                //Loging successful
                MessageBox.Show("Loing Successful");
                loggedin = lb.Username;
                switch (lb.UserType)
                {
                    case "Admin":
                        { 
                            //Display admin dashboard
                            frmAdminDashboard admin = new frmAdminDashboard();
                            admin.Show();
                            this.Hide();
                        }
                        break;
                    case "User":
                        { 
                            //Display user dashboard
                            frmUserDashboard user = new frmUserDashboard();
                            user.Show();
                            this.Hide();
                        }
                        break;
                    default:
                        {
                            //Display an error messeage
                            MessageBox.Show("Invalid User Type");
                        }
                        break;
                }
            }
            else
            {
                //Loging failed
                MessageBox.Show("Login Failed. Try again!!");
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
