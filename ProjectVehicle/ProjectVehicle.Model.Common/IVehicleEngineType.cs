using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVehicle.Model.Common
{
    public interface IVehicleEngineType 
    {
        int ID { get; set; }
        string EngineType { get; set; }
    }
}
