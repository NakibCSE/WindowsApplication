using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TransportManagementSystem.DataAccess;
using System.Data.SqlClient;

namespace TransportManagementSystem.UI
{
    public partial class VehicleType : Form
    {
        TransportDataAccess tda = new TransportDataAccess();

        String ActiveInActiveValue = "";

        public VehicleType()
        {
            InitializeComponent();
        }

        private void VehicleType_Load(object sender, EventArgs e)
        {
            //Showing data on datagrid view
            DataTable dt = tda.SelectVehicle();
            dataGridViewVehicle.DataSource = dt;

        }

        public void Clear()
        {
            textBoxId.Text = "";
            textBoxName.Text = "";
            textBoxRegNo.Text = "";
            textBoxNote.Text = "";
            rdoActive.Checked=false;
            rdoInActive.Checked=false;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!rdoActive.Checked && !rdoInActive.Checked)
            {

                MessageBox.Show("Please Select Active or InActive ", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                rdoActive.Focus();
                return;

            }

            //Get the data from text fied
            tda.Name = textBoxName.Text;
            tda.RegistrationNo = textBoxRegNo.Text;
            tda.Note = textBoxNote.Text;

            if (rdoActive.Checked == true)
            {
                ActiveInActiveValue = "1";
            }
            else if (rdoInActive.Checked == true)
            {
                ActiveInActiveValue = "0";
            }

            bool isSuccess = tda.createVehicleType(tda.Name, ActiveInActiveValue, tda.RegistrationNo, tda.Note);

            if (isSuccess == true)
            {
                MessageBox.Show("New Vehicle Created Successfully");
               
            }
            else
            {
                MessageBox.Show("Failed to create new Vehicle. Try again!!");
            }

            //Refresh
            //Showing data on datagrid
            DataTable dt = tda.SelectVehicle();
            dataGridViewVehicle.DataSource = dt;
            Clear();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Transport tp = new Transport();
            tp.Show();
            this.Hide();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            Transport tp = new Transport();
            tp.Show();
            this.Hide();
        }

        private void dataGridViewVehicle_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Get the data from data grid view and load it to the textboxes respectively
            //Identify the row on which mouse is clicked
            int rowIndex = e.RowIndex;
            textBoxId.Text = dataGridViewVehicle.Rows[rowIndex].Cells[0].Value.ToString();
            textBoxName.Text = dataGridViewVehicle.Rows[rowIndex].Cells[1].Value.ToString();
            String activeStatus = dataGridViewVehicle.Rows[rowIndex].Cells[2].Value.ToString();
            int activeStatusInt = Convert.ToInt32(activeStatus);
            if (activeStatusInt == 1)
            {
                rdoActive.Checked = true;
            }
            else
            {
                rdoInActive.Checked = true;
            }

            textBoxRegNo.Text = dataGridViewVehicle.Rows[rowIndex].Cells[3].Value.ToString();
            textBoxNote.Text = dataGridViewVehicle.Rows[rowIndex].Cells[4].Value.ToString();
            
        }

        //Search records
        SqlConnection conn = new SqlConnection(Global.BDConn);
        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            //Get the value from text box
            string keyword = textBoxSearch.Text;

            SqlDataAdapter sda = new SqlDataAdapter("SELECT *FROM VW_VEHICLE where Name Like '%" + keyword + "%'" , conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridViewVehicle.DataSource = dt;
        }
        

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!rdoActive.Checked && !rdoInActive.Checked)
            {

                MessageBox.Show("Please Select Active or InActive ", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                rdoActive.Focus();
                return;

            }

            //Get the data from text fied
            tda.ID = Convert.ToInt32(textBoxId.Text);
            tda.Name = textBoxName.Text;
            tda.RegistrationNo = textBoxRegNo.Text;
            tda.Note = textBoxNote.Text;
           
            if (rdoActive.Checked == true)
            {
                ActiveInActiveValue = "1";
            }
            else if (rdoInActive.Checked == true)
            {
                ActiveInActiveValue = "0";
            }

            bool isSuccess = tda.updateVehicle(tda.ID, tda.Name, tda.RegistrationNo, tda.Note ,ActiveInActiveValue);

            if (isSuccess == true)
            {
                MessageBox.Show("Vehicle Updated Successfully");
            }
            else
            {
                MessageBox.Show("Failed update Vehicle. Try again!!");
            }

            //Refresh
            //Showing data on datagrid
            DataTable dt = tda.SelectVehicle();
            dataGridViewVehicle.DataSource = dt;

            //Clear the field
            Clear();
        }

      

    }
}
