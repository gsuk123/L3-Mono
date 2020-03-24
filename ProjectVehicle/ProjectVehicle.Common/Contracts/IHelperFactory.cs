using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVehicle.Common.Contracts
{
    public interface IHelperFactory
    {
        IVehiclePaging CreateVehiclePaging();
        IVehicleFiltering CreateVehicleFiltering();
        IVehicleSorting CreateVehicleSorting();
    }
}
