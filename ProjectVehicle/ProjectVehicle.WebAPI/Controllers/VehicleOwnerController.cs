using AutoMapper;
using PagedList;
using ProjectVehicle.Common.Contracts;
using ProjectVehicle.Model.Common;
using ProjectVehicle.Service.Common;
using ProjectVehicle.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ProjectVehicle.WebAPI.Controllers
{
    public class VehicleOwnerController : ApiController
    {
        private readonly IVehicleOwnerService vehicleOwnerService;
        private readonly IMapper mapper;
        private readonly IHelperFactory helperFactory;
        public VehicleOwnerController(IVehicleOwnerService vehicleOwnerService, IMapper mapper, IHelperFactory helperFactory)
        {
            this.vehicleOwnerService = vehicleOwnerService;
            this.mapper = mapper;
            this.helperFactory = helperFactory;
        }

        [HttpGet]
        public async Task<IPagedList<VehicleOwnerRestModel>> GetOwners(
            string sort = null,
            string search = null,
            int? page = null)
        {
            var filtering = helperFactory.CreateVehicleFiltering();
            filtering.Filter = search;
            var sorting = helperFactory.CreateVehicleSorting();
            sorting.Sort = sort;
            var paging = helperFactory.CreateVehiclePaging();
            paging.Page = page;

            var vehicleOwners = await vehicleOwnerService.GetOwnersServiceAsync(sorting, filtering, paging);
            List<VehicleOwnerRestModel> vehicleOwnersList = mapper.Map<List<VehicleOwnerRestModel>>(vehicleOwners.ToList());

            return new StaticPagedList<VehicleOwnerRestModel>(vehicleOwnersList, vehicleOwners.PageNumber, vehicleOwners.PageSize, vehicleOwners.TotalItemCount);            
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetOwner(int id)
        {
            try
            {
                var vehicleOwner = await vehicleOwnerService.GetOwnerServiceAsync(id);
                if (vehicleOwner == null)
                {
                    return NotFound();
                }
                VehicleOwnerRestModel vehicleOwnerRest = mapper.Map<VehicleOwnerRestModel>(vehicleOwner);
                return Ok(vehicleOwnerRest);
            }
            catch
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> CreateOwner([FromBody]VehicleOwnerRestModel vehicleOwnerRest)
        {
            try
            {
                var vehicleOwner = mapper.Map<IVehicleOwner>(vehicleOwnerRest);
                await vehicleOwnerService.CreateOwnerServiceAsync(vehicleOwner);
                return Ok(vehicleOwner);
            }
            catch
            {
                return InternalServerError();
            }
        }

        [HttpPut]
        public async Task<IHttpActionResult> EditOwner([FromBody]VehicleOwnerRestModel vehicleOwnerRest, int id)
        {
            try
            {
                var vehicleOwner = mapper.Map<IVehicleOwner>(vehicleOwnerRest);
                await vehicleOwnerService.EditOwnerServiceAsync(vehicleOwner, id);
                return Ok();
            }
            catch
            {
                return InternalServerError();
            }
        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeleteOwner(int id)
        {
            try
            {
                await vehicleOwnerService.DeleteOwnerServiceAsync(id);
                return Ok();
            }
            catch
            {
                return InternalServerError();
            }
        }

    }
}
