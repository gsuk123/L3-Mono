using ProjectVehicle.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVehicle.Service.Common
{
    public interface IVehicleModelService
    {
        Task<IVehicleModel> GetVehicleModelById(int id);
        Task<IEnumerable<IVehicleModel>> GetVehicleModelsAsync();
        Task CreateVehicleModelServiceAsync(IVehicleModel vehicleModel);
        Task DeleteVehicleModelService(int id);
        Task EditVehicleModelServiceAsync(IVehicleModel vehicleModel, int id);

    }
}
