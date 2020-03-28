using AutoMapper;
using PagedList;
using ProjectVehicle.Common.Contracts;
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
    public class VehicleRegistrationRepository : Repository<VehicleRegistrationEntity>, IVehicleRegistrationRepository
    {
        private readonly IMapper mapper;
        public VehicleRegistrationRepository(VehicleContext context, IMapper mapper)
            :base(context)
        {
            this.mapper = mapper;
        }

        public async Task<IPagedList<IVehicleRegistration>> GetRegistrationsAsync(IVehicleSorting sort, IVehicleFiltering filter, IVehiclePaging page)
        {
            var vehicleRegistrationsEntity = await base.GetAllAsync();

            var searchRegistration = filter.Filter;
            var sortRegistration = sort.Sort;

            if (!String.IsNullOrEmpty(searchRegistration))
            {
                vehicleRegistrationsEntity = vehicleRegistrationsEntity.Where(v => v.RegistrationNumber.Contains(searchRegistration));
            }
            switch (sortRegistration)
            {
                case "reg_desc":
                    vehicleRegistrationsEntity = vehicleRegistrationsEntity.OrderByDescending(v => v.RegistrationNumber);
                    break;
                case "reg_asc":
                    vehicleRegistrationsEntity = vehicleRegistrationsEntity.OrderBy(v => v.RegistrationNumber);
                    break;
                default:
                    vehicleRegistrationsEntity = vehicleRegistrationsEntity.OrderBy(v => v.RegistrationNumber);
                    break;
            }

            int pageSize = 3;
            var totalItemCount = vehicleRegistrationsEntity.Count();

            var pageCount = (double)totalItemCount / pageSize;
            var pageNumber = (int)Math.Ceiling(pageCount);

            var skip = ((page.Page ?? 1) - 1) * pageSize;
            var pageResult = vehicleRegistrationsEntity.Skip(skip).Take(pageSize).ToList();
            var vehicleRegistrationsList = mapper.Map<List<IVehicleRegistration>>(pageResult);

            return new StaticPagedList<IVehicleRegistration>(vehicleRegistrationsList, pageNumber, pageSize, totalItemCount);
        }
        public async Task<IVehicleRegistration> GetRegistrationAsync(int id)
        {
            var vehicleRegistrationEntity = await base.GetIdAsync(id);
            IVehicleRegistration vehicleRegistration = mapper.Map<IVehicleRegistration>(vehicleRegistrationEntity);
            return vehicleRegistration;
        }        
        public async Task CreateRegistrationAsync(IVehicleRegistration vehicleRegistration)
        {
            VehicleRegistrationEntity vehicleRegistrationEntity = mapper.Map<VehicleRegistrationEntity>(vehicleRegistration);
            await base.AddAsync(vehicleRegistrationEntity);
        }
        public async Task EditRegistrationAsync(IVehicleRegistration vehicleRegistration, int id)
        {
            VehicleRegistrationEntity vehicleRegistrationEntity = mapper.Map<VehicleRegistrationEntity>(vehicleRegistration);
            await base.UpdateAsync(vehicleRegistrationEntity, id);
        }

        public async Task DeleteRegistrationAsync(int id)
        {
            var vehicleRegistrationEntity = await base.GetIdAsync(id);
            await base.DeleteAsync(vehicleRegistrationEntity);
        }

    }
}
