using EnterpriseApp.DataAccess.EFRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseApp.DataAccess.EFContext
{
    public class ApplicationDbContextMyForRead : ApplicationDbContextMyForCUD, IDbContextForRead
    {
        public ApplicationDbContextMyForRead()
            : base("ReadMySqlLocal", throwIfV1Schema: false)
        {

        }

        public static ApplicationDbContextMyForRead CreateApplicationDbContext4Read()
        {
            return new ApplicationDbContextMyForRead();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder); // This needs to go before the other rules!

        }


        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }

}
