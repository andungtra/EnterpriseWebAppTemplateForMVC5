using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace EnterpriseApp.Presentation.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_Error()
        {

        }

        protected void Application_EndRequest()
        {
            if (Response.StatusCode >= 400
            || Server.GetLastError() != null
            )
            {
                this.HandleException();
            }
        }

        private void HandleException()
        {
            Exception exception = Server.GetLastError();

            if (exception == null)
            {
                exception = new HttpException(Response.StatusCode, Response.StatusDescription);
            }

            string orginalCulture = "tr";
            string orginalControllerName = "Home";
            string orginalActionName = "Index";

            HttpContextBase orginalContext = new HttpContextWrapper(Context);
            RouteData orginalRouteData = RouteTable.Routes.GetRouteData(orginalContext);
            if (orginalRouteData != null)
            {
                try
                {
                    orginalCulture = orginalRouteData.GetRequiredString("culture");
                }
                catch (Exception)
                {
                }

                orginalControllerName = orginalRouteData.GetRequiredString("controller");
                orginalActionName = orginalRouteData.GetRequiredString("action");
            }

            HandleErrorInfo errorViewModel = new HandleErrorInfo(exception, orginalControllerName, orginalActionName);

            Response.Clear();
            Response.TrySkipIisCustomErrors = true;

            var newRouteData = new RouteData();
            //newRouteData.Values["culture"] = orginalCulture;
            newRouteData.DataTokens["area"] = ""; // In case controller is in another area
            newRouteData.Values["controller"] = "Error";
            //newRouteData.DataTokens["controller"] = "Error";
            newRouteData.DataTokens["errorViewModel"] = errorViewModel;

            newRouteData.Values["action"] = "Index";

            if (Response.StatusCode == 401)
            {
                newRouteData.Values["action"] = "_401";
            }
            else if (Response.StatusCode == 403)
            {
                newRouteData.Values["action"] = "_403";
            }
            else if (Response.StatusCode == 404)
            {
                newRouteData.Values["action"] = "_404";
            }

            newRouteData.DataTokens["controller"] = newRouteData.Values["controller"];
            newRouteData.DataTokens["action"] = newRouteData.Values["action"];

            var httpContext = new HttpContextWrapper(this.Context);
            var requestContext = new RequestContext(httpContext, newRouteData);

            IController controller = ControllerBuilder.Current.GetControllerFactory().CreateController(requestContext, "Error");

            httpContext.RewritePath(httpContext.Request.FilePath, httpContext.Request.PathInfo, string.Empty);

            controller.Execute(requestContext);

            /*
            var newRequestContext = new RequestContext(new HttpContextWrapper(Context), newRouteData);

            IController newController = ControllerBuilder.Current.GetControllerFactory()
                        .CreateController(newRequestContext, "Error");

            newController.Execute(newRequestContext);
            */

            Server.ClearError();
        }

    }
}
