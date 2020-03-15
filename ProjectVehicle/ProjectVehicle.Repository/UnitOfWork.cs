using ProjectVehicle.DAL;
using ProjectVehicle.DAL.Entities;
using ProjectVehicle.Repository.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVehicle.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VehicleContext _context;


        public UnitOfWork(VehicleContext context)
        {
            _context = context; //it uses the same context to initiate both repository
            //VehiclesMakes = new VehicleMakeRepository(_context);
            //VehiclesModels = new VehicleModelRepository(_context);
        }

        public IVehicleMakeRepository VehiclesMakes { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
