using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseApp.Domain.Shared.Helper.DataGrid
{
    public interface IHelperDataGridPaginator
    {

        int? PageSize { get; set; }

        int? CurrentPage { get; set; }

        string AreaName { get; set; }

        string ControllerName { get; set; }

        string ActionName { get; set; }

        string GoToFirstPageLink { get; set; }

        string GoToPreviousPageLink { get; set; }

        string GoToNextPageLink { get; set; }

        string GoToLastPageLink { get; set; }

        string DisabledClass { get; set; }

        string ActiveClass { get; set; }

        string GoToFirstPageClass { get; set; }

        string GoToPreviousPageClass { get; set; }

        string GoToNextPageClass { get; set; }

        string GoToLastPageClass { get; set; }

        int StartingPageNo { get; set; }

        int EndingPageNo { get; set; }

        int? TotalPages { get; }

        int? TotalElement { get; }

        int? StartingElementNo { get; }

        int? EndingElementNo { get; }

        IQueryable<T> ApplyPaginator<T>(IQueryable<T> queryableList);

    }

}
