using ProjectVehicle.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVehicle.Model
{
    public class VehicleRegistration : IVehicleRegistration
    {
        public int ID { get; set; }
        public string RegistrationNumber { get; set; }
        public int VehicleModelId { get; set; }
        public int VehicleOwnerId { get; set; }        
        public  IVehicleModel VehicleModel { get; set; }        
        public  IVehicleOwner VehicleOwner { get; set; }
    }
}
