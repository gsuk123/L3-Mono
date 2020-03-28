using System;
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
            [Required]
            public string ModelName { get; set; }
            [Required]
            public int ModelYear { get; set; }
            [Required]
            public string Colour { get; set; }
            public int VehicleMakeID { get; set; }            
            public int VehicleEngineTypeID { get; set; }            
            [ForeignKey("VehicleMakeID")] 
            public virtual VehicleMakeEntity VehicleMake { get; set; }
            [ForeignKey("VehicleEngineTypeID")]
            public virtual VehicleEngineTypeEntity VehicleEngineType { get; set; }
            public virtual ICollection<VehicleRegistrationEntity> VehicleRegistration { get; set; }

    }
}
