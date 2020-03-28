using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVehicle.Model.Common
{
    public interface IVehicleRegistration
    {
        int ID { get; set; }
        string RegistrationNumber { get; set; }
        int VehicleModelId { get; set; }
        int VehicleOwnerId { get; set; }
        IVehicleModel VehicleModel { get; set; }
        IVehicleOwner VehicleOwner { get; set; }
    }
}
