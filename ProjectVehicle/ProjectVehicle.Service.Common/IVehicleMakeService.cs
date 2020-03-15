using PagedList;
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
        Task<IVehicleMake> GetVehicleMakeServiceAsync(int id);
        Task DeleteVehicleMakeServiceAsync(int id);
        Task<IEnumerable<IVehicleMake>> GetVehicleMakesServiceAsync();
        Task CreateVehicleMakeServiceAsync(IVehicleMake vehicleMake);
        Task EditVehicleMakeServiceAsync(IVehicleMake vehicleMake, int id);        
        
        Task<IPagedList<IVehicleMake>> FindVehicleMakeServiceAsync(IVehicleSorting sort, IVehicleFiltering filter, IVehiclePaging page);


    }
}
