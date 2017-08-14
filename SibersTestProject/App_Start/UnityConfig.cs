using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using SibersTestProject.Data.Contracts.Context;
using SibersTestProject.Data.DAL.Context;
using SibersTestProject.Data.Contracts;
using SibersTestProject.Data.DAL;
using System.Linq;
using System.Reflection;
using SibersTestProject.Logic.Contracts.Service;
using SibersTestProject.Logic.BL.Service;
using SibersTestProject.Logic.Contracts;
using SibersTestProject.Logic.BL;
using Unity.AutoRegistration;
using SibersTestProject.Logic.Contracts.Service.Base;
using Microsoft.Practices.ObjectBuilder2;
using SibersTestProject.Data.Contracts.Repositories;
using SibersTestProject.Data.DAL.Repositories;
using SibersTestProject.Logic.BL.Service.Base;

namespace SibersTestProject.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            //// NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            //// container.LoadConfiguration();

            //// TODO: Register your types here
            container.RegisterType<IProjectDbContext, ProjectDbContext>();
            //container.RegisterType(typeof(IEntityRepository<>), typeof(EntityRepository<>), new HierarchicalLifetimeManager());
            container.RegisterType<IService, PhotoService>("SibersTestProject.Logic.BL.Service.PhotoService", new HierarchicalLifetimeManager());
            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());
            //container.RegisterType<IServicesHost, ServicesHost>(new HierarchicalLifetimeManager());
            // register services host
            container.RegisterType<IServicesHost, ServicesHost>(new HierarchicalLifetimeManager(), new InjectionFactory(c => {
                var host = new ServicesHost();
                var uow = c.Resolve<IUnitOfWork>();

                c.Registrations
                .Where(item => item.RegisteredType == typeof(IService) && !item.MappedToType.IsInterface && !item.MappedToType.IsGenericType && !item.MappedToType.IsAbstract && !String.IsNullOrEmpty(item.Name))
                .ForEach(item => c.Resolve<IService>(item.Name, new ResolverOverride[] {
                    new ParameterOverride("servicesHost", host),
                    new ParameterOverride("unitOfWork", uow)
                }));

                return host;
            }));


        }
    }
}
