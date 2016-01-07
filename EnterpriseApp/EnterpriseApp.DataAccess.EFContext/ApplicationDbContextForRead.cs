using EnterpriseApp.DataAccess.EFRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseApp.DataAccess.EFContext
{
    public class ApplicationDbContextForRead : ApplicationDbContextForCUD, IDbContextForRead
    {
        public ApplicationDbContextForRead()
            : base("ReadMySqlLocal", throwIfV1Schema: false)
        {

        }

        public static ApplicationDbContextForRead CreateApplicationDbContext4Read()
        {
            return new ApplicationDbContextForRead();
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
