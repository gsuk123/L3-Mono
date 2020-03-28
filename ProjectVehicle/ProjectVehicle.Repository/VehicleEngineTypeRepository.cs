using AutoMapper;
using ProjectVehicle.DAL;
using ProjectVehicle.DAL.Entities;
using ProjectVehicle.Model.Common;
using ProjectVehicle.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVehicle.Repository
{
    public class VehicleEngineTypeRepository : Repository<VehicleEngineTypeEntity>, IVehicleEngineTypeRepository
    {
        private readonly IMapper mapper;
        public VehicleEngineTypeRepository(VehicleContext context, IMapper mapper)
            :base(context)
        {
            this.mapper = mapper;
        }

        public async Task<IEnumerable<IVehicleEngineType>> GetAllEngineTypeAsync()
        {
            var vehicleEngineTypeEntities = await base.GetAllAsync();
            var vehicleEngineTypes = mapper.Map<List<IVehicleEngineType>>(vehicleEngineTypeEntities.ToList());
            return vehicleEngineTypes;
        }
    }
}
