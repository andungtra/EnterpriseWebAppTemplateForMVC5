using EnterpriseApp.Domain.SampleDomain.Service.Read;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseApp.Domain.SampleDomain.Entity;
using EnterpriseApp.Domain.Shared.Helper.DataGrid;

namespace EnterpriseApp.Application.Service.SampleDomain.Read
{
    public class ServiceReadAuthor : IServiceReadAuthor
    {
        public Author GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Author> GetByIdQuery(int id)
        {
            throw new NotImplementedException();
        }

        public TTargetType GetByIdWithProjection<TTargetType>(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TTargetType> GetList<TTargetType>(IQueryable<TTargetType> targetQuery)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Author> GetListQuery(IHelperDataGridFilter filter = null, IHelperDataGridSorter sorter = null, IHelperDataGridPaginator paginator = null)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TTargetType> GetListWithProjectionQuery<TTargetType>(IHelperDataGridFilter filter = null, IHelperDataGridSorter sorter = null, IHelperDataGridPaginator paginator = null)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TTargetType> GetListWithProjectionQuery<TTargetType>(IQueryable<TTargetType> targetQuery, IHelperDataGridFilter filter = null, IHelperDataGridSorter sorter = null, IHelperDataGridPaginator paginator = null)
        {
            throw new NotImplementedException();
        }
    }
}
