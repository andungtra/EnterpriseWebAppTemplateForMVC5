using System.Web.Mvc;

namespace EnterpriseApp.Presentation.Web.Areas.SampleDomain
{
    public class SampleDomainAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "SampleDomain";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "SampleDomain_default",
                "SampleDomain/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}