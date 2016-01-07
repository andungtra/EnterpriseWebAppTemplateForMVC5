using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EnterpriseApp.Presentation.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.LowercaseUrls = true;

            // Default
            routes.MapRoute(
                name: "Default_WithCulture"
               , url: "{culture}/{controller}/{action}/{id}"
               , defaults: new { culture = "en", controller = "Home", action = "Index", id = UrlParameter.Optional }
               , namespaces: new string[] { "EnterpriseApp.Presentation.Web.Controllers" }
               , constraints: new { culture = "[a-z]{2}" }
            );

            routes.MapRoute(
                name: "Default"
                , url: "{controller}/{action}/{id}"
                , defaults: new { culture = "en", controller = "Home", action = "Index", id = UrlParameter.Optional }
                , namespaces: new string[] { "EnterpriseApp.Presentation.Web.Controllers" }
                , constraints: new { culture = "[a-z]{2}" }
            );

        }
    }
}
