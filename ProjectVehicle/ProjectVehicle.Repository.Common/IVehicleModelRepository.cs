using ProjectVehicle.DAL.Entities;
using ProjectVehicle.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVehicle.Repository.Common
{
    public interface IVehicleModelRepository : IRepository<VehicleModelEntity>
    {
        Task<IEnumerable<IVehicleModel>> GetSomeVehiclesModelsAsync();
        Task<IVehicleModel> GetVehicleModelIdAsync(int id);
        Task CreateVehicleModelAsync(IVehicleModel vehicleModel);
        Task DeleteVehicleModelAsync(int id);
        Task EditVehicleModelAsync(IVehicleModel vehicleModel, int id);
    }
}
