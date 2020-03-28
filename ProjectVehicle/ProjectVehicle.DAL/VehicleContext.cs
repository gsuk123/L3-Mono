using ProjectVehicle.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVehicle.DAL
{
    public class VehicleContext : DbContext
    {

        public DbSet<VehicleMakeEntity> VehiclesMakes { get; set; }
        public DbSet<VehicleModelEntity> VehiclesModels { get; set; }
        public DbSet<VehicleEngineTypeEntity> VehicleEngineTypes { get; set; }
        public DbSet<VehicleRegistrationEntity> VehicleRegistrations { get; set; }
        public DbSet<VehicleOwnerEntity> VehicleOwners { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();            
        }

    }
}
