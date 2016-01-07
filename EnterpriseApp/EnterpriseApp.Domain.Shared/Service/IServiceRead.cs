using EnterpriseApp.Domain.Shared.Helper.DataGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseApp.Domain.Shared.Service
{
    public interface IServiceRead<TPrimaryIdType, TType>
    {

        IQueryable<TType> GetByIdQuery(TPrimaryIdType id);

        TType GetById(TPrimaryIdType id);

        TTargetType GetByIdWithProjection<TTargetType>(TPrimaryIdType id);

        IQueryable<TType> GetListQuery(
            IHelperDataGridFilter filter = null
            , IHelperDataGridSorter sorter = null
            , IHelperDataGridPaginator paginator = null
        );

        IQueryable<TTargetType> GetListWithProjectionQuery<TTargetType>(
            IHelperDataGridFilter filter = null
            , IHelperDataGridSorter sorter = null
            , IHelperDataGridPaginator paginator = null
        );

        IQueryable<TTargetType> GetListWithProjectionQuery<TTargetType>(
            IQueryable<TTargetType> targetQuery
            , IHelperDataGridFilter filter = null
            , IHelperDataGridSorter sorter = null
            , IHelperDataGridPaginator paginator = null
        );

        IEnumerable<TTargetType> GetList<TTargetType>(IQueryable<TTargetType> targetQuery);

    }

}
