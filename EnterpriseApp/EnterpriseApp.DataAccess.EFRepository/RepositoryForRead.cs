using EnterpriseApp.Domain.Shared.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace EnterpriseApp.DataAccess.EFRepository
{
    public class RepositoryForRead<T> : IRepositoryForRead<T> where T : class
    {
        private readonly IDbContextForRead _context;
        private IDbSet<T> _entities;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public RepositoryForRead(IDbContextForRead context)
        {
            this._context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetById(object id)
        {
            return this.Entities.Find(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetById(object[] id)
        {
            return this.Entities.Find(id);
        }

        /// <summary>
        /// 
        /// </summary>
        public IQueryable<T> Table
        {
            get { return this.Entities; }
        }

        public IEnumerable<T_Target> ToList<T_Target>(IQueryable<T_Target> query)
        {
            using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted }))
            {
                IEnumerable<T_Target> toReturn = query.ToList();
                scope.Complete();
                return toReturn;
            }
        }

        public T_Target ToSingle<T_Target>(IQueryable<T_Target> query)
        {
            var trace = query.ToString();

            using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted }))
            {
                T_Target toReturn = query.SingleOrDefault();
                scope.Complete();
                return toReturn;
            }
        }

        private IDbSet<T> Entities
        {
            get
            {
                if (this._entities == null)
                {
                    this._entities = _context.Set<T>();
                }

                return this._entities;
            }
        }

    }

}
