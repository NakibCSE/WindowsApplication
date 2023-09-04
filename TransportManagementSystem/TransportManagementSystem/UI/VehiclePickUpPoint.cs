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

namespace TransportManagementSystem.UI
{
    public partial class VehiclePickUpPoint : Form
    {
        public VehiclePickUpPoint()
        {
            InitializeComponent();
        }

        TransportDataAccess tda = new TransportDataAccess();
        public void comboboxDataLoad()
        {
            SqlConnection conn = new SqlConnection(Global.BDConn);

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
        }

        private void VehiclePickUpPoint_Load(object sender, EventArgs e)
        {
            comboboxDataLoad();
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

        private void lblStartingPointID_Click(object sender, EventArgs e)
        {

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
            tda.Name = textBoxName.Text;
            tda.StartingPointID = Convert.ToInt32(comboBoxStartingPointID.SelectedValue);
            tda.Note = textBoxNote.Text;

            if (rdoActive.Checked == true)
            {
                ActiveInActiveValue = "1";
            }
            else if (rdoInActive.Checked == true)
            {
                ActiveInActiveValue = "0";
            }

            bool isSuccess = tda.createVehiclePickUpPoint(tda.Name, tda.StartingPointID, tda.Note, ActiveInActiveValue);

            if (isSuccess == true)
            {
                MessageBox.Show("New Pickup point Created Successfully");

            }
            else
            {
                MessageBox.Show("Failed to create new Pickup point. Try again!!");
            }

            //Refresh
            //Showing data on datagrid
            DataTable dt = tda.SelectVehiclePickUpPOint();
            dataGridViewPickUpPoints.DataSource = dt;
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
            tda.ID = Convert.ToInt32(textBoxId.Text);
            tda.Name = textBoxName.Text;
            tda.StartingPointID = Convert.ToInt32(comboBoxStartingPointID.SelectedValue);
            tda.Note = textBoxNote.Text;

            if (rdoActive.Checked == true)
            {
                ActiveInActiveValue = "1";
            }
            else if (rdoInActive.Checked == true)
            {
                ActiveInActiveValue = "0";
            }

            bool isSuccess = tda.updatePickupPoint(tda.ID, tda.Name, tda.StartingPointID,tda.Note, ActiveInActiveValue);

            if (isSuccess == true)
            {
                MessageBox.Show("Pickup point Updated Successfully");
            }
            else
            {
                MessageBox.Show("Failed update Pickup point. Try again!!");
            }

            //Refresh
            //Showing data on datagrid
            DataTable dt = tda.SelectVehiclePickUpPOint();
            dataGridViewPickUpPoints.DataSource = dt;

            //Clear the field
            Clear();
        }

        private void dataGridViewPickUpPoints_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            comboboxDataLoad();
            //Get the data from data grid view and load it to the textboxes respectively
            //Identify the row on which mouse is clicked
            int rowIndex = e.RowIndex;
            textBoxId.Text = dataGridViewPickUpPoints.Rows[rowIndex].Cells[0].Value.ToString();
            comboBoxStartingPointID.SelectedValue = dataGridViewPickUpPoints.Rows[rowIndex].Cells[1].Value;
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
        }

        //Search records
        SqlConnection conn = new SqlConnection(Global.BDConn);
        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            //Get the value from text box
            string keyword = textBoxSearch.Text;

            SqlDataAdapter sda = new SqlDataAdapter("SELECT *FROM pickuppoints where Name Like '%" + keyword + "%' or Note like '%" + keyword + "%' ", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridViewPickUpPoints.DataSource = dt;
        }

     
    }
}
