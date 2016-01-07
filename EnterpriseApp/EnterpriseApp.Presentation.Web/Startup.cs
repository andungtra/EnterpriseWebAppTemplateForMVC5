using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EnterpriseApp.Presentation.Web.Startup))]
namespace EnterpriseApp.Presentation.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
