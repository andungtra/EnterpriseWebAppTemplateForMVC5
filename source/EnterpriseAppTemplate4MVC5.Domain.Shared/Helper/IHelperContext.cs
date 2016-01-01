using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseAppTemplate4MVC5.Domain.Shared.Helper
{
    public interface IHelperContext
    {

        string GetIP();

        string GetUserId();

        string GetUserName();

    }

}
