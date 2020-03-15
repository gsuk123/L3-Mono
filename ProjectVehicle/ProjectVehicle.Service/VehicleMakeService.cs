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

        public async Task<IVehicleMake> GetVehicleMakeById(int id)
        {
            return await vehicleMakeRepository.GetVehicleMakeIdAsync(id);            
        }
        public async Task<IEnumerable<IVehicleMake>> GetVehicleMakesByFilterService(string filter)
        {
            return await vehicleMakeRepository.GetVehicleMakesByFilter(filter);
        }

        public  Task<IEnumerable<IVehicleMake>> GetVehicleMakesAsync()
        {
            return  vehicleMakeRepository.GetSomeVehiclesAsync();            
        }

        public async Task CreateVehicleMakeServiceAsync(IVehicleMake vehicleMake)
        {
            await vehicleMakeRepository.CreateVehicleMakeAsync(vehicleMake);
        }

        public async Task EditVehicleMakeServiceAsync(IVehicleMake vehicleMake, int id)
        {
            await vehicleMakeRepository.EditVehicleMakeAsync(vehicleMake, id);
        }
        public async Task DeleteVehicleMakeService(int id)
        {
            await vehicleMakeRepository.DeleteVehicleMakeAsync(id);            
        }

    }
}
