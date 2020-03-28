using ProjectVehicle.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVehicle.DAL
{
    public class VehicleInitializer : DropCreateDatabaseIfModelChanges<VehicleContext>
    {
        protected override void Seed(VehicleContext context)
        {
            var vehiclesMake = new List<VehicleMakeEntity>
            {
                new VehicleMakeEntity{ ManufacturerName="Audi", MadeIn="Germany"},
                new VehicleMakeEntity{ ManufacturerName="BMW", MadeIn="Germany"},
                new VehicleMakeEntity{ ManufacturerName="Opel", MadeIn="Germany"},
                new VehicleMakeEntity{ ManufacturerName="Fiat", MadeIn="Italy"}
            };
            vehiclesMake.ForEach(v => context.VehiclesMakes.Add(v));
            context.SaveChanges();

            var vehicleEngine = new List<VehicleEngineTypeEntity>
            {
                new VehicleEngineTypeEntity {EngineType = "diesel"},
                new VehicleEngineTypeEntity {EngineType = "petrol"}
            };
            vehicleEngine.ForEach(v => context.VehicleEngineTypes.Add(v));
            context.SaveChanges();

            var vehicleModels = new List<VehicleModelEntity>
            {
                new VehicleModelEntity {ModelName="a3", ModelYear=2011, Colour="Black", VehicleMakeID=1, VehicleEngineTypeID=1},
                new VehicleModelEntity {ModelName="a4", ModelYear=2012, Colour="Red", VehicleMakeID=1, VehicleEngineTypeID=2},
                new VehicleModelEntity {ModelName="m3", ModelYear=2010, Colour="Black", VehicleMakeID=2, VehicleEngineTypeID=1},
                new VehicleModelEntity {ModelName="Astra", ModelYear=2016, Colour="Black", VehicleMakeID=3, VehicleEngineTypeID=2}
            };
            vehicleModels.ForEach(v => context.VehiclesModels.Add(v));
            context.SaveChanges();

            var vehicleOwners = new List<VehicleOwnerEntity>
            {
                new VehicleOwnerEntity {FirstName = "Gabrijel", LastName = "Suk"},
                new VehicleOwnerEntity {FirstName = "Ivan", LastName = "Ivanov"},
                new VehicleOwnerEntity {FirstName = "Marko", LastName = "Markan"},
                new VehicleOwnerEntity {FirstName = "Pero", LastName = "Peric"}
            };
            vehicleOwners.ForEach(v => context.VehicleOwners.Add(v));
            context.SaveChanges();

            var vehicleRegistrations = new List<VehicleRegistrationEntity>
            {
                new VehicleRegistrationEntity { RegistrationNumber = "NA467DC", VehicleModelId=1, VehicleOwnerId=1},
                new VehicleRegistrationEntity { RegistrationNumber = "NA670DF", VehicleModelId=4, VehicleOwnerId=2},
                new VehicleRegistrationEntity { RegistrationNumber = "ZG464FC", VehicleModelId=3, VehicleOwnerId=3},
                new VehicleRegistrationEntity { RegistrationNumber = "DU167DE", VehicleModelId=2, VehicleOwnerId=1}
            };
            vehicleRegistrations.ForEach(v => context.VehicleRegistrations.Add(v));
            context.SaveChanges();




        }
    }
}
