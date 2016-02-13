using EnterpriseApp.Domain.SampleDomain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseApp.DataAccess.EF.SampleDomain.MysqlMapping
{
    public class MapBook : EntityTypeConfiguration<Book>
    {

        /// <summary>
        /// 
        /// </summary>
        public MapBook()
        {
            // PRIMARY KEY
            HasKey(p => p.Id);

            Property(p => p.Id)
                .HasColumnName("Id")
                .HasColumnOrder(10)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                ;

            // AuthorId
            Property(p => p.AuthorId)
                .HasColumnName("AuthorId")
                .HasColumnOrder(20)
                .IsRequired()
                ;

            // Title
            Property(p => p.Title)
                .HasColumnName("Title")
                .HasColumnOrder(30)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(100)
                ;

            // CreateDate
            Property(p => p.CreateDate)
                .HasColumnName("CreateDate")
                .HasColumnOrder(500)
                .IsRequired()
                ;

            // CreatorId
            Property(p => p.CreatorId)
                .HasColumnName("CreatorId")
                .HasColumnOrder(510)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(100)
                ;

            // LastEditDate
            Property(p => p.LastEditDate)
                .HasColumnName("LastEditDate")
                .HasColumnOrder(520)
                .IsRequired()
                ;

            // LastEditorId
            Property(p => p.LastEditorId)
                .HasColumnName("LastEditorId")
                .HasColumnOrder(530)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(100)
                ;

            // IsDeleted
            Property(p => p.IsDeleted)
                .HasColumnName("IsDeleted")
                .HasColumnOrder(540)
                .IsRequired()
                ;

            // Relations

            // 1-many with Author
            HasRequired(b => b.Author)
                .WithMany( a => a.Books)
                .HasForeignKey(b => b.AuthorId)
                .WillCascadeOnDelete(true)
                ;

            // Ignores


            // Table

            //string schemeName = ConfigurationManager.AppSettings["EnterpriseApp.DataAccess.EF.DefaultScheme"];

            //ToTable("SmpBook", schemeName);
            ToTable("SmpBook"); // scheme removed for mysql

        }

    }
}
