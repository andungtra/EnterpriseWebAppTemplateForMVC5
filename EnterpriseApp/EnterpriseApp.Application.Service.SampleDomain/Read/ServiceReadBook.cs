using EnterpriseApp.Domain.SampleDomain.Service.Read;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseApp.Domain.SampleDomain.Entity;
using EnterpriseApp.Domain.Shared.Helper.DataGrid;
using EnterpriseApp.Domain.Shared.Repository;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace EnterpriseApp.Application.Service.SampleDomain.Read
{
    public class ServiceReadBook : IServiceReadBook
    {

        private readonly IRepositoryForRead<Book> _bookRepository;

        public ServiceReadBook(
            IRepositoryForRead<Book> bookRepository
        )
        {
            this._bookRepository = bookRepository;
        }

        public Book GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Book> GetByIdQuery(int id)
        {
            throw new NotImplementedException();
        }

        public TTargetType GetByIdWithProjection<TTargetType>(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TTargetType> GetList<TTargetType>(IQueryable<TTargetType> targetQuery)
        {
            return this._bookRepository.ToList(targetQuery);
        }

        public IQueryable<Book> GetListQuery(IHelperDataGridFilter filter = null, IHelperDataGridSorter sorter = null, IHelperDataGridPaginator paginator = null)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TTargetType> GetListWithProjectionQuery<TTargetType>(IHelperDataGridFilter filter = null, IHelperDataGridSorter sorter = null, IHelperDataGridPaginator paginator = null)
        {
            IQueryable<Book> query = this._bookRepository.Table;

            IQueryable<TTargetType> targetQuery = query.ProjectTo<TTargetType>();

            if (filter != null)
            {
                targetQuery = filter.ApplyFilters(targetQuery);
            }

            if (sorter != null)
            {
                targetQuery = sorter.ApplySorters(targetQuery);
            }

            if (paginator != null)
            {
                targetQuery = paginator.ApplyPaginator(targetQuery);
            }

            return targetQuery;
        }

        public IQueryable<TTargetType> GetListWithProjectionQuery<TTargetType>(IQueryable<TTargetType> targetQuery, IHelperDataGridFilter filter = null, IHelperDataGridSorter sorter = null, IHelperDataGridPaginator paginator = null)
        {
            if (filter != null)
            {
                targetQuery = filter.ApplyFilters(targetQuery);
            }

            if (sorter != null)
            {
                targetQuery = sorter.ApplySorters(targetQuery);
            }

            if (paginator != null)
            {
                targetQuery = paginator.ApplyPaginator(targetQuery);
            }

            return targetQuery;
        }
    }
}
