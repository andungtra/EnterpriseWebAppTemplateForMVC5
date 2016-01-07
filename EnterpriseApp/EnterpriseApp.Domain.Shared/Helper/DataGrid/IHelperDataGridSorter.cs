using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseApp.Domain.Shared.Helper.DataGrid
{
    public enum GridSorterDirection
    {
        ASC,
        DESC
    }

    public interface IHelperDataGridSorter
    {

        IList<IDictionary<GridSorterDirection, Expression>> SorterExpressions { get; }

        IHelperDataGridSorter AddSorter<T, F>(Expression<Func<T, F>> sortingExpression, GridSorterDirection direction);

        IQueryable<T> ApplySorters<T>(IQueryable<T> queryableList);

    }

}
