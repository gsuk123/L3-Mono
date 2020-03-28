using PagedList;
using ProjectVehicle.Common.Contracts;
using ProjectVehicle.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVehicle.Service.Common
{
    public interface IVehicleOwnerService
    {
        Task<IPagedList<IVehicleOwner>> GetOwnersServiceAsync(IVehicleSorting sort, IVehicleFiltering filter, IVehiclePaging page);
        Task<IVehicleOwner> GetOwnerServiceAsync(int id);
        Task CreateOwnerServiceAsync(IVehicleOwner vehicleOwner);
        Task EditOwnerServiceAsync(IVehicleOwner vehicleOwner, int id);
        Task DeleteOwnerServiceAsync(int id);

    }
}
