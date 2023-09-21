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
            frmTransportRoute tr = new frmTransportRoute();
            tr.Show();
            this.Hide();
        }

        private void btnStartingPoint_Click(object sender, EventArgs e)
        {
            frmVehicleStartingPoint sp = new frmVehicleStartingPoint();
            sp.Show();
            this.Hide();
        }

        private void btnPickUpPoint_Click(object sender, EventArgs e)
        {
            frmVehiclePickUpPoint vcp = new frmVehiclePickUpPoint();
            vcp.Show();
            this.Hide();
        }
    }
}
