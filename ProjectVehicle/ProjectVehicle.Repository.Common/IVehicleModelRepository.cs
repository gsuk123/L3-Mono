using PagedList;
using ProjectVehicle.DAL.Entities;
using ProjectVehicle.Model.Common;
using ProjectVehicle.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVehicle.Repository.Common
{
    public interface IVehicleModelRepository : IRepository<VehicleModelEntity>
    {
        Task<IEnumerable<IVehicleModel>> GetVehiclesModelsAsync();
        Task<IVehicleModel> GetVehicleModelIdAsync(int id);
        Task CreateVehicleModelAsync(IVehicleModel vehicleModel);
        Task DeleteVehicleModelAsync(int id);
        Task EditVehicleModelAsync(IVehicleModel vehicleModel, int id);

        Task<IPagedList<IVehicleModel>> FindVehicleModelAsync(IVehicleSorting sort, IVehicleFiltering filter, IVehiclePaging page, int? makeId = null);
    }
}
