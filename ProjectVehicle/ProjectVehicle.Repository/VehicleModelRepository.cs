using AutoMapper;
using PagedList;
using ProjectVehicle.Common.Contracts;
using ProjectVehicle.DAL;
using ProjectVehicle.DAL.Entities;
using ProjectVehicle.Model.Common;
using ProjectVehicle.Repository.Common;
using ProjectVehicle.Service.Common;
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

        public async Task<IPagedList<IVehicleModel>> FindVehicleModelAsync(IVehicleSorting sort, IVehicleFiltering filter, IVehiclePaging page, int? makeId = null)
        {
            var vehicleModels = await base.GetAllAsync();

            var searchVehicle = filter.Filter;
            var sortVehicle = sort.Sort;

            if (makeId.HasValue)
            {
                vehicleModels = vehicleModels.Where(m => m.VehicleMakeID == makeId);
            }
            if (!String.IsNullOrEmpty(searchVehicle))
            {
                vehicleModels = vehicleModels.Where(v => v.ModelName.Contains(searchVehicle));
            }
            switch (sortVehicle)
            {
                case "model_desc":
                    vehicleModels = vehicleModels.OrderByDescending(v => v.ModelName);
                    break;
                case "Year":
                    vehicleModels = vehicleModels.OrderBy(v => v.ModelYear);
                    break;
                case "year_desc":
                    vehicleModels = vehicleModels.OrderByDescending(v => v.ModelYear);
                    break;
                default:
                    vehicleModels = vehicleModels.OrderBy(v => v.ModelName);
                    break;
            }

            var mappedList = mapper.Map<List<IVehicleModel>>(vehicleModels.ToList());
            var pagedList = mappedList.ToPagedList(page.Page ?? 1, 3);

            return pagedList;
        }
    }
}
