using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TransportManagementSystem.DataInterface
{
    class TransportDataInterface
    {
        //public setter getter
        public int ID { get; set; }
        public string Name { get; set; }
        public string RegistrationNo { get; set; }
        public string Note { set; get; }
        public int VehicleID { set; get; }
        public int SectorID { set; get; }
        public int RouteID { set; get; }
        public int StartingPointID { set; get; }
    }
}
