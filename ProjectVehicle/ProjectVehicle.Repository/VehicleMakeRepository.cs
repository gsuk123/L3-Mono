using AutoMapper;
using PagedList;
using ProjectVehicle.Common.Contracts;
using ProjectVehicle.DAL;
using ProjectVehicle.DAL.Entities;
using ProjectVehicle.Model;
using ProjectVehicle.Model.Common;
using ProjectVehicle.Repository.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVehicle.Repository
{
    public class VehicleMakeRepository : Repository<VehicleMakeEntity>, IVehicleMakeRepository
    {
        private readonly IMapper mapper;

        public VehicleMakeRepository(VehicleContext context, IMapper mapper)
            : base(context)
        {
            this.mapper = mapper;
        }

        public async Task<IPagedList<IVehicleMake>> GetVehiclesMakeAsync(IVehicleSorting sort, IVehicleFiltering filter, IVehiclePaging page, IVehiclePaging pageSizeTest)
        {
            var vehicleMakesEntity = await base.GetAllAsync();
            

            var searchVehicle = filter.Filter;
            var sortVehicle = sort.Sort;
            var pageSizeVehicle = pageSizeTest.PageSize;
            int defaultPageSize = 3;

            if (!String.IsNullOrEmpty(searchVehicle))
            {
                vehicleMakesEntity = vehicleMakesEntity.Where(v => v.ManufacturerName.Contains(searchVehicle)
                                       || v.MadeIn.Contains(searchVehicle));
            }
            switch (sortVehicle)
            {
                case "name_desc":
                    vehicleMakesEntity = vehicleMakesEntity.OrderByDescending(v => v.ManufacturerName); 
                    break;
                case "madein_desc":
                    vehicleMakesEntity = vehicleMakesEntity.OrderByDescending(v => v.MadeIn);
                    break;
                default:
                    vehicleMakesEntity = vehicleMakesEntity.OrderBy(v => v.ManufacturerName);
                    break;
            }

            int pageSize = pageSizeVehicle ?? defaultPageSize;

            var totalItemCount = vehicleMakesEntity.Count(); 
            
            var pageCount = (double)totalItemCount / pageSize;
            var pageNumber = (int)Math.Ceiling(pageCount);

            var skip = ((page.Page ?? 1) - 1) * pageSize;
            var pageResult = vehicleMakesEntity.Skip(skip).Take(pageSize).ToList();
            var vehicleMakesList = mapper.Map<List<IVehicleMake>>(pageResult);

            return new StaticPagedList<IVehicleMake>(vehicleMakesList, pageNumber, pageSize, totalItemCount);
        }

        public async Task<IVehicleMake> GetVehicleMakeAsync(int id)
        {
            var vehicleMakeEntity = await base.GetIdAsync(id);
            IVehicleMake vehicleMake = mapper.Map<IVehicleMake>(vehicleMakeEntity);
            return vehicleMake;
        }

        public async Task CreateVehicleMakeAsync(IVehicleMake vehicleMake)
        {
            VehicleMakeEntity vehicleMakeEntity = mapper.Map<VehicleMakeEntity>(vehicleMake);
            await base.AddAsync(vehicleMakeEntity);
        }

        public async Task EditVehicleMakeAsync(IVehicleMake vehicleMake, int id)
        {
            VehicleMakeEntity vehicleMakeEntity = mapper.Map<VehicleMakeEntity>(vehicleMake);
            await base.UpdateAsync(vehicleMakeEntity, id);
        }

        public async Task DeleteVehicleMakeAsync(int id)
        {
            var vehicleMakeEntity = await base.GetIdAsync(id);
            await base.DeleteAsync(vehicleMakeEntity);       

        }
    }
}
