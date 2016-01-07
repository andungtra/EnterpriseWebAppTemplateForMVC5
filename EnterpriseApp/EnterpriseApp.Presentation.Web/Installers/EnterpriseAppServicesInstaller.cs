using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using EnterpriseApp.Application.Service.Log;
using EnterpriseApp.DataAccess.EFContext;
using EnterpriseApp.DataAccess.EFRepository;
using EnterpriseApp.Domain.Log.Service;
using EnterpriseApp.Domain.Shared.Helper;
using EnterpriseApp.Domain.Shared.Repository;
using EnterpriseApp.Presentation.Web.Helper;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnterpriseApp.Presentation.Web.Installers
{
    public class EnterpriseAppServicesInstaller : IWindsorInstaller
    {

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {

            // APPLICATION DB CONTEXTS

            // CUD Context
            container
                .Register(Component.For<IDbContextForCUD>()
                .ImplementedBy<ApplicationDbContextForCUD>()
                .LifeStyle.PerWebRequest
                );

            // Read Context
            container
                .Register(Component.For<IDbContextForRead>()
                .ImplementedBy<ApplicationDbContextForRead>()
                .LifeStyle.PerWebRequest
                );

            // REPOSITORIES

            // CUD Repository
            container
                .Register(Component.For(typeof(IRepositoryForCUD<>))
                .ImplementedBy(typeof(RepositoryForCUD<>))
                .LifeStyle.PerWebRequest
                );

            // Read Repository
            container
                .Register(Component.For(typeof(IRepositoryForRead<>))
                .ImplementedBy(typeof(RepositoryForRead<>))
                .LifeStyle.PerWebRequest
                );

            // HELPERS

            // Serializer Helper
            container
                .Register(Component.For<IHelperSerializer>()
                .ImplementedBy<HelperSerializer>()
                .LifeStyle.Singleton
                );

            // Context Helper
            container
                .Register(Component.For<IHelperContext>()
                .ImplementedBy<HelperContextHttp>()
                .LifeStyle.PerWebRequest
                );

            // IDENTITY DOMAIN SERVICES

            // ApplicationUserManager
            container.Register(Component.For<ApplicationUserManager>()
              .UsingFactoryMethod(
                (kernel, creationContext) => HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>()
              )
              .LifestylePerWebRequest());

            // ApplicationRoleManager
            container.Register(Component.For<ApplicationRoleManager>()
              .UsingFactoryMethod(
                (kernel, creationContext) => HttpContext.Current.GetOwinContext().Get<ApplicationRoleManager>()
              )
              .LifestylePerWebRequest());

            // ApplicationSignInManager
            container.Register(Component.For<ApplicationSignInManager>()
              .UsingFactoryMethod(
                (kernel, creationContext) => HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>()
              )
              .LifestylePerWebRequest());

            // ApplicationUser Services


            // LOG DOMAIN SERVICES

            // Process Log Service
            container
                .Register(Component.For<IServiceProcessLog>()
                .ImplementedBy<ServiceProcessLog>()
                .LifeStyle.PerWebRequest
                );

            // YOUR DOMAIN SERVICES



        }

    }
}