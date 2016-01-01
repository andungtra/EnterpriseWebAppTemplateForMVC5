using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseAppTemplate4MVC5.Domain.Shared.Helper.DataGrid
{
    public interface IHelperDataGridFilter
    {

        List<Expression> Filters { get; set; }

        IHelperDataGridFilter AddFilter<TValue, TCompareAgainst>(
            string filterKey
            , IEnumerable<TCompareAgainst> wantedItems
            , Expression<Func<TValue, TCompareAgainst>> convertBetweenTypes
            );

        IQueryable<T> ApplyFilters<T>(IQueryable<T> queryableList);

    }

}
