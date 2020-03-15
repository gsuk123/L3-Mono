using AutoMapper;
using ProjectVehicle.DAL;
using ProjectVehicle.DAL.Entities;
using ProjectVehicle.Model;
using ProjectVehicle.Model.Common;
using ProjectVehicle.Repository.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVehicle.Repository
{
    public class VehicleMakeRepository : Repository<VehicleMakeEntity>, IVehicleMakeRepository
    {
        private readonly IMapper mapper;

        public VehicleMakeRepository(VehicleContext context, IMapper mapper)
            : base(context)
        {
            this.mapper = mapper;
        }

        public async Task<IEnumerable<IVehicleMake>> GetVehicleMakesByFilter(string filter)
        {
            var vehicleMakes = await base.GetAllAsync();
            vehicleMakes = vehicleMakes.Where(v => v.ManufacturerName.Contains(filter) || v.MadeIn.Contains(filter));
            var mappedResult = mapper.Map<List<IVehicleMake>>(vehicleMakes.ToList());
            return mappedResult;
        }
        public async Task<IVehicleMake> GetVehicleMakeIdAsync(int id)
        {
            var vehicleMakeEntity = await base.GetIdAsync(id);
            IVehicleMake vehicleMake = mapper.Map<IVehicleMake>(vehicleMakeEntity);
            return vehicleMake;
        }

        public async Task<IEnumerable<IVehicleMake>> GetSomeVehiclesAsync()
        {
            var entites = await base.GetAllAsync();
            var mappedResult = mapper.Map<List<IVehicleMake>>(entites.ToList());
            return mappedResult;
        }
        public async Task CreateVehicleMakeAsync(IVehicleMake vehicleMake)
        {
            VehicleMakeEntity vehicleMakeEM = mapper.Map<VehicleMakeEntity>(vehicleMake);
            await base.AddAsync(vehicleMakeEM);
        }

        public async Task EditVehicleMakeAsync(IVehicleMake vehicleMake, int id)
        {
            VehicleMakeEntity vehicleMakeEM = mapper.Map<VehicleMakeEntity>(vehicleMake);
            await base.UpdateAsync(vehicleMakeEM, id);
        }

        public async Task DeleteVehicleMakeAsync(int id)
        {
            var vehicleMakeEntity = await base.GetIdAsync(id);
            await base.DeleteAsync(vehicleMakeEntity);         
            
        }


        //public IEnumerable<IVehicleMake> GetSomeVehicles()
        //{
        //    var entites = base.GetAll().OrderByDescending(c => c.ManufacturerName).ToList();
        //    var mappedResult = mapper.Map<List<IVehicleMake>>(entites.ToList());
        //    return mappedResult;
        //}


        //public VehicleContext VehicleContext
        //{
        //    get { return Context as VehicleContext; }
        //}


        //public IEnumerable<VehicleMakeEntity> FindVehicles(string name)
        //{
        //    return base.Find((vehicleMake) => ApplyFiltering(vehicleMake, name));
        //}

        //private bool ApplyFiltering(VehicleMakeEntity entity, string name)
        //{
        //    return entity.ManufacturerName == name;
        //}

        //public VehicleMakeEntity GetSomeVehicle(int? id)
        //{
        //    var vehicleMakes = base.VehiclesMakes;
        //    var vehicleMake =  vehicleMakes.FindAsync(id);

        //}

    }
}
