using AutoMapper;
using PagedList;
using ProjectVehicle.Common.Contracts;
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
        public async Task<IPagedList<VehicleMakeRestModel>> GetVehiclesMake(
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

            var vehicleMakes = await vehicleMakeService.GetVehiclesMakeServiceAsync(sorting, filtering, paging);
            List<VehicleMakeRestModel> vehicleMakeList = mapper.Map<List<VehicleMakeRestModel>>(vehicleMakes.ToList());

            return new StaticPagedList<VehicleMakeRestModel>(vehicleMakeList, vehicleMakes.PageNumber, vehicleMakes.PageSize, vehicleMakes.TotalItemCount);            
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
                VehicleMakeRestModel vehicleMakeRest = mapper.Map<VehicleMakeRestModel>(vehicleMake);
                return Ok(vehicleMakeRest);
            }
            catch
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> CreateVehicleMake([FromBody]VehicleMakeRestModel vehicleMakeRest)
        {
            try
            {
                var vehicleMake = mapper.Map<IVehicleMake>(vehicleMakeRest);
                await vehicleMakeService.CreateVehicleMakeServiceAsync(vehicleMake);
                return Ok(vehicleMake);
            }
            catch
            {
                return InternalServerError();
            }

        }

        [HttpPut]
        public async Task<IHttpActionResult> EditVehicleMake([FromBody]VehicleMakeRestModel vehicleMakeRest, int id)
        {
            try
            {
                var vehicleMake = mapper.Map<IVehicleMake>(vehicleMakeRest);
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

    }
}
