using System;
using WebActivatorEx;

[assembly: PreApplicationStartMethod(typeof(EnterpriseApp.Presentation.Web.App_Start.WindsorActivator), "PreStart")]
[assembly: ApplicationShutdownMethodAttribute(typeof(EnterpriseApp.Presentation.Web.App_Start.WindsorActivator), "Shutdown")]

namespace EnterpriseApp.Presentation.Web.App_Start
{
    public static class WindsorActivator
    {
        static ContainerBootstrapper bootstrapper;

        public static void PreStart()
        {
            bootstrapper = ContainerBootstrapper.Bootstrap();
        }
        
        public static void Shutdown()
        {
            if (bootstrapper != null)
                bootstrapper.Dispose();
        }
    }
}