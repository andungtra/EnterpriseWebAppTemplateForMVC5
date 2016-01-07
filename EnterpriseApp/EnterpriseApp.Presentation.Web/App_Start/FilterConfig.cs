using EnterpriseApp.Presentation.Web.ActionFilter;
using System.Web;
using System.Web.Mvc;

namespace EnterpriseApp.Presentation.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new LocalizationFilter());
            filters.Add(new VersionFilter());
            filters.Add(new HandleErrorAttribute());
        }
    }
}
