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
        [Required(ErrorMessage = "Manufacturer name is required")]
        public string ManufacturerName { get; set; }
        [Required(ErrorMessage = "Made in country is required")]
        public string MadeIn { get; set; }
    }

}