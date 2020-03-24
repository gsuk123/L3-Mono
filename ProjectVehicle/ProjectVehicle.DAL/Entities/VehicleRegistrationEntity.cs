using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVehicle.DAL.Entities
{
    [Table("VehicleRegistration")]
    public class VehicleRegistrationEntity
    {
        [Key]
        public int ID { get; set; }
        public string RegistrationNumber { get; set; }
        public int VehicleModelId { get; set; }              
        public int VehicleOwnerId { get; set; }        
        [ForeignKey("VehicleModelId")]
        public virtual VehicleModelEntity VehicleModel { get; set; }
        [ForeignKey("VehicleOwnerId")]
        public virtual VehicleOwnerEntity VehicleOwner { get; set; }
    }
}
