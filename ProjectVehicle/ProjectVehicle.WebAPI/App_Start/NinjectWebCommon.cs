[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(ProjectVehicle.WebAPI.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(ProjectVehicle.WebAPI.NinjectWebCommon), "Stop")]

namespace ProjectVehicle.WebAPI
{
    using AutoMapper;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Extensions.Factory;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using Ninject.Web.WebApi.Filter;
    using ProjectVehicle.DAL.Entities;
    using ProjectVehicle.Model;
    using ProjectVehicle.Model.Common;
    using ProjectVehicle.Repository;
    using ProjectVehicle.Repository.Common;
    using ProjectVehicle.Service;
    using ProjectVehicle.Service.Common;
    using ProjectVehicle.WebAPI.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Http;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        public static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        public static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IHelperFactory>().ToFactory();
            kernel.Bind<IVehicleSorting>().To<VehicleSorting>();
            kernel.Bind<IVehiclePaging>().To<VehiclePaging>();
            kernel.Bind<IVehicleFiltering>().To<VehicleFiltering>();
            kernel.Bind<IVehicleMakeService>().To<VehicleMakeService>();
            kernel.Bind<IVehicleMakeRepository>().To<VehicleMakeRepository>();
            kernel.Bind<IVehicleModelService>().To<VehicleModelService>();
            kernel.Bind<IVehicleModelRepository>().To<VehicleModelRepository>();
            
            kernel.Bind<IMapper>().ToMethod((context) =>
            {

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<VehicleMakeEntity, IVehicleMake>().ReverseMap();
                    cfg.CreateMap<VehicleMakeRestModel, IVehicleMake>().ReverseMap();
                    cfg.CreateMap<VehicleModelEntity, IVehicleModel>().ReverseMap();
                    cfg.CreateMap<VehicleModelRestModel, IVehicleModel>().ReverseMap();

                });

                IMapper mapper = config.CreateMapper();
                return mapper;
            });

        }
    }
}







