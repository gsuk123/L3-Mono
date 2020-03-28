using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVehicle.DAL.Entities
{

    [Table("VehicleEngineType")]
    public class VehicleEngineTypeEntity
    {
        [Key]
        public int ID { get; set; }
        public string EngineType { get; set; }
        public virtual ICollection<VehicleModelEntity> VehicleModels { get; set; }
    }
}
