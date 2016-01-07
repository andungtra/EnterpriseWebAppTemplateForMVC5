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
    public class MapExceptionLog : EntityTypeConfiguration<ExceptionLog>
    {
        /// <summary>
        /// 
        /// </summary>
        public MapExceptionLog()
        {
            // PRIMARY KEY
            HasKey(e => e.Id);

            Property(e => e.Id)
                .HasColumnName("Id")
                .HasColumnOrder(10)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                ;

            // Source
            Property(e => e.Source)
                .HasColumnName("Source")
                .HasColumnOrder(20)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(200)
                ;

            // Message
            Property(e => e.Message)
                .HasColumnName("Message")
                .HasColumnOrder(30)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(1000)
                ;

            // Level
            Property(e => e.Level)
                .HasColumnName("Level")
                .HasColumnOrder(40)
                .IsRequired()
                ;

            // User Id
            Property(e => e.UserId)
                .HasColumnName("UserId")
                .HasColumnOrder(50)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(128)
                ;

            // IP
            Property(e => e.IP)
                .HasColumnName("IP")
                .HasColumnOrder(60)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(100)
                ;

            // Date
            Property(e => e.Date)
                .HasColumnName("Date")
                .HasColumnOrder(70)
                .IsRequired()
                ;

            //string schemeName = ConfigurationManager.AppSettings["EnterpriseApp.DataAccess.EF.DefaultScheme"];

            // TO TABLE
            //ToTable("LogException", schemeName);
            ToTable("LogException");
        }

    }

}
