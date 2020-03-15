using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectVehicle.WebAPI.Models
{
    public class VehicleMakeRestModel
    {
        public int ID { get; set; }
        
        public string ManufacturerName { get; set; }
        
        public string MadeIn { get; set; }
    }

}