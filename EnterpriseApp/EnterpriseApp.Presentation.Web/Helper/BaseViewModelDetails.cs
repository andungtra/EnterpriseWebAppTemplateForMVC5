using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnterpriseApp.Presentation.Web.Helper
{
    public abstract class BaseViewModelDetails<T>
    {

        public T Entity { get; set; }

    }

}