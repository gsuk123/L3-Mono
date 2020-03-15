using AutoMapper;
using PagedList;
using ProjectVehicle.DAL;
using ProjectVehicle.Model;
using ProjectVehicle.Model.Common;
using ProjectVehicle.Service.Common;
using ProjectVehicle.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace ProjectVehicle.WebAPI.Controllers
{
    
    public class VehicleMakeController : ApiController
    {
        private readonly IVehicleMakeService vehicleMakeService;
        private readonly IMapper mapper;
        private readonly IHelperFactory helperFactory;


        public VehicleMakeController(IVehicleMakeService vehicleMakeService, IMapper mapper, IHelperFactory helperFactory)
        {
            this.mapper = mapper;
            this.vehicleMakeService = vehicleMakeService;
            this.helperFactory = helperFactory;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetVehicleMake(int id)
        {
            try
            {
                var vehicleMake = await vehicleMakeService.GetVehicleMakeServiceAsync(id);
                if (vehicleMake == null)
                {
                    return NotFound();
                }
                VehicleMakeRestModel vehicleMakeRM = mapper.Map<VehicleMakeRestModel>(vehicleMake);
                return Ok(vehicleMakeRM);
            }
            catch
            {
                return InternalServerError();
            }
        }


        [HttpGet]        
        public async Task<IEnumerable<VehicleMakeRestModel>> GetAllVehicles()
        {
            var vehicleMake = await vehicleMakeService.GetVehicleMakesServiceAsync();
            var vehicleMakeList = new List<VehicleMakeRestModel>();
            foreach (var v in vehicleMake)
            {
                VehicleMakeRestModel vehicleMakeRest = mapper.Map<VehicleMakeRestModel>(v);
                vehicleMakeList.Add(vehicleMakeRest);
            }
            return vehicleMakeList;
        }

        [HttpPost]
        public async Task<IHttpActionResult> CreateVehicleMake([FromBody]VehicleMakeRestModel vehicleMakeRM)
        {
            try
            {
                var vehicleMake = mapper.Map<IVehicleMake>(vehicleMakeRM);
                await vehicleMakeService.CreateVehicleMakeServiceAsync(vehicleMake);
                return Ok(vehicleMake);
            }
            catch
            {
                return InternalServerError();
            }

        }

        [HttpPut]
        public async Task<IHttpActionResult> EditVehicleMake([FromBody]VehicleMakeRestModel vehicleMakeRM, int id)
        {
            try
            {
                var vehicleMake = mapper.Map<IVehicleMake>(vehicleMakeRM);
                await vehicleMakeService.EditVehicleMakeServiceAsync(vehicleMake, id);
                return Ok(vehicleMake);
            }
            catch
            {
                return InternalServerError();
            }

        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeleteVehicleMake(int id)
        {
            try
            {
                await vehicleMakeService.DeleteVehicleMakeServiceAsync(id);
                return Ok();
            }
            catch
            {
                return InternalServerError();
            }

        }

        [HttpGet]
        public async Task<IPagedList<VehicleMakeRestModel>> Find(
            string sortVehicle = null, 
            string searchVehicle = null,
            int? pageVehicle = null)
        {
            var filter = helperFactory.CreateVehicleFiltering();
            filter.Filter = searchVehicle;
            var sort = helperFactory.CreateVehicleSorting();
            sort.Sort = sortVehicle;
            var page = helperFactory.CreateVehiclePaging();
            page.Page = pageVehicle;

            var vehicles = await vehicleMakeService.FindVehicleMakeServiceAsync(sort, filter, page);
            var vehiclesList = new List<VehicleMakeRestModel>();
            foreach(var v in vehicles)
            {
                VehicleMakeRestModel vehicleMakeRM = mapper.Map<VehicleMakeRestModel>(v);
                vehiclesList.Add(vehicleMakeRM);
            }
            var vehiclePagedList = new StaticPagedList<VehicleMakeRestModel>(vehiclesList, vehicles.PageNumber, vehicles.PageSize, vehicles.TotalItemCount);
            return vehiclePagedList;
        }

    }
}
