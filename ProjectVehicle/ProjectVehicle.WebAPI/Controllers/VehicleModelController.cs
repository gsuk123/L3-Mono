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
    public class VehicleModelController : ApiController
    {
        private readonly IVehicleModelService vehicleModelService;
        private readonly IMapper mapper;
        private readonly IHelperFactory helperFactory;

        public VehicleModelController(IVehicleModelService vehicleModelService, IMapper mapper, IHelperFactory helperFactory)
        {
            this.vehicleModelService = vehicleModelService;
            this.mapper = mapper;
            this.helperFactory = helperFactory;
        }

        [HttpGet]
        public async Task<IPagedList<VehicleModelRestModel>> GetVehicleModels(
                string sort = null,
                string search = null,
                int? page = null,
                int? makeId = null)
        {

            var filtering = helperFactory.CreateVehicleFiltering();
            filtering.Filter = search;
            var sorting = helperFactory.CreateVehicleSorting();
            sorting.Sort = sort;
            var paging = helperFactory.CreateVehiclePaging();
            paging.Page = page;

            var vehicleModels = await vehicleModelService.GetVehicleModelsServiceAsync(sorting, filtering, paging, makeId);
            List<VehicleModelRestModel> vehicleModelsList = mapper.Map<List<VehicleModelRestModel>>(vehicleModels.ToList());

            return new StaticPagedList<VehicleModelRestModel>(vehicleModelsList, vehicleModels.PageNumber, vehicleModels.PageSize, vehicleModels.TotalItemCount);            
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetVehicleModel(int id)
        {
            try
            {
                var vehicleModel = await vehicleModelService.GetVehicleModelServiceAsync(id);
                if (vehicleModel == null)
                {
                    return NotFound();
                }
                VehicleModelRestModel vehicleModelRest = mapper.Map<VehicleModelRestModel>(vehicleModel);
                return Ok(vehicleModelRest);
            }
            catch
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> CreateVehicleModel([FromBody]VehicleModelRestModel vehicleModelRest)
        {
            try
            {
                var vehicleModel = mapper.Map<IVehicleModel>(vehicleModelRest);
                await vehicleModelService.CreateVehicleModelServiceAsync(vehicleModel);
                return Ok(vehicleModel);
            }
            catch
            {
                return InternalServerError();
            }

        }

        [HttpPut]
        public async Task<IHttpActionResult> EditVehicleModel([FromBody]VehicleModelRestModel vehicleModelRest, int id)
        {
            try
            {
                var vehicleModel = mapper.Map<IVehicleModel>(vehicleModelRest);
                await vehicleModelService.EditVehicleModelServiceAsync(vehicleModel, id);
                return Ok(vehicleModel);
            }
            catch
            {
                return InternalServerError();
            }
        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeleteVehicleModel(int id)
        {
            try
            {
                await vehicleModelService.DeleteVehicleModelServiceAsync(id);
                return Ok();
            }
            catch
            {
                return InternalServerError();
            }
        }      

    }
}
