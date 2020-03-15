using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectVehicle.DAL.Entities
{
    [Table("VehicleMake")]
    public class VehicleMakeEntity
    {        
        [Key]
        public int ID { get; set; }
        public string ManufacturerName { get; set; }
        public string MadeIn { get; set; }
        public virtual ICollection<VehicleModelEntity> VehicleModels { get; set; }
    }
    
}
