using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVehicle.DAL.Entities
{
    [Table("VehicleOwner")]
    public class VehicleOwnerEntity
    {
        [Key]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<VehicleRegistrationEntity> VehicleRegistration { get; set; }
    }
}
