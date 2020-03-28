using PagedList;
using ProjectVehicle.Common.Contracts;
using ProjectVehicle.Model.Common;
using ProjectVehicle.Repository.Common;
using ProjectVehicle.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVehicle.Service
{
    public class VehicleRegistrationService : IVehicleRegistrationService
    {
        private readonly IVehicleRegistrationRepository vehicleRegistrationRepository;
        public VehicleRegistrationService(IVehicleRegistrationRepository vehicleRegistrationRepository)
        {
            this.vehicleRegistrationRepository = vehicleRegistrationRepository;
        }

        public Task<IVehicleRegistration> GetRegistrationServiceAsync(int id)
        {
            return vehicleRegistrationRepository.GetRegistrationAsync(id);
        }
        public Task CreateRegistrationServiceAsync(IVehicleRegistration vehicleRegistration)
        {
            return vehicleRegistrationRepository.CreateRegistrationAsync(vehicleRegistration);
        }
        public Task EditRegistrationServiceAsync(IVehicleRegistration vehicleRegistration, int id)
        {
            return vehicleRegistrationRepository.EditRegistrationAsync(vehicleRegistration, id);
        }
        public Task DeleteRegistrationServiceAsync(int id)
        {
            return vehicleRegistrationRepository.DeleteRegistrationAsync(id);
        }
        public Task<IPagedList<IVehicleRegistration>> GetRegistrationsServiceAsync(IVehicleSorting sort, IVehicleFiltering filter, IVehiclePaging page)
        {
            return vehicleRegistrationRepository.GetRegistrationsAsync(sort, filter, page);
        }

    }
}
