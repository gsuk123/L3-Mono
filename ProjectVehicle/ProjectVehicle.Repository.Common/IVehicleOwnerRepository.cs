using PagedList;
using ProjectVehicle.Common.Contracts;
using ProjectVehicle.DAL.Entities;
using ProjectVehicle.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVehicle.Repository.Common
{
    public interface IVehicleOwnerRepository : IRepository<VehicleOwnerEntity>
    {        
        Task<IPagedList<IVehicleOwner>> GetOwnersAsync(IVehicleSorting sort, IVehicleFiltering filter, IVehiclePaging page);
        Task<IVehicleOwner> GetOwnerAsync(int id);
        Task DeleteOwnerAsync(int id);
        Task CreateOwnerAsync(IVehicleOwner vehicleOwner);
        Task EditOwnerAsync(IVehicleOwner vehicleOwner, int id);
    }
}
