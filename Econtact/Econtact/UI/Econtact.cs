using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Econtact.DataAccess;
using System.Data.SqlClient;

namespace Econtact
{
    public partial class Econtact : Form
    {

        EcontactDataAccess c = new EcontactDataAccess();
        

        public Econtact()
        {
            InitializeComponent();
        }

        private void Econtact_Load(object sender, EventArgs e)
        {
            //Show data on data grid view
            DataTable dt = c.Select();
            dgvContactList.DataSource = dt;
            clear();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Get the value from input field
            c.FirstName = textBoxFirstName.Text;
            c.LastName = textBoxLastName.Text;
            c.ContactNo = textBoxContactNo.Text;
            c.Address = textBoxAddress.Text;
            c.Gender = cmbGender.Text;
            //Inserting data into our database using the method we created



            bool succes = c.Insert(c);
            if (succes == true)
            {
                MessageBox.Show("New Contact Successfully Inserted");
            }
            else
            {
                MessageBox.Show("Failed to insert new Contact");
            }
            //Show data on data grid view
            DataTable dt = c.Select();
            dgvContactList.DataSource = dt;

            //Clear data field
            clear();
        }

        public void clear()
        {
            textBoxContactID.Text = "";
            textBoxFirstName.Text = "";
            textBoxLastName.Text = "";
            textBoxContactNo.Text = "";
            textBoxAddress.Text = "";
            cmbGender.Text = "";
        }

        private void textBoxContactID_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvContactList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Get the data from data grid view and load it to the textboxes respectively
            //Identify the row on which mouse is clicked
            int rowIndex = e.RowIndex;
            textBoxContactID.Text = dgvContactList.Rows[rowIndex].Cells[0].Value.ToString();
            textBoxFirstName.Text = dgvContactList.Rows[rowIndex].Cells[1].Value.ToString();
            textBoxLastName.Text = dgvContactList.Rows[rowIndex].Cells[2].Value.ToString();
            textBoxContactNo.Text = dgvContactList.Rows[rowIndex].Cells[3].Value.ToString();
            textBoxAddress.Text = dgvContactList.Rows[rowIndex].Cells[4].Value.ToString();
            cmbGender.Text = dgvContactList.Rows[rowIndex].Cells[5].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Get the data from text box
            c.ContactID = int.Parse(textBoxContactID.Text);
            c.FirstName = textBoxFirstName.Text;
            c.LastName = textBoxLastName.Text;
            c.ContactNo = textBoxContactNo.Text;
            c.Address = textBoxAddress.Text;
            c.Gender = cmbGender.Text;

            //Update data in database
            bool success = c.Update(c);

            if (success == true)
            {
                //Updated successfully
                MessageBox.Show("Contact has been updated successfully");
                //Show data on data grid view
                DataTable dt = c.Select();
                dgvContactList.DataSource = dt;

                //Clear data field
                clear();

            }
            else
            {
                //Failed to update 
                MessageBox.Show("Contact Failed to update");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //Call clear method to clear all the fields
            clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Get the contact ID from the application
            c.ContactID = Convert.ToInt32(textBoxContactID.Text);
            bool success = c.Delete(c);
            if (success == true)
            {
                //Successfully deleted
                MessageBox.Show("Contact Sucessfully Deleted");

                //Refresh the data grid view
                //Show data on data grid view
                DataTable dt = c.Select();
                dgvContactList.DataSource = dt;

                //Clear data field
                clear();
            }
            else
            { 
                //Failed to delete 
                MessageBox.Show("Failed to delete contact. Try again");
            }
        }

        SqlConnection conn = new SqlConnection(Global.DBCon);
      
        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            //Get the value from text box
            string keyword = textBoxSearch.Text;

            SqlDataAdapter sda = new SqlDataAdapter("SELECT *FROM tbl_contact where FirstName Like '%"+keyword+"%' OR LastName Like '%"+keyword+"%'  OR Address Like '%"+keyword+"%'",conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgvContactList.DataSource = dt;
        }
    }
}
