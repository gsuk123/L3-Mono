using ProjectVehicle.Model;
using ProjectVehicle.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVehicle.Service.Common
{
    public interface IVehicleMakeService
    {
        Task<IVehicleMake> GetVehicleMakeById(int id);
        Task DeleteVehicleMakeService(int id);
        Task<IEnumerable<IVehicleMake>> GetVehicleMakesAsync();
        Task CreateVehicleMakeServiceAsync(IVehicleMake vehicleMake);
        Task EditVehicleMakeServiceAsync(IVehicleMake vehicleMake, int id);

        Task<IEnumerable<IVehicleMake>> GetVehicleMakesByFilterService(string filter);

    }
}
