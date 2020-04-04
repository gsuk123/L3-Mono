using ProjectVehicle.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVehicle.Common
{
    public class VehiclePaging : IVehiclePaging
    {
        public int? Page { get; set; }
        public int? PageSize { get; set; }
    }
}
