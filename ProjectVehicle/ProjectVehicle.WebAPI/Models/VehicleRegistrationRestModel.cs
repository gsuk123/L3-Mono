using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectVehicle.WebAPI.Models
{
    public class VehicleRegistrationRestModel
    {
        public int ID { get; set; }
        public string RegistrationNumber { get; set; }
        public int VehicleModelId { get; set; }
        public int VehicleOwnerId { get; set; }
    }
}