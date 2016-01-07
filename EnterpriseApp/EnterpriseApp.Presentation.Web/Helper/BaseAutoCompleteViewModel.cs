using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnterpriseApp.Presentation.Web.Helper
{
    public abstract class BaseAutoCompleteViewModel
    {

        public IList<Dictionary<string, string>> suggestions { get; set; }

    }

}