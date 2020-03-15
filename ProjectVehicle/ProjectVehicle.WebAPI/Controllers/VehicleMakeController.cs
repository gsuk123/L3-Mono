using AutoMapper;
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


        public VehicleMakeController(IVehicleMakeService vehicleMakeService, IMapper mapper)
        {
            this.mapper = mapper;
            this.vehicleMakeService = vehicleMakeService;
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
        public async Task<IEnumerable<VehicleMakeRestModel>> GetVehicleMakeByFilter(string filter)
        {
            var vehicleMake = await vehicleMakeService.GetVehicleMakesByFilterService(filter);
            var vehicleMakeList = new List<VehicleMakeRestModel>();
            foreach (var v in vehicleMake)
            {
                VehicleMakeRestModel vehicleMakeRest = mapper.Map<VehicleMakeRestModel>(v);
                vehicleMakeList.Add(vehicleMakeRest);
            }
            return vehicleMakeList;
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
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
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
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
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

    }
}
