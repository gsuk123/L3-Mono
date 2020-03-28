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
    public interface IVehicleRegistrationRepository : IRepository<VehicleRegistrationEntity>
    {
        Task<IVehicleRegistration> GetRegistrationAsync(int id);               
        Task DeleteRegistrationAsync(int id);
        Task CreateRegistrationAsync(IVehicleRegistration vehicleRegistration);
        Task EditRegistrationAsync(IVehicleRegistration vehicleRegistration, int id);
        Task<IPagedList<IVehicleRegistration>> GetRegistrationsAsync(IVehicleSorting sort, IVehicleFiltering filter, IVehiclePaging page);
    }
}
