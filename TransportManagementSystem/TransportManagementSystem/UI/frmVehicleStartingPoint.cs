using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using TransportManagementSystem.DataAccess;
using TransportManagementSystem.DataInterface;

namespace TransportManagementSystem.UI
{
    public partial class frmVehicleStartingPoint : Form
    {

        //Database connection
        SqlConnection conn = new SqlConnection(Global.BDConn);

        //Instance of data interface
        TransportDataInterface tdf = new TransportDataInterface();

        //Instance of data access
        TransportDataAccess tda = new TransportDataAccess();

        public frmVehicleStartingPoint()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            textBoxId.Text = "";
            comboBoxSectorID.Text = "";
            comboBoxVehicleID.Text = "";
            comboBoxRouteID.Text = "";
            textBoxName.Text = "";
            rdoActive.Checked = false;
            rdoInActive.Checked = false;
        }

        public void ComboboxDataLoad()
        {
            string sql = "SELECT ID, NAME FROM VehicleSector";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);


            // Bind the data to the ComboBox
            comboBoxSectorID.DataSource = dt;
            comboBoxSectorID.DisplayMember = "Name";
            comboBoxSectorID.ValueMember = "ID";

            string sql1 = "SELECT ID, NAME FROM VehicleType_Mst";
            SqlCommand cmd1 = new SqlCommand(sql1, conn);
            SqlDataAdapter adapter1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            adapter1.Fill(dt1);

            // Bind the data to the ComboBox
            comboBoxVehicleID.DataSource = dt1;
            comboBoxVehicleID.DisplayMember = "Name";
            comboBoxVehicleID.ValueMember = "ID";

            string sql2 = "SELECT ID, NAME FROM TransportRoute";
            SqlCommand cmd2 = new SqlCommand(sql2, conn);
            SqlDataAdapter adapter2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            adapter2.Fill(dt2);

            // Bind the data to the ComboBox
            comboBoxRouteID.DataSource = dt2;
            comboBoxRouteID.DisplayMember = "Name";
            comboBoxRouteID.ValueMember = "ID";


