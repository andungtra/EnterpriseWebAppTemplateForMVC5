using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseApp.DataAccess.EFRepository
{
    public interface IDbContextForCUD
    {

        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        Database Database { get; }

        int SaveChanges();

        Task<int> SaveChangesAsync();

    }
}
