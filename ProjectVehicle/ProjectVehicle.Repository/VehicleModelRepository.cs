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
    public class VehicleModelRepository : Repository<VehicleModelEntity>, IVehicleModelRepository
    {
        private readonly IMapper mapper;

        public VehicleModelRepository(VehicleContext context, IMapper mapper)
            : base(context)
        {
            this.mapper = mapper;
        }

        public async Task<IVehicleModel> GetVehicleModelIdAsync(int id)
        {
            var vehicleModelEntity = await base.GetIdAsync(id);
            IVehicleModel vehicleModel = mapper.Map<IVehicleModel>(vehicleModelEntity);
            return vehicleModel;
        }

        public async Task<IEnumerable<IVehicleModel>> GetVehiclesModelsAsync()
        {
            var entites = await base.GetAllAsync();
            var mappedResult = mapper.Map<List<IVehicleModel>>(entites.ToList());
            return mappedResult;
        }

        public async Task CreateVehicleModelAsync(IVehicleModel vehicleModel)
        {
            VehicleModelEntity vehicleModelEM = mapper.Map<VehicleModelEntity>(vehicleModel);
            await base.AddAsync(vehicleModelEM);
        }

        public async Task EditVehicleModelAsync(IVehicleModel vehicleModel, int id)
        {
            VehicleModelEntity vehicleModelEM = mapper.Map<VehicleModelEntity>(vehicleModel);
            await base.UpdateAsync(vehicleModelEM, id);
        }

        public async Task DeleteVehicleModelAsync(int id)
        {
            var vehicleModelEntity = await base.GetIdAsync(id);
            await base.DeleteAsync(vehicleModelEntity);
        }
    }
}
