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

namespace TransportManagementSystem
{
    public partial class VehicleSector : Form
    {
        TransportDataAccess tda = new TransportDataAccess();

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

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Transport tc = new Transport();
            tc.Show();
            this.Hide();
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

            if (rdoActive.Checked == true)
            {
                ActiveInActiveValue = "1";
            }
            else if(rdoInActive.Checked == true)
            {
                ActiveInActiveValue = "0";
            }

            bool isSuccess = tda.createVehicleSector(Name, ActiveInActiveValue);

            if (isSuccess == true)
            {
                MessageBox.Show("Vehicle Sector Created Successfully");
            }
            else
            {
                MessageBox.Show("Failed to create Vehicle sector. Try again!!");
            }

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
            if (!rdoActive.Checked && !rdoInActive.Checked)
            {

                MessageBox.Show("Please Select Active or InActive ", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                rdoActive.Focus();
                return;

            }

            //Get the data from text fied
            tda.ID = Convert.ToInt32(textBoxId.Text);
            tda.Name = textBoxName.Text;

            if (rdoActive.Checked == true)
            {
                ActiveInActiveValue = "1";
            }
            else if (rdoInActive.Checked == true)
            {
                ActiveInActiveValue = "0";
            }

            bool isSuccess = tda.updateVehicleSector(tda.ID, tda.Name, ActiveInActiveValue);

            if (isSuccess == true)
            {
                MessageBox.Show("Vehicle Sector Updated Successfully");
            }
            else
            {
                MessageBox.Show("Failed to create Vehicle sector. Try again!!");
            }

            //Refresh
            //Showing data on datagrid
            DataTable dt = tda.SelectVehicleSector();
            dgvVehicleSectorList.DataSource = dt;

            //Clear the field
            clear();

        }
        SqlConnection conn = new SqlConnection(Global.BDConn);
        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            //Get the value from text box
            string keyword = textBoxSearch.Text;

            SqlDataAdapter sda = new SqlDataAdapter("SELECT *FROM VechicleSector where Name Like '%" + keyword + "%'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgvVehicleSectorList.DataSource = dt;
        }

        private void dgvVehicleSectorList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
