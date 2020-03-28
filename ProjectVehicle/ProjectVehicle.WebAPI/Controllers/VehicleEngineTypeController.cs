using AutoMapper;
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
    public class VehicleEngineTypeController : ApiController
    {
        private readonly IVehicleEngineTypeService vehicleEngineTypeService;
        private readonly IMapper mapper;

        public VehicleEngineTypeController(IVehicleEngineTypeService vehicleEngineTypeService, IMapper mapper)
        {
            this.vehicleEngineTypeService = vehicleEngineTypeService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<VehicleEngineTypeRestModel>> GetEngineType()
        {
            var vehicleEngine = await vehicleEngineTypeService.GetEngineTypeServiceAsync();
            List<VehicleEngineTypeRestModel> vehicleEngineRest = mapper.Map<List<VehicleEngineTypeRestModel>>(vehicleEngine.ToList());
            return vehicleEngineRest;
        }
    }
}
