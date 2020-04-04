using PagedList;
using ProjectVehicle.Common.Contracts;
using ProjectVehicle.DAL.Entities;
using ProjectVehicle.Model;
using ProjectVehicle.Model.Common;
using ProjectVehicle.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVehicle.Repository.Common
{
    public interface IVehicleMakeRepository : IRepository<VehicleMakeEntity>
    {
        Task<IVehicleMake> GetVehicleMakeAsync(int id);
        Task DeleteVehicleMakeAsync(int id);        
        Task CreateVehicleMakeAsync(IVehicleMake vehicleMake);
        Task EditVehicleMakeAsync(IVehicleMake vehicleMake, int id);        
        Task<IPagedList<IVehicleMake>> GetVehiclesMakeAsync(IVehicleSorting sort, IVehicleFiltering filter, IVehiclePaging page, IVehiclePaging pageSizeTest);
    }
}
