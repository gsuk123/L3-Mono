using PagedList;
using ProjectVehicle.Common.Contracts;
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
       
        Task<IVehicleModel> GetVehicleModelIdAsync(int id);
        Task CreateVehicleModelAsync(IVehicleModel vehicleModel);
        Task DeleteVehicleModelAsync(int id);
        Task EditVehicleModelAsync(IVehicleModel vehicleModel, int id);
        Task<IPagedList<IVehicleModel>> GetVehicleModelsAsync(IVehicleSorting sort, IVehicleFiltering filter, IVehiclePaging page, int? makeId = null);
    }
}
