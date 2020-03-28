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

        public async Task<IPagedList<IVehicleModel>> GetVehicleModelsAsync(IVehicleSorting sort, IVehicleFiltering filter, IVehiclePaging page, int? makeId = null)
        {
            var vehicleModelsEntity = await base.GetAllAsync();

            var searchModel = filter.Filter;
            var sortModel = sort.Sort;

            if (makeId.HasValue)
            {
                vehicleModelsEntity = vehicleModelsEntity.Where(m => m.VehicleMakeID == makeId);
            }
            if (!String.IsNullOrEmpty(searchModel))
            {
                vehicleModelsEntity = vehicleModelsEntity.Where(v => v.ModelName.Contains(searchModel));
            }
            switch (sortModel)
            {
                case "model_desc":
                    vehicleModelsEntity = vehicleModelsEntity.OrderByDescending(v => v.ModelName);
                    break;
                case "year_asc":
                    vehicleModelsEntity = vehicleModelsEntity.OrderBy(v => v.ModelYear);
                    break;
                case "year_desc":
                    vehicleModelsEntity = vehicleModelsEntity.OrderByDescending(v => v.ModelYear);
                    break;
                default:
                    vehicleModelsEntity = vehicleModelsEntity.OrderBy(v => v.ModelName);
                    break;
            }

            int pageSize = 3;
            var totalItemCount = vehicleModelsEntity.Count();

            var pageCount = (double)totalItemCount / pageSize;
            var pageNumber = (int)Math.Ceiling(pageCount);

            var skip = ((page.Page ?? 1) - 1) * pageSize;
            var pageResult = vehicleModelsEntity.Skip(skip).Take(pageSize).ToList();
            var vehicleModelsList = mapper.Map<List<IVehicleModel>>(pageResult);

            return new StaticPagedList<IVehicleModel>(vehicleModelsList, pageNumber, pageSize, totalItemCount);
        }

        public async Task<IVehicleModel> GetVehicleModelIdAsync(int id)
        {
            var vehicleModelEntity = await base.GetIdAsync(id);
            IVehicleModel vehicleModel = mapper.Map<IVehicleModel>(vehicleModelEntity);
            return vehicleModel;
        }

        public async Task CreateVehicleModelAsync(IVehicleModel vehicleModel)
        {
            VehicleModelEntity vehicleModelEntity = mapper.Map<VehicleModelEntity>(vehicleModel);
            await base.AddAsync(vehicleModelEntity);
        }

        public async Task EditVehicleModelAsync(IVehicleModel vehicleModel, int id)
        {
            VehicleModelEntity vehicleModelEntity = mapper.Map<VehicleModelEntity>(vehicleModel);
            await base.UpdateAsync(vehicleModelEntity, id);
        }

        public async Task DeleteVehicleModelAsync(int id)
        {
            var vehicleModelEntity = await base.GetIdAsync(id);
            await base.DeleteAsync(vehicleModelEntity);
        }


    }
}
