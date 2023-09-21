using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BillingSystem.BLL;
using BillingSystem.BLL.DAL;

namespace BillingSystem.UI
{
    public partial class frmUsers : Form
    {
        public frmUsers()
        {
            InitializeComponent();
        }

        userBLL u = new userBLL();
        userDAL dal = new userDAL();



        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
   
            //Getting data from UI
            u.FirstName = textBoxFirstName.Text;
            u.LastName = textBoxLastName.Text;
            u.Email = textBoxEmail.Text;
            u.Username = textBoxUserName.Text;
            u.Password = textBoxPassword.Text;
            u.Contact = textBoxContact.Text;
            u.Address = textBoxAddress.Text;
            u.Gender = comboBoxGender.Text;
            u.UserType = comboBoxUserType.Text;
            u.AddedDate = DateTime.Now;

            //Getting the user ID of the logged in user
            String loggedUser = frmLogin.loggedin;
            userBLL usr = dal.GetIDFromUserName(loggedUser);

            u.AddedBy = usr.ID;



            //Inserting into database
            bool isSuccess = dal.Insert(u);
            if (isSuccess == true)
            {
                MessageBox.Show("New User created successfully");
                Clear();
            }
            else
            {
                MessageBox.Show("Failed to create new user");
            }

            //Refersh the data grid view to show updated user list
            DataTable dt = dal.Select();
            dataGridViewUser.DataSource = dt;
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUsers_Load(object sender, EventArgs e)
        {
            DataTable dt = dal.Select();
            dataGridViewUser.DataSource = dt;
        }
        public void Clear()
        {
            textBoxUserID.Text = "";
            textBoxUserName.Text = "";
            textBoxFirstName.Text = "";
            textBoxLastName.Text = "";
            textBoxEmail.Text = "";
            textBoxContact.Text = "";
            textBoxPassword.Text = "";
            comboBoxGender.Text = "";
            comboBoxUserType.Text = "";
            textBoxAddress.Text = "";
        }

        private void dataGridViewUser_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            //Loading data from data grid view to text field
            int rowIndex = e.RowIndex;
            textBoxUserID.Text = dataGridViewUser.Rows[rowIndex].Cells[0].Value.ToString();
            textBoxFirstName.Text = dataGridViewUser.Rows[rowIndex].Cells[1].Value.ToString();
            textBoxLastName.Text = dataGridViewUser.Rows[rowIndex].Cells[2].Value.ToString();
            textBoxEmail.Text = dataGridViewUser.Rows[rowIndex].Cells[3].Value.ToString();
            textBoxUserName.Text = dataGridViewUser.Rows[rowIndex].Cells[4].Value.ToString();
            textBoxPassword.Text = dataGridViewUser.Rows[rowIndex].Cells[5].Value.ToString();
            textBoxContact.Text = dataGridViewUser.Rows[rowIndex].Cells[6].Value.ToString();
            textBoxAddress.Text = dataGridViewUser.Rows[rowIndex].Cells[7].Value.ToString();
            comboBoxGender.Text = dataGridViewUser.Rows[rowIndex].Cells[8].Value.ToString();
            comboBoxUserType.Text = dataGridViewUser.Rows[rowIndex].Cells[9].Value.ToString();

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            //Getting data from UI
            u.ID = Convert.ToInt32(textBoxUserID.Text);
            u.FirstName = textBoxFirstName.Text;
            u.LastName = textBoxLastName.Text;
            u.Email = textBoxEmail.Text;
            u.Username = textBoxUserName.Text;
            u.Password = textBoxPassword.Text;
            u.Contact = textBoxContact.Text;
            u.Address = textBoxAddress.Text;
            u.Gender = comboBoxGender.Text;
            u.UserType = comboBoxUserType.Text;
            u.AddedDate = DateTime.Now;

            //Updating data in database
            bool isSuccess = dal.Update(u);
            if (isSuccess == true)
            {
                MessageBox.Show("User Updated successfully");
                Clear();
            }
            else
            {
                MessageBox.Show("Failed to update user");
            }

            //Refersh the data grid view to show updated user list
            DataTable dt = dal.Select();
            dataGridViewUser.DataSource = dt;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Getting data from UI
            u.ID = Convert.ToInt32(textBoxUserID.Text);

            //Delete data from database
            bool isSuccess = dal.Delete(u);
            if (isSuccess == true)
            {
                MessageBox.Show("User Deleted successfully");
                Clear();
            }
            else
            {
                MessageBox.Show("Failed to Delete user");
            }

            //Refersh the data grid view to show updated user list
            DataTable dt = dal.Select();
            dataGridViewUser.DataSource = dt;
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            String keyword = textBoxSearch.Text;
            if (keyword != null)
            {
                DataTable dt = dal.Search(keyword);
                dataGridViewUser.DataSource = dt;
            }
            else
            {
                DataTable dt = dal.Select();
                dataGridViewUser.DataSource = dt;
            }
            
        }
 

    }
}
