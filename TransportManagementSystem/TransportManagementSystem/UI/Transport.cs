using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TransportManagementSystem.UI;
using TransportManagementSystem.DataAccess;

namespace TransportManagementSystem
{
    public partial class Transport : Form
    {
        TransportDataAccess DAObj = new TransportDataAccess();
        public Transport()
        {
            InitializeComponent();
        }

        private void VehicleSector_Click(object sender, EventArgs e)
        {
            VehicleSector vc = new VehicleSector();
            vc.Show();
            this.Hide();
        }

        private void btnVehicleType_Click(object sender, EventArgs e)
        {
            VehicleType vt = new VehicleType();
            vt.Show();
            this.Hide();

        }

        private void btnTransportRoute_Click(object sender, EventArgs e)
        {
            TransportRoute tr = new TransportRoute();
            tr.Show();
            this.Hide();
        }

        private void btnStartingPoint_Click(object sender, EventArgs e)
        {
            VehicleStartingPoint sp = new VehicleStartingPoint();
            sp.Show();
            this.Hide();
        }

        private void btnPickUpPoint_Click(object sender, EventArgs e)
        {
            VehiclePickUpPoint vcp = new VehiclePickUpPoint();
            vcp.Show();
            this.Hide();
        }
    }
}
