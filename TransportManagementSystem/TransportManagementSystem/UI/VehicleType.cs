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
using TransportManagementSystem.DataInterface;

namespace TransportManagementSystem.UI
{
    public partial class VehicleType : Form
    {
        //Database connection
        SqlConnection conn = new SqlConnection(Global.BDConn);

        //Instance of Data access
        TransportDataAccess tda = new TransportDataAccess();


        //Instance of data interface
        TransportDataInterface tdf = new TransportDataInterface();


        String ActiveInActiveValue = "";

        public VehicleType()
        {
            InitializeComponent();
        }

        private void VehicleType_Load(object sender, EventArgs e)
        {
            //Showing data on datagrid view
            DataTable dt = tda.SelectVehicleType();
            dataGridViewVehicle.DataSource = dt;

            //Disable the update button
            btnUpdate.Enabled = false;
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
            //Check active inactive status
            if (!rdoActive.Checked && !rdoInActive.Checked)
            {

                MessageBox.Show("Please Select Active or InActive ", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                rdoActive.Focus();
                return;

            }

            //Get the data from text fied
            tdf.Name = textBoxName.Text;
            tdf.RegistrationNo = textBoxRegNo.Text;
            tdf.Note = textBoxNote.Text;

            if (rdoActive.Checked == true)
            {
                ActiveInActiveValue = "1";
            }
            else if (rdoInActive.Checked == true)
            {
                ActiveInActiveValue = "0";
            }

            tda.createVehicleType(tdf.Name, ActiveInActiveValue, tdf.RegistrationNo, tdf.Note);

            //Refresh
            //Showing data on datagrid
            DataTable dt = tda.SelectVehicleType();
            dataGridViewVehicle.DataSource = dt;
            Clear();
        }

        private void dataGridViewVehicle_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Enable the update button and disable the save button
            btnUpdate.Enabled = true;
            btnSave.Enabled = false;

            //Get the data from data grid view and load it to the textboxes respectively
            //Identify the row on which mouse is clicked
            int rowIndex = e.RowIndex;
            textBoxId.Text = dataGridViewVehicle.Rows[rowIndex].Cells[0].Value.ToString();
            textBoxName.Text = dataGridViewVehicle.Rows[rowIndex].Cells[1].Value.ToString();
            String activeStatus = dataGridViewVehicle.Rows[rowIndex].Cells[2].Value.ToString();

            if (activeStatus == "True")
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
            tdf.ID = Convert.ToInt32(textBoxId.Text);
            tdf.Name = textBoxName.Text;
            tdf.RegistrationNo = textBoxRegNo.Text;
            tdf.Note = textBoxNote.Text;
           
            if (rdoActive.Checked == true)
            {
                ActiveInActiveValue = "1";
            }
            else if (rdoInActive.Checked == true)
            {
                ActiveInActiveValue = "0";
            }

            tda.updateVehicleType(tdf.ID, tdf.Name, ActiveInActiveValue, tdf.RegistrationNo, tdf.Note);

            //Refresh
            //Showing data on datagrid
            DataTable dt = tda.SelectVehicleType();
            dataGridViewVehicle.DataSource = dt;

            //Clear the field
            Clear();

            //Disable the update button and enable the save button
            btnUpdate.Enabled = false;
            btnSave.Enabled = true;

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //Clear the fields
            Clear();

            //Enable the save button and disable the update button
            btnUpdate.Enabled = false;
            btnSave.Enabled = true;
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            Transport tp = new Transport();
            tp.Show();
            this.Hide();
        }

    }
}
