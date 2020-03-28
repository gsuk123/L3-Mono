using ProjectVehicle.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVehicle.Model
{
    public class VehicleModel : IVehicleModel
    {
        public int VehicleModelID { get; set; }
        public string ModelName { get; set; }
        public int ModelYear { get; set; }
        public string Colour { get; set; }
        public int VehicleMakeID { get; set; }
        public int VehicleEngineTypeID { get; set; }
        public IVehicleMake VehicleMake { get; set; }
        public IVehicleEngineType VehicleEngineType { get; set; }
    }
}
