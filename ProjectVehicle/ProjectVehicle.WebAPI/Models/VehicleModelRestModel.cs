using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectVehicle.WebAPI.Models
{
    public class VehicleModelRestModel
    {
        public int VehicleModelID { get; set; }
        public string ModelName { get; set; }
        public int ModelYear { get; set; }
        public string Colour { get; set; }
        public int VehicleMakeID { get; set; }
        public int VehicleEngineTypeID { get; set; }
    }
}