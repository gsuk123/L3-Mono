using ProjectVehicle.DAL.Entities;
using ProjectVehicle.Model;
using ProjectVehicle.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVehicle.Repository.Common
{
    public interface IVehicleMakeRepository : IRepository<VehicleMakeEntity>
    {
        Task<IVehicleMake> GetVehicleMakeIdAsync(int id);
        Task DeleteVehicleMakeAsync(int id);
        Task<IEnumerable<IVehicleMake>> GetSomeVehiclesAsync();
        Task CreateVehicleMakeAsync(IVehicleMake vehicleMake);
        Task EditVehicleMakeAsync(IVehicleMake vehicleMake, int id);

        Task<IEnumerable<IVehicleMake>> GetVehicleMakesByFilter(string filter);
    }
}
