using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVehicle.Model.Common
{
    public interface IVehicleModel
    {
        int VehicleModelID { get; set; }
        string ModelName { get; set; }
        int ModelYear { get; set; }
        string Colour { get; set; }
        int VehicleMakeID { get; set; }
        int VehicleEngineTypeID { get; set; }
        IVehicleMake VehicleMake { get; set; }
        IVehicleEngineType VehicleEngineType { get; set; }
    }
}
