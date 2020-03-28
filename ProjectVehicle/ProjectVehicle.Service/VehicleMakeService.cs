using PagedList;
using ProjectVehicle.Common.Contracts;
using ProjectVehicle.Model;
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
    public class VehicleMakeService : IVehicleMakeService
    {
        private readonly IVehicleMakeRepository vehicleMakeRepository;
        
        public VehicleMakeService(IVehicleMakeRepository vehicleMakeRepository)
        {
            this.vehicleMakeRepository = vehicleMakeRepository;
        }
        public Task<IVehicleMake> GetVehicleMakeServiceAsync(int id)
        {
            return vehicleMakeRepository.GetVehicleMakeAsync(id);            
        }
        public Task CreateVehicleMakeServiceAsync(IVehicleMake vehicleMake)
        {
            return vehicleMakeRepository.CreateVehicleMakeAsync(vehicleMake);
        }
        public Task EditVehicleMakeServiceAsync(IVehicleMake vehicleMake, int id)
        {
            return vehicleMakeRepository.EditVehicleMakeAsync(vehicleMake, id);
        }
        public Task DeleteVehicleMakeServiceAsync(int id)
        {
            return vehicleMakeRepository.DeleteVehicleMakeAsync(id);            
        }        
        public Task<IPagedList<IVehicleMake>> GetVehiclesMakeServiceAsync(IVehicleSorting sort, IVehicleFiltering filter, IVehiclePaging page)
        {
            return vehicleMakeRepository.GetVehiclesMakeAsync(sort, filter, page);
        }
    }
}
