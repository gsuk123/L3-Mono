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
    public class VehicleOwnerService : IVehicleOwnerService
    {
        private readonly IVehicleOwnerRepository vehicleOwnerRepository;
        public VehicleOwnerService(IVehicleOwnerRepository vehicleOwnerRepository)
        {
            this.vehicleOwnerRepository = vehicleOwnerRepository; 
        }

        public Task<IPagedList<IVehicleOwner>> GetOwnersServiceAsync(IVehicleSorting sort, IVehicleFiltering filter, IVehiclePaging page)
        {
            return vehicleOwnerRepository.GetOwnersAsync(sort, filter, page);
        }
        public Task<IVehicleOwner> GetOwnerServiceAsync(int id)
        {
            return vehicleOwnerRepository.GetOwnerAsync(id);
        }
        public Task CreateOwnerServiceAsync(IVehicleOwner vehicleOwner)
        {
            return vehicleOwnerRepository.CreateOwnerAsync(vehicleOwner);
        }
        public Task EditOwnerServiceAsync(IVehicleOwner vehicleOwner, int id)
        {
            return vehicleOwnerRepository.EditOwnerAsync(vehicleOwner, id);
        }
        public Task DeleteOwnerServiceAsync(int id)
        {
            return vehicleOwnerRepository.DeleteOwnerAsync(id);
        }
    }
}
