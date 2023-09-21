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
    public partial class frmTransportRoute : Form
    {
        //Database connection
        SqlConnection conn = new SqlConnection(Global.BDConn);

        //Instance of data interface
        TransportDataInterface tdf = new TransportDataInterface();

        public frmTransportRoute()
        {
            InitializeComponent();
        }
        public void Clear()
        {
            textBoxId.Text = "";
            textBoxName.Text = "";
        }
        TransportDataAccess tda = new TransportDataAccess();
        private void btnClose_Click(object sender, EventArgs e)
        {
            Transport tp = new Transport();
            tp.Show();
            this.Hide();
        }

        private void TransportRoute_Load(object sender, EventArgs e)
        {
            //Showing data on datagrid
            DataTable dt = tda.SelectTransportRoute();
            dataGridViewTransportRoute.DataSource = dt;

            //Disable update button
            btnUpdate.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            //Get the data from text fied
            tdf.Name = textBoxName.Text;

            tda.createTransportRoute(tdf.Name);

            //Refresh
            //Showing data on datagrid
            DataTable dt = tda.SelectTransportRoute();
            dataGridViewTransportRoute.DataSource = dt;

            //Clear the field
            Clear();

            //Enable save button
            btnSave.Enabled = true;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Get the data from text field
            tdf.ID =Convert.ToInt32(textBoxId.Text);
            tdf.Name = textBoxName.Text;
            
            tda.updateTransportRoute(tdf.ID, tdf.Name);

            //Refresh
            //Showing data on datagrid
            DataTable dt = tda.SelectTransportRoute();
            dataGridViewTransportRoute.DataSource = dt;

            //Clear the field
            Clear();

            //Disable update button
            btnUpdate.Enabled = false;
        }

        private void dataGridViewTransportRoute_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Enable update button
            btnUpdate.Enabled = true;

            //Disable save button
            btnSave.Enabled = false;

            //Get the data from data grid view and load it to the textboxes respectively
            //Identify the row on which mouse is clicked
            int rowIndex = e.RowIndex;
            textBoxId.Text = dataGridViewTransportRoute.Rows[rowIndex].Cells[0].Value.ToString();
            textBoxName.Text = dataGridViewTransportRoute.Rows[rowIndex].Cells[1].Value.ToString();
        }


       

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            //Get the value from text box
            string keyword = textBoxSearch.Text;

            SqlDataAdapter sda = new SqlDataAdapter("SELECT *FROM TransportRoute WHERE Name Like '%" + keyword + "%'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridViewTransportRoute.DataSource = dt;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //Clear the fields
            Clear();

            //disable update button
            btnUpdate.Enabled = false;

            //Enable save button
            btnSave.Enabled = true;
        }
    }
}
