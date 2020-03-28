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
    public class VehicleEngineTypeService : IVehicleEngineTypeService
    {
        private readonly IVehicleEngineTypeRepository vehicleEngineTypeRepository;
        public VehicleEngineTypeService(IVehicleEngineTypeRepository vehicleEngineTypeRepository)
        {
            this.vehicleEngineTypeRepository = vehicleEngineTypeRepository;
        }

        public Task<IEnumerable<IVehicleEngineType>> GetEngineTypeServiceAsync()
        {
            return vehicleEngineTypeRepository.GetAllEngineTypeAsync();
        }
    }
}
