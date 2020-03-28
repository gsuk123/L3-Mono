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
    public class VehicleOwnerRepository : Repository<VehicleOwnerEntity>, IVehicleOwnerRepository
    {
        private readonly IMapper mapper;
        public VehicleOwnerRepository(VehicleContext context, IMapper mapper)
            : base(context)
        {
            this.mapper = mapper;
        }

        public async Task<IPagedList<IVehicleOwner>> GetOwnersAsync(IVehicleSorting sort, IVehicleFiltering filter, IVehiclePaging page)
        {
            var vehicleOwnersEntity = await base.GetAllAsync();

            var searchOwner = filter.Filter;
            var sortOwner = sort.Sort;

            if (!String.IsNullOrEmpty(searchOwner))
            {
                vehicleOwnersEntity = vehicleOwnersEntity.Where(v => v.FirstName.Contains(searchOwner));
            }
            switch (sortOwner)
            {
                case "fname_desc":
                    vehicleOwnersEntity = vehicleOwnersEntity.OrderByDescending(v => v.FirstName);
                    break;
                case "lname_desc":
                    vehicleOwnersEntity = vehicleOwnersEntity.OrderBy(v => v.LastName);
                    break;
                default:
                    vehicleOwnersEntity = vehicleOwnersEntity.OrderBy(v => v.FirstName);
                    break;
            }

            int pageSize = 3;
            var totalItemCount = vehicleOwnersEntity.Count();

            var pageCount = (double)totalItemCount / pageSize;
            var pageNumber = (int)Math.Ceiling(pageCount);

            var skip = ((page.Page ?? 1) - 1) * pageSize;
            var pageResult = vehicleOwnersEntity.Skip(skip).Take(pageSize).ToList();
            var vehicleOwnersList = mapper.Map<List<IVehicleOwner>>(pageResult);

            return new StaticPagedList<IVehicleOwner>(vehicleOwnersList, pageNumber, pageSize, totalItemCount);
        }

        public async Task<IVehicleOwner> GetOwnerAsync(int id)
        {
            var vehicleOwnerEntity = await base.GetIdAsync(id);
            IVehicleOwner vehicleOwner = mapper.Map<IVehicleOwner>(vehicleOwnerEntity);
            return vehicleOwner;
        }

        public async Task CreateOwnerAsync(IVehicleOwner vehicleOwner)
        {
            VehicleOwnerEntity vehicleOwnerEntity = mapper.Map<VehicleOwnerEntity>(vehicleOwner);
            await base.AddAsync(vehicleOwnerEntity);
        }

        public async Task EditOwnerAsync(IVehicleOwner vehicleOwner, int id)
        {
            VehicleOwnerEntity vehicleOwnerEntity = mapper.Map<VehicleOwnerEntity>(vehicleOwner);
            await base.UpdateAsync(vehicleOwnerEntity, id);
        }

        public async Task DeleteOwnerAsync(int id)
        {
            var vehicleOwnerEntity = await base.GetIdAsync(id);
            await base.DeleteAsync(vehicleOwnerEntity);
        }

    }
}
