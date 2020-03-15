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

        public Task<IVehicleModel> GetVehicleModelServiceAsync(int id)
        {
            return vehicleModelRepository.GetVehicleModelIdAsync(id);            
        }

        public Task<IEnumerable<IVehicleModel>> GetVehiclesModelsServiceAsync()
        {
            return vehicleModelRepository.GetVehiclesModelsAsync();            
        }

        public Task CreateVehicleModelServiceAsync(IVehicleModel vehicleModel)
        {
            return vehicleModelRepository.CreateVehicleModelAsync(vehicleModel);
        }
        public Task EditVehicleModelServiceAsync(IVehicleModel vehicleModel, int id)
        {
            return vehicleModelRepository.EditVehicleModelAsync(vehicleModel, id);
        }

        public Task DeleteVehicleModelServiceAsync(int id)
        {
            return vehicleModelRepository.DeleteVehicleModelAsync(id);            
        }

    }
}
