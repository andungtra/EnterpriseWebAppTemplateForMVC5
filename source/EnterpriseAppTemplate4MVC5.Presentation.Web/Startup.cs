using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EnterpriseAppTemplate4MVC5.Presentation.Web.Startup))]
namespace EnterpriseAppTemplate4MVC5.Presentation.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
