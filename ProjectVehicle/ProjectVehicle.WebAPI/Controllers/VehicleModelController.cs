using AutoMapper;
using PagedList;
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
        public async Task<IHttpActionResult> GetVehicleModel(int id)
        {
            try
            {
                var vehicleModel = await vehicleModelService.GetVehicleModelServiceAsync(id);
                if (vehicleModel == null)
                {
                    return NotFound();
                }
                VehicleModelRestModel vehicleModelRM = mapper.Map<VehicleModelRestModel>(vehicleModel);
                return Ok(vehicleModelRM);
            }
            catch
            {
                return InternalServerError();
            }
        }

        [HttpGet]        
        public async Task<IEnumerable<VehicleModelRestModel>> GetAllVehiclesModels()
        {
            var vehicleModel = await vehicleModelService.GetVehiclesModelsServiceAsync();
            var vehicleModelList = new List<VehicleModelRestModel>();
            foreach (var v in vehicleModel)
            {
                VehicleModelRestModel vehicleModelRest = mapper.Map<VehicleModelRestModel>(v);
                vehicleModelList.Add(vehicleModelRest);
            }
            return vehicleModelList;
        }

        [HttpPost]
        public async Task<IHttpActionResult> CreateVehicleModel([FromBody]VehicleModelRestModel vehicleModelRM)
        {
            try
            {
                var vehicleModel = mapper.Map<IVehicleModel>(vehicleModelRM);
                await vehicleModelService.CreateVehicleModelServiceAsync(vehicleModel);
                return Ok(vehicleModel);
            }
            catch
            {
                return InternalServerError();
            }

        }

        [HttpPut]
        public async Task<IHttpActionResult> EditVehicleModel([FromBody]VehicleModelRestModel vehicleModelRM, int id)
        {
            try
            {
                var vehicleModel = mapper.Map<IVehicleModel>(vehicleModelRM);
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

        
        [HttpGet]
        public async Task<IPagedList<VehicleModelRestModel>> Find(
            string sortVehicle = null,            
            string searchVehicle = null,
            int? pageVehicle = null,
            int? makeId = null)
        {


            var filter = helperFactory.CreateVehicleFiltering();
            filter.Filter = searchVehicle;
            var sort = helperFactory.CreateVehicleSorting();
            sort.Sort = sortVehicle;
            var page = helperFactory.CreateVehiclePaging();
            page.Page = pageVehicle;

            var vehicles = await vehicleModelService.FindVehicleModelServiceAsync(sort, filter, page, makeId);
            var vehiclesList = new List<VehicleModelRestModel>();
            foreach (var v in vehicles)
            {
                VehicleModelRestModel vehicleModelRM = mapper.Map<VehicleModelRestModel>(v);
                vehiclesList.Add(vehicleModelRM);
            }
            var vehiclePagedList = new StaticPagedList<VehicleModelRestModel>(vehiclesList, vehicles.PageNumber, vehicles.PageSize, vehicles.TotalItemCount);
            return vehiclePagedList;

        }

    }
}
