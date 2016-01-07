using EnterpriseApp.Domain.Log.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseApp.DataAccess.EF.Log.MysqlMapping
{
    public class MapProcessLog : EntityTypeConfiguration<ProcessLog>
    {
        /// <summary>
        /// 
        /// </summary>
        public MapProcessLog()
        {
            // PRIMARY KEY
            HasKey(p => p.Id);

            Property(p => p.Id)
                .HasColumnName("Id")
                .HasColumnOrder(10)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                ;

            // ObjectName
            Property(p => p.ObjectName)
                .HasColumnName("ObjectName")
                .HasColumnOrder(20)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(200)
                ;

            // ObjectPrimaryKey
            Property(p => p.ObjectPrimaryKey)
                .HasColumnName("ObjectPrimaryKey")
                .HasColumnOrder(30)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(100)
                ;

            // Object
            Property(p => p.Object)
                .HasColumnName("Object")
                .HasColumnOrder(40)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(4000)
                ;

            // ProcessType
            Property(p => p.ProcessType)
                .HasColumnName("ProcessType")
                .HasColumnOrder(50)
                .IsRequired()
                ;

            // User Id
            Property(p => p.UserId)
                .HasColumnName("UserId")
                .HasColumnOrder(60)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(128)
                ;

            // IP
            Property(p => p.IP)
                .HasColumnName("IP")
                .HasColumnOrder(70)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(100)
                ;

            // Date
            Property(p => p.Date)
                .HasColumnName("Date")
                .HasColumnOrder(80)
                .IsRequired()
                ;

            //string schemeName = ConfigurationManager.AppSettings["EnterpriseApp.DataAccess.EF.DefaultScheme"];

            // TO TABLE
            //ToTable("LogProcess", schemeName);
            ToTable("LogProcess");
        }
    }

}
