using ProjectVehicle.DAL.Entities;
using ProjectVehicle.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVehicle.Repository.Common
{
    public interface IVehicleEngineTypeRepository : IRepository<VehicleEngineTypeEntity>
    {
        Task<IEnumerable<IVehicleEngineType>> GetAllEngineTypeAsync();
    }
}
