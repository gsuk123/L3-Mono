using PagedList;
using ProjectVehicle.Common.Contracts;
using ProjectVehicle.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVehicle.Service.Common
{
    public interface IVehicleRegistrationService
    {       
        Task<IVehicleRegistration> GetRegistrationServiceAsync(int id);
        Task CreateRegistrationServiceAsync(IVehicleRegistration vehicleRegistration);
        Task EditRegistrationServiceAsync(IVehicleRegistration vehicleRegistration, int id);
        Task DeleteRegistrationServiceAsync(int id);
        Task<IPagedList<IVehicleRegistration>> GetRegistrationsServiceAsync(IVehicleSorting sort, IVehicleFiltering filter, IVehiclePaging page);
    }
}
