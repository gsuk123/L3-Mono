using ProjectVehicle.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVehicle.Service.Common
{
    public interface IVehicleEngineTypeService
    {
        Task<IEnumerable<IVehicleEngineType>> GetEngineTypeServiceAsync();
    }
}
