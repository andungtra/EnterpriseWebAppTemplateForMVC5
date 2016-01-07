using EnterpriseApp.Domain.Shared.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseApp.Presentation.Web.Helper
{
    public interface IEmailViewModel
    {

        IHelperContext Context { get; set; }

        string SiteBaseUrl { get; set; }

        string MessageSubject { get; set; }

        string MessageBody { get; set; }

        string GenerateHTML();

    }

}
