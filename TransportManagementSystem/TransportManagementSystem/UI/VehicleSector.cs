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

namespace TransportManagementSystem
{
    public partial class VehicleSector : Form
    {
        //Database connection
        SqlConnection conn = new SqlConnection(Global.BDConn);

        //Instance of data access 
        TransportDataAccess tda = new TransportDataAccess();

        //Instance of data interface
        TransportDataInterface tdf = new TransportDataInterface();

        String ActiveInActiveValue = "";
        public VehicleSector()
        {
            InitializeComponent();
        }

        private void VehicleSector_Load(object sender, EventArgs e)
        {
 
            //Showing data on datagrid
            DataTable dt = tda.SelectVehicleSector();
            dgvVehicleSectorList.DataSource = dt;

            //Disable update button
            btnUpdate.Enabled = false;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Transport tc = new Transport();
            tc.Show();
            this.Hide();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Check Active InActive status checked or not
            if (!rdoActive.Checked && !rdoInActive.Checked)
            {

                MessageBox.Show("Please Select Active or InActive ", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                rdoActive.Focus();
                return;

            }

            //Get the data from text fied
            tdf.Name = textBoxName.Text;

            if (rdoActive.Checked == true)
            {
                ActiveInActiveValue = "1";
            }
            else if(rdoInActive.Checked == true)
            {
                ActiveInActiveValue = "0";
            }

            //Call the create vehicle sector metod to create new vehicle sector
            tda.createVehicleSector(tdf.Name, ActiveInActiveValue);

            //Refresh
            //Showing data on datagrid
            DataTable dt = tda.SelectVehicleSector();
            dgvVehicleSectorList.DataSource = dt;

            //Clear the field
            clear();

        }
        public void clear()
        {
            textBoxId.Text = "";
            textBoxName.Text = "";
            rdoActive.Checked = false;
            rdoInActive.Checked = false;
        }

        private void dgvVehicleSectorList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Enable the update button and disable the save button
            btnUpdate.Enabled = true;
            btnSave.Enabled = false;

            //Get the data from data grid view and load it to the textboxes respectively
            //Identify the row on which mouse is clicked
            int rowIndex = e.RowIndex;
            textBoxId.Text = dgvVehicleSectorList.Rows[rowIndex].Cells[0].Value.ToString();
            textBoxName.Text = dgvVehicleSectorList.Rows[rowIndex].Cells[1].Value.ToString();
            String activeStatus = dgvVehicleSectorList.Rows[rowIndex].Cells[2].Value.ToString();
            
            if (activeStatus == "True")
            {
                rdoActive.Checked = true;
            }
            else
            {
                rdoInActive.Checked = true;
            }
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Check active inactive status
            if (!rdoActive.Checked && !rdoInActive.Checked)
            {

                MessageBox.Show("Please Select Active or InActive ", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                rdoActive.Focus();
                return;

            }

            //Get the data from text fied
            tdf.ID = Convert.ToInt32(textBoxId.Text);
            tdf.Name = textBoxName.Text;

            if (rdoActive.Checked == true)
            {
                ActiveInActiveValue = "1";
            }
            else if (rdoInActive.Checked == true)
            {
                ActiveInActiveValue = "0";
            }

            tda.updateVehicleSector(tdf.ID, tdf.Name, ActiveInActiveValue);

            //Refresh
            //Showing data on datagrid
            DataTable dt = tda.SelectVehicleSector();
            dgvVehicleSectorList.DataSource = dt;

            //Clear the field
            clear();

            //Disable the update button and enable the save button
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }
    
        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            //Get the value from text box
            string keyword = textBoxSearch.Text;

            SqlDataAdapter sda = new SqlDataAdapter("SELECT *FROM VechicleSector where Name Like '%" + keyword + "%'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgvVehicleSectorList.DataSource = dt;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //Clear the fields
            clear();

            //Enable the save button and disable the update button
            btnUpdate.Enabled = false;
            btnSave.Enabled = true;
        }
    }
}
