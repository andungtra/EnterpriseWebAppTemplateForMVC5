using EnterpriseApp.DataAccess.EF.Log.MysqlMapping;
using EnterpriseApp.DataAccess.EF.SampleDomain.MysqlMapping;
using EnterpriseApp.DataAccess.EFRepository;
using EnterpriseApp.Domain.Identity.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseApp.DataAccess.EFContext
{
    public class ApplicationDbContextMyForCUD : IdentityDbContext<ApplicationUser>, IDbContextForCUD
    {

        public ApplicationDbContextMyForCUD()
            : base("CUDMySqlLocal", throwIfV1Schema: false)
        {

        }

        public ApplicationDbContextMyForCUD(string connectionName, bool throwIfV1Schema)
            : base(connectionName, throwIfV1Schema)
        {

        }

        public static ApplicationDbContextMyForCUD CreateApplicationDbContextForCUD()
        {
            return new ApplicationDbContextMyForCUD();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<DecimalPropertyConvention>();
            //modelBuilder.Conventions.Add(new DecimalPropertyConvention(25, 4));
            //string schemeName = ConfigurationManager.AppSettings["EnterpriseApp.DataAccess.EF.DefaultScheme"];

            //modelBuilder.HasDefaultSchema(schemeName);

            base.OnModelCreating(modelBuilder); // This needs to go before the other rules!

            // IDENTITY

            //modelBuilder.Entity<ApplicationUser>().ToTable("IDUser", schemeName);
            //modelBuilder.Entity<IdentityUserRole>().ToTable("IDUserRole", schemeName);
            //modelBuilder.Entity<IdentityUserLogin>().ToTable("IDUserLogin", schemeName);
            //modelBuilder.Entity<IdentityUserClaim>().ToTable("IDUserClaim", schemeName);
            //modelBuilder.Entity<IdentityRole>().ToTable("IDRole", schemeName);

            modelBuilder.Entity<ApplicationUser>().ToTable("IDUser");
            modelBuilder.Entity<IdentityUserRole>().ToTable("IDUserRole");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("IDUserLogin");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("IDUserClaim");
            modelBuilder.Entity<IdentityRole>().ToTable("IDRole");

            // LOG
            modelBuilder.Configurations.Add(new MapExceptionLog());
            modelBuilder.Configurations.Add(new MapProcessLog());

            // SAMPLE DOMAIN
            modelBuilder.Configurations.Add(new MapAuthor());
            modelBuilder.Configurations.Add(new MapBook());

            // YOUR DOMAIN OBJECT MAPPING FILES



        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

    }

}
