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
    public partial class frmVehiclePickUpPoint : Form
    {
        //Database connection
        SqlConnection conn = new SqlConnection(Global.BDConn);

        //Instance of data interface class
        TransportDataInterface tdf = new TransportDataInterface();

        //Instance of data access class
        TransportDataAccess tda = new TransportDataAccess();

        public frmVehiclePickUpPoint()
        {
            InitializeComponent();
        }

       
        public void comboboxDataLoad()
        {

            //Open connection
            conn.Open();

            string sql = "SELECT ID, NAME FROM VehicleStartingPoint";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);


            // Bind the data to the ComboBox
            comboBoxStartingPointID.DataSource = dt;
            comboBoxStartingPointID.DisplayMember = "Name";
            comboBoxStartingPointID.ValueMember = "ID";

            //Showing data on datagrid
            DataTable dt1 = tda.SelectVehiclePickUpPOint();
            dataGridViewPickUpPoints.DataSource = dt1;

            //Close database connection
            conn.Close();
        }

        private void VehiclePickUpPoint_Load(object sender, EventArgs e)
        {
            comboboxDataLoad();
            //Disable update button
            btnUpdate.Enabled = false;
            comboBoxStartingPointID.SelectedIndex = -1;

        }

        public void Clear()
        {
            textBoxId.Text = "";
            comboBoxStartingPointID.Text = "";
            textBoxName.Text = "";
            textBoxNote.Text = "";
            rdoActive.Checked = false;
            rdoInActive.Checked=false;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Transport tp = new Transport();
            tp.Show();
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

            String ActiveInActiveValue = "";

            //Get the data from text fied
            tdf.Name = textBoxName.Text;
            tdf.StartingPointID = Convert.ToInt32(comboBoxStartingPointID.SelectedValue);
            tdf.Note = textBoxNote.Text;

            if (rdoActive.Checked == true)
            {
                ActiveInActiveValue = "1";
            }
            else if (rdoInActive.Checked == true)
            {
                ActiveInActiveValue = "0";
            }

            tda.createVehiclePickUpPoint(tdf.Name, tdf.StartingPointID, tdf.Note, ActiveInActiveValue);


            //Refresh
            //Showing data on datagrid
            DataTable dt = tda.SelectVehiclePickUpPOint();
            dataGridViewPickUpPoints.DataSource = dt;

            //Clear the fielda
            Clear();
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!rdoActive.Checked && !rdoInActive.Checked)
            {

                MessageBox.Show("Please Select Active or InActive ", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                rdoActive.Focus();
                return;

            }

            String ActiveInActiveValue = "";

            //Get the data from text fied
            tdf.ID = Convert.ToInt32(textBoxId.Text);
            tdf.Name = textBoxName.Text;
            tdf.StartingPointID = Convert.ToInt32(comboBoxStartingPointID.SelectedValue);
            tdf.Note = textBoxNote.Text;

            if (rdoActive.Checked == true)
            {
                ActiveInActiveValue = "1";
            }
            else if (rdoInActive.Checked == true)
            {
                ActiveInActiveValue = "0";
            }

            tda.updatePickupPoint(tdf.ID, tdf.Name, tdf.StartingPointID,tdf.Note, ActiveInActiveValue);

            //Refresh
            //Showing data on datagrid
            DataTable dt = tda.SelectVehiclePickUpPOint();
            dataGridViewPickUpPoints.DataSource = dt;

            //Clear the field
            Clear();

            //Disable update button and enable save button
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }

        private void dataGridViewPickUpPoints_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Enable update button
            btnUpdate.Enabled = true;

            //Disable save button
            btnSave.Enabled = false;

            comboboxDataLoad();
            //Get the data from data grid view and load it to the textboxes respectively
            //Identify the row on which mouse is clicked
            int rowIndex = e.RowIndex;
            textBoxId.Text = dataGridViewPickUpPoints.Rows[rowIndex].Cells[0].Value.ToString();
            //comboBoxStartingPointID.SelectedValue = dataGridViewPickUpPoints.Rows[rowIndex].Cells[1].Value;
            textBoxName.Text = dataGridViewPickUpPoints.Rows[rowIndex].Cells[2].Value.ToString(); 
            textBoxNote.Text = dataGridViewPickUpPoints.Rows[rowIndex].Cells[3].Value.ToString();

            int activeStatusInt = Convert.ToInt32(dataGridViewPickUpPoints.Rows[rowIndex].Cells[4].Value);
            if (activeStatusInt == 1)
            {
                rdoActive.Checked = true;
            }
            else
            {
                rdoInActive.Checked = true;
            }
            // Set the selected cell back to the current row
            dataGridViewPickUpPoints.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewPickUpPoints.CurrentCell = dataGridViewPickUpPoints.Rows[rowIndex].Cells[0];
        }

        //Search records
        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            //Get the value from text box
            string keyword = textBoxSearch.Text.Trim();

            SqlDataAdapter sda = new SqlDataAdapter("SELECT PUP.ID, STP.[Name] AS 'StartingPoint Name', PUP.[Name], PUP.Note, PUP.IsActive FROM PickupPoints PUP JOIN VehicleStartingPoint STP ON PUP.StartingPointID = STP.ID WHERE STP.[Name]  LIKE '%" + keyword + "%' OR PUP.[Name] LIKE '%" + keyword + "%'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridViewPickUpPoints.DataSource = dt;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //Clear the fields
            Clear();
            //Disable update button
            btnUpdate.Enabled = false;
            //Enable save button
            btnSave.Enabled = true;
        }

     
    }
}