            ////Showing data on datagrid
            DataTable dt3 = tda.SelectVechileStartingPoint();
            dataGridViewStartingPoint.DataSource = dt3;
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Transport tp = new Transport();
            tp.Show();
            this.Hide();
        }

        private void VehicleStartingPoint_Load(object sender, EventArgs e)
        {
            // Subscribe to the RowHeaderMouseClick event
            dataGridViewStartingPoint.RowHeaderMouseClick += dataGridViewStartingPoint_RowHeaderMouseClick;

            //Call ComboboxDataLoad 
            ComboboxDataLoad();

            //Disable update button
            btnUpdate.Enabled = false;

            //Set the initial selected index of comnoboxes to -1
            comboBoxRouteID.SelectedIndex = -1;
            comboBoxSectorID.SelectedIndex = -1;
            comboBoxVehicleID.SelectedIndex = -1;

           
                
        }

        private void comboBoxVehicleID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxSectorID_SelectedIndexChanged(object sender, EventArgs e)
        {
          

        }

        private void comboBoxRouteID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
           
            try
            {
                if (!rdoActive.Checked && !rdoInActive.Checked)
                {

                    MessageBox.Show("Please Select Active or InActive ", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    rdoActive.Focus();
                    return;

                }

                String ActiveInActiveValue = "";

                //Get the data from text fied
                tdf.SectorID = Convert.ToInt32(comboBoxSectorID.SelectedValue);
                tdf.VehicleID = Convert.ToInt32(comboBoxVehicleID.SelectedValue);
                tdf.RouteID = Convert.ToInt32(comboBoxRouteID.SelectedValue);
                tdf.Name = textBoxName.Text;

                if (rdoActive.Checked == true)
                {
                    ActiveInActiveValue = "1";
                }
                else if (rdoInActive.Checked == true)
                {
                    ActiveInActiveValue = "0";
                }

                tda.createVehicleStartingPoint(tdf.SectorID, tdf.VehicleID, tdf.RouteID,tdf.Name, ActiveInActiveValue);


                //Refresh
                //Showing data on datagrid
                DataTable dt = tda.SelectVechileStartingPoint();
                dataGridViewStartingPoint.DataSource = dt;
                Clear();
            }
            catch (Exception ex)
            {
                // Handle the exception
                MessageBox.Show("An error occurred while saving data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                //Check active status
                if (!rdoActive.Checked && !rdoInActive.Checked)
                {

                    MessageBox.Show("Please Select Active or InActive ", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    rdoActive.Focus();
                    return;

                }
                String ActiveInActiveValue = "";
                //Get the data from text fied
                tdf.ID = Convert.ToInt32(textBoxId.Text);
                tdf.SectorID = Convert.ToInt32(comboBoxSectorID.SelectedValue);
                tdf.VehicleID = Convert.ToInt32(comboBoxVehicleID.SelectedValue);
                tdf.RouteID = Convert.ToInt32(comboBoxRouteID.SelectedValue);
                tdf.Name = textBoxName.Text;


                if (rdoActive.Checked == true)
                {
                    ActiveInActiveValue = "1";
                }
                else if (rdoInActive.Checked == true)
                {
                    ActiveInActiveValue = "0";
                }

                 tda.updateStartingPoint(tdf.ID, tdf.SectorID, tdf.VehicleID, tdf.RouteID,tdf.Name, ActiveInActiveValue);

             
                //Refresh
                //Showing data on datagrid
                DataTable dt = tda.SelectVechileStartingPoint();
                dataGridViewStartingPoint.DataSource = dt;

                //Clear the field
                Clear();

                //Disable update button
                btnUpdate.Enabled = false;

            }
            catch (Exception ex)
            {
                // Handle the exception
                MessageBox.Show("An error occurred while saving data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewStartingPoint_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            //Disable save button and enable update button
            btnSave.Enabled = false;
            btnUpdate.Enabled = true;

            //Get the data from data grid view and load it to the textboxes respectively
            //Identify the row on which mouse is clicked
            int rowIndex = e.RowIndex;
            textBoxId.Text = dataGridViewStartingPoint.Rows[rowIndex].Cells[0].Value.ToString();

         
            object selectedItem = dataGridViewStartingPoint.Rows[rowIndex].Cells[1].Value.ToString();
            comboBoxSectorID.SelectedItem = selectedItem;
            selectedItem = dataGridViewStartingPoint.Rows[rowIndex].Cells[2].Value.ToString();
            comboBoxVehicleID.SelectedValue = selectedItem;
            selectedItem = dataGridViewStartingPoint.Rows[rowIndex].Cells[3].Value.ToString();
            comboBoxRouteID.SelectedValue = selectedItem;

            textBoxName.Text = dataGridViewStartingPoint.Rows[rowIndex].Cells[4].Value.ToString();
            int activeStatusInt = Convert.ToInt32(dataGridViewStartingPoint.Rows[rowIndex].Cells[5].Value);
            if (activeStatusInt == 1)
            {
                rdoActive.Checked = true;
            }
            else
            {
                rdoInActive.Checked = true;
            }

            // Set the selected cell back to the current row
            dataGridViewStartingPoint.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewStartingPoint.CurrentCell = dataGridViewStartingPoint.Rows[rowIndex].Cells[0];
        }

        //Search records
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //Get the value from text box
            string keyword = textBoxSearch.Text;

            SqlDataAdapter sda = new SqlDataAdapter("SELECT STP.ID, SEC.[Name] AS 'Sector Name' , VEH.[Name] AS 'Vehicle Type', RT.[Name] AS 'Transport Route', STP.[Name], STP.IsActive FROM VehicleStartingPoint STP JOIN VehicleSector SEC ON STP.SectorID = SEC.ID JOIN VehicleType_Mst VEH ON STP.VehicleID = VEH.ID JOIN TransportRoute RT ON STP.RouteID = RT.ID WHERE STP.[Name] LIKE '%" + keyword + "%' OR SEC.[Name] LIKE '%" + keyword + "%' OR  VEH.[Name] LIKE '%" + keyword + "%' OR  RT.[Name] LIKE '%" + keyword + "%'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridViewStartingPoint.DataSource = dt;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //Clear the fields
            Clear();
            //Disable update button and enable save button
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }


        }
    }