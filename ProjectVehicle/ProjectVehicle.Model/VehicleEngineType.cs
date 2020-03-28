using ProjectVehicle.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVehicle.Model
{
    public class VehicleEngineType : IVehicleEngineType
    {
        public int ID { get; set; }
        public string EngineType { get; set; }
    }
}
