﻿using PagedList;
using ProjectVehicle.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVehicle.Service.Common
{
    public interface IVehicleModelService
    {
        Task<IVehicleModel> GetVehicleModelServiceAsync(int id);
        Task<IEnumerable<IVehicleModel>> GetVehiclesModelsServiceAsync();
        Task CreateVehicleModelServiceAsync(IVehicleModel vehicleModel);
        Task DeleteVehicleModelServiceAsync(int id);
        Task EditVehicleModelServiceAsync(IVehicleModel vehicleModel, int id);

        Task<IPagedList<IVehicleModel>> FindVehicleModelServiceAsync(IVehicleSorting sort, IVehicleFiltering filter, IVehiclePaging page, int? makeId = null);

    }
}
