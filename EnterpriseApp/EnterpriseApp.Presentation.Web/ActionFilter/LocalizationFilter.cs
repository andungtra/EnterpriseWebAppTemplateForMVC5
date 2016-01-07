using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace EnterpriseApp.Presentation.Web.ActionFilter
{
    public class LocalizationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            string culture = "en";
            string selectedCulture = "";

            try
            {

                if (filterContext.RouteData.Values.ContainsKey("culture"))
                {
                    selectedCulture = filterContext.RouteData.Values["culture"].ToString().ToLower();
                }

                if (!String.IsNullOrWhiteSpace(selectedCulture)
                    && (
                        selectedCulture.StartsWith("en")
                        || selectedCulture.StartsWith("tr")
                    )
                )
                {
                    culture = selectedCulture;
                }

                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
                Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
            }
            catch (Exception)
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en");
                Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
            }


            base.OnActionExecuting(filterContext);

        }

    }
}