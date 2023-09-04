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
    public partial class TransportRoute : Form
    {
        public TransportRoute()
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
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            

            //Get the data from text fied
            tda.Name = textBoxName.Text;

            bool isSuccess = tda.createTransportRoute(Name);

            if (isSuccess == true)
            {
                MessageBox.Show("Transport Route Created Successfully");
            }
            else
            {
                MessageBox.Show("Failed to create Transport route. Try again!!");
            }

            //Refresh
            //Showing data on datagrid
            DataTable dt = tda.SelectTransportRoute();
            dataGridViewTransportRoute.DataSource = dt;

            //Clear the field
            Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Get the data from text field
            tda.ID =Convert.ToInt32(textBoxId.Text);
            tda.Name = textBoxName.Text;


            bool isSuccess = tda.updateTransportRoute(tda.ID, tda.Name);

            if (isSuccess == true)
            {
                MessageBox.Show("Transport route Updated Successfully");
            }
            else
            {
                MessageBox.Show("Failed update transport route. Try again!!");
            }

            //Refresh
            //Showing data on datagrid
            DataTable dt = tda.SelectTransportRoute();
            dataGridViewTransportRoute.DataSource = dt;

            //Clear the field
            Clear();
        }

        private void dataGridViewTransportRoute_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Get the data from data grid view and load it to the textboxes respectively
            //Identify the row on which mouse is clicked
            int rowIndex = e.RowIndex;
            textBoxId.Text = dataGridViewTransportRoute.Rows[rowIndex].Cells[0].Value.ToString();
            textBoxName.Text = dataGridViewTransportRoute.Rows[rowIndex].Cells[1].Value.ToString();
        }

        private void dataGridViewTransportRoute_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        SqlConnection conn = new SqlConnection(Global.BDConn);

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            //Get the value from text box
            string keyword = textBoxSearch.Text;

            SqlDataAdapter sda = new SqlDataAdapter("SELECT *FROM transportroute where Name Like '%" + keyword + "%'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridViewTransportRoute.DataSource = dt;
        }



    }
}
