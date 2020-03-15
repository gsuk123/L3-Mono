using AutoMapper;
using PagedList;
using ProjectVehicle.DAL;
using ProjectVehicle.DAL.Entities;
using ProjectVehicle.Model;
using ProjectVehicle.Model.Common;
using ProjectVehicle.Repository.Common;
using ProjectVehicle.Service.Common;
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

        public async Task<IVehicleMake> GetVehicleMakeAsync(int id)
        {
            var vehicleMakeEntity = await base.GetIdAsync(id);
            IVehicleMake vehicleMake = mapper.Map<IVehicleMake>(vehicleMakeEntity);
            return vehicleMake;
        }

        public async Task<IEnumerable<IVehicleMake>> GetAllVehiclesAsync()
        {
            var entites = await base.GetAllAsync();
            var mappedResult = mapper.Map<List<IVehicleMake>>(entites.ToList());
            return mappedResult;
        }
        public async Task CreateVehicleMakeAsync(IVehicleMake vehicleMake)
        {
            VehicleMakeEntity vehicleMakeEM = mapper.Map<VehicleMakeEntity>(vehicleMake);
            await base.AddAsync(vehicleMakeEM);
        }

        public async Task EditVehicleMakeAsync(IVehicleMake vehicleMake, int id)
        {
            VehicleMakeEntity vehicleMakeEM = mapper.Map<VehicleMakeEntity>(vehicleMake);
            await base.UpdateAsync(vehicleMakeEM, id);
        }

        public async Task DeleteVehicleMakeAsync(int id)
        {
            var vehicleMakeEntity = await base.GetIdAsync(id);
            await base.DeleteAsync(vehicleMakeEntity);         
            
        }

        public async Task<IPagedList<IVehicleMake>> FindVehicleMakeAsync(IVehicleSorting sort, IVehicleFiltering filter, IVehiclePaging page)
        {
            var vehicles = await base.GetAllAsync();

            var searchVehicle = filter.Filter;
            var sortVehicle = sort.Sort;

            if (!String.IsNullOrEmpty(searchVehicle))
            {
                vehicles = vehicles.Where(v => v.ManufacturerName.Contains(searchVehicle)
                                       || v.MadeIn.Contains(searchVehicle));
            }
            switch (sortVehicle)
            {
                case "name_desc":
                    vehicles = vehicles.OrderByDescending(v => v.ManufacturerName);
                    break;
                case "madein_desc":
                    vehicles = vehicles.OrderByDescending(v => v.MadeIn);
                    break;
                default:
                    vehicles = vehicles.OrderBy(v => v.ManufacturerName);
                    break;
            }
            var mappedList = mapper.Map<List<IVehicleMake>>(vehicles.ToList());
            var pagedList = mappedList.ToPagedList(page.Page ?? 1, 3);

            return pagedList;

        }

    }
}
