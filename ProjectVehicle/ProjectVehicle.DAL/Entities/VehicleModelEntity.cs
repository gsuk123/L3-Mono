﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVehicle.DAL.Entities
{
    [Table("VehicleModel")]
    public class VehicleModelEntity
    {
            [Key]
            public int VehicleModelID { get; set; }
            public string ModelName { get; set; }
            public int ModelYear { get; set; }
            public string Colour { get; set; }
            public int VehicleMakeID { get; set; }
            [ForeignKey("VehicleMakeID")]
            public virtual VehicleMakeEntity VehicleMake { get; set; }     

    }
}