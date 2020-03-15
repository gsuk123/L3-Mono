using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVehicle.Model.Common
{
    public interface IVehicleMake
    {

        int ID { get; set; }
        string ManufacturerName { get; set; }
        string MadeIn { get; set; }

    }
}
