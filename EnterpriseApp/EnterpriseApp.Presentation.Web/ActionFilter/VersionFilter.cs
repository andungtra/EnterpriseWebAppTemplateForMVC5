using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace EnterpriseApp.Presentation.Web.ActionFilter
{
    public class VersionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            string version = "";

            if (HttpRuntime.Cache["versionInfo"] != null)
            {
                version = HttpRuntime.Cache["versionInfo"] as string;
            }
            else
            {
                Version versionInfo = Assembly.GetExecutingAssembly().GetName().Version;

                version = versionInfo.Major
                                + "." + versionInfo.Minor
                                + "." + versionInfo.MinorRevision
                                + " Build " + versionInfo.Build
                                ;

            }
            filterContext.Controller.ViewData.Add("versionInfo", version);

        }

    }

}