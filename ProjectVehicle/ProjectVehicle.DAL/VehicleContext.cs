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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }



        //public new IDbSet<TEntity> Set<TEntity>() where TEntity : VehicleMakeEntity
        //{
        //    return base.Set<TEntity>();
        //}
    }
}
