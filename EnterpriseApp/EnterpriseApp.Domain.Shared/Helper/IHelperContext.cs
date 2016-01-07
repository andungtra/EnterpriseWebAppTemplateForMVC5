using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseApp.Domain.Shared.Helper
{

    public interface IHelperContext
    {

        string GetSiteBaseFullUrl();

        string GetSiteServerMapPath();

        string GetIP();

        string GetUserId();

        string GetUserName();

        IPrincipal GetUser();

    }

}
