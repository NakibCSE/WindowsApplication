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
    public partial class VehicleStartingPoint : Form
    {
        public VehicleStartingPoint()
        {
            InitializeComponent();
        }

        TransportDataAccess tda = new TransportDataAccess();
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
            SqlConnection conn = new SqlConnection(Global.BDConn);

            //Open connection
            conn.Open();

            string sql = "SELECT ID, NAME FROM VechicleSector";
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


            //Showing data on datagrid
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
            ComboboxDataLoad();
                
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
                tda.SectorID = Convert.ToInt32(comboBoxSectorID.SelectedValue);
                tda.VehicleID = Convert.ToInt32(comboBoxVehicleID.SelectedValue);
                tda.RouteID = Convert.ToInt32(comboBoxRouteID.SelectedValue);
                tda.Name = textBoxName.Text;

                if (rdoActive.Checked == true)
                {
                    ActiveInActiveValue = "1";
                }
                else if (rdoInActive.Checked == true)
                {
                    ActiveInActiveValue = "0";
                }

                bool isSuccess = tda.createVehicleStartingPoint(tda.Name, tda.SectorID, tda.VehicleID, tda.RouteID, ActiveInActiveValue);

                if (isSuccess == true)
                {
                    MessageBox.Show("New Starting point Created Successfully");

                }
                else
                {
                    MessageBox.Show("Failed to create new Starting point. Try again!!");
                }

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
                tda.SectorID = Convert.ToInt32(comboBoxSectorID.SelectedValue);
                tda.VehicleID = Convert.ToInt32(comboBoxVehicleID.SelectedValue);
                tda.RouteID = Convert.ToInt32(comboBoxRouteID.SelectedValue);


                if (rdoActive.Checked == true)
                {
                    ActiveInActiveValue = "1";
                }
                else if (rdoInActive.Checked == true)
                {
                    ActiveInActiveValue = "0";
                }

                bool isSuccess = tda.updateStartingPoint(tda.ID, tda.Name, tda.SectorID, tda.VehicleID, tda.RouteID, ActiveInActiveValue);

                if (isSuccess == true)
                {
                    MessageBox.Show("Startingpoint Updated Successfully");
                }
                else
                {
                    MessageBox.Show("Failed update Starting point. Try again!!");
                }

                //Refresh
                //Showing data on datagrid
                DataTable dt = tda.SelectVechileStartingPoint();
                dataGridViewStartingPoint.DataSource = dt;

                //Clear the field
                Clear();

            }
            catch (Exception ex)
            {
                // Handle the exception
                MessageBox.Show("An error occurred while saving data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewStartingPoint_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            ComboboxDataLoad();

            //Get the data from data grid view and load it to the textboxes respectively
            //Identify the row on which mouse is clicked
            int rowIndex = e.RowIndex;
            textBoxId.Text = dataGridViewStartingPoint.Rows[rowIndex].Cells[0].Value.ToString();
            comboBoxSectorID.SelectedValue = dataGridViewStartingPoint.Rows[rowIndex].Cells[1].Value;
            comboBoxVehicleID.SelectedValue = dataGridViewStartingPoint.Rows[rowIndex].Cells[2].Value;
            comboBoxRouteID.SelectedValue = dataGridViewStartingPoint.Rows[rowIndex].Cells[3].Value;
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
        }

        //Search records
        SqlConnection conn = new SqlConnection(Global.BDConn);
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //Get the value from text box
            string keyword = textBoxSearch.Text;

            SqlDataAdapter sda = new SqlDataAdapter("SELECT *FROM VehicleStartingPoint where Name Like '%" + keyword + "%'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridViewStartingPoint.DataSource = dt;
        }

        }
    }