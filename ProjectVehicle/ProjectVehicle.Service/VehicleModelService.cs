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
    public class VehicleModelService : IVehicleModelService
    {
        private readonly IVehicleModelRepository vehicleModelRepository;

        public VehicleModelService(IVehicleModelRepository vehicleModelRepository)
        {
            this.vehicleModelRepository = vehicleModelRepository;
        }

        public async Task<IVehicleModel> GetVehicleModelById(int id)
        {
            return await vehicleModelRepository.GetVehicleModelIdAsync(id);            
        }


        public async Task<IEnumerable<IVehicleModel>> GetVehicleModelsAsync()
        {
            return await vehicleModelRepository.GetSomeVehiclesModelsAsync();            
        }

        public async Task CreateVehicleModelServiceAsync(IVehicleModel vehicleModel)
        {
            await vehicleModelRepository.CreateVehicleModelAsync(vehicleModel);
        }
        public async Task EditVehicleModelServiceAsync(IVehicleModel vehicleModel, int id)
        {
            await vehicleModelRepository.EditVehicleModelAsync(vehicleModel, id);
        }

        public async Task DeleteVehicleModelService(int id)
        {
            await vehicleModelRepository.DeleteVehicleModelAsync(id);            
        }


    }
}
