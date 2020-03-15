using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVehicle.Repository.Common
{
    public interface IUnitOfWork : IDisposable
    {
        IVehicleMakeRepository VehiclesMakes { get; }
        //IVehicleModelRepository VehiclesModels { get; }
        int Complete();
    }
}
