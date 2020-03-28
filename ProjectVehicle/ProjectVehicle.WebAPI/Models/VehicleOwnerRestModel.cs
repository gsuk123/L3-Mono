using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectVehicle.WebAPI.Models
{
    public class VehicleOwnerRestModel
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}