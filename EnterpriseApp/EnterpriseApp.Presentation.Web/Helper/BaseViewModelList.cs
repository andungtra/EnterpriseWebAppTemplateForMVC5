using EnterpriseApp.Domain.Shared.Helper.DataGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnterpriseApp.Presentation.Web.Helper
{
    public abstract class BaseViewModelList<T>
    {

        public IEnumerable<T> Data { get; set; }

        public IHelperDataGridSorter Sorter { get; set; }

        public IHelperDataGridFilter Filter { get; set; }

        public IHelperDataGridPaginator Paginator { get; set; }

    }

}