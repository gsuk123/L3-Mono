using AutoMapper;
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

        public VehicleModelController(IVehicleModelService vehicleModelService, IMapper mapper)
        {
            this.vehicleModelService = vehicleModelService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetVehicleModel(int id)
        {
            try
            {
                var vehicleModel = await vehicleModelService.GetVehicleModelById(id);
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
            var vehicleModel = await vehicleModelService.GetVehicleModelsAsync();
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
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
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
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
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
                await vehicleModelService.DeleteVehicleModelService(id);
                return Ok();
            }
            catch
            {
                return InternalServerError();
            }
        }

    }
}
