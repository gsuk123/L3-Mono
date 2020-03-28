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
    public class VehicleRegistrationController : ApiController
    {
        private readonly IVehicleRegistrationService vehicleRegistrationService;
        private readonly IMapper mapper;
        private readonly IHelperFactory helperFactory;
        public VehicleRegistrationController(IVehicleRegistrationService vehicleRegistrationService, IMapper mapper, IHelperFactory helperFactory)
        {
            this.vehicleRegistrationService = vehicleRegistrationService;
            this.mapper = mapper;
            this.helperFactory = helperFactory;
        }

        [HttpGet]
        public async Task<IPagedList<VehicleRegistrationRestModel>> GetRegistrations(
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

            var vehicleRegistrations = await vehicleRegistrationService.GetRegistrationsServiceAsync(sorting, filtering, paging);
            List<VehicleRegistrationRestModel> vehicleRegistrationsList = mapper.Map<List<VehicleRegistrationRestModel>>(vehicleRegistrations.ToList());

            return new StaticPagedList<VehicleRegistrationRestModel>(vehicleRegistrationsList, vehicleRegistrations.PageNumber, vehicleRegistrations.PageSize, vehicleRegistrations.TotalItemCount);            
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetRegistration(int id)
        {
            try
            {
                var vehicleRegistration = await vehicleRegistrationService.GetRegistrationServiceAsync(id);
                if (vehicleRegistration == null)
                {
                    return NotFound();
                }
                VehicleRegistrationRestModel vehicleRegistrationRest = mapper.Map<VehicleRegistrationRestModel>(vehicleRegistration);
                return Ok(vehicleRegistrationRest);
            }
            catch
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> CreateRegistration([FromBody] VehicleRegistrationRestModel vehicleRegistrationRest)
        {
            try
            {
                var vehicleRegistration = mapper.Map<IVehicleRegistration>(vehicleRegistrationRest);
                await vehicleRegistrationService.CreateRegistrationServiceAsync(vehicleRegistration);
                return Ok(vehicleRegistration);
            }
            catch
            {
                return InternalServerError();
            }
        }

        [HttpPut]
        public async Task<IHttpActionResult> EditRegistration([FromBody]VehicleRegistrationRestModel vehicleRegistrationRest, int id)
        {
            try
            {
                var vehicleRegistration = mapper.Map<IVehicleRegistration>(vehicleRegistrationRest);
                await vehicleRegistrationService.EditRegistrationServiceAsync(vehicleRegistration, id);
                return Ok();
            }
            catch
            {
                return InternalServerError();
            }

        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeleteRegistration(int id)
        {
            try
            {
                await vehicleRegistrationService.DeleteRegistrationServiceAsync(id);
                return Ok();
            }
            catch
            {
                return InternalServerError();
            }

        }

    }
}
