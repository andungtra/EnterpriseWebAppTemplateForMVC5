using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseAppTemplate4MVC5.Domain.Shared.Repository
{
    public interface IRepositoryForRead<T> where T : class
    {

        T GetById(object id);

        T GetById(object[] id);

        IQueryable<T> Table { get; }

        IEnumerable<T_Target> ToList<T_Target>(IQueryable<T_Target> query);

        T_Target ToSingle<T_Target>(IQueryable<T_Target> query);

    }

}
