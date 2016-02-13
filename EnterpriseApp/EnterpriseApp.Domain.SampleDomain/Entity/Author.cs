using EnterpriseApp.Domain.Shared.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseApp.Domain.SampleDomain.Entity
{
    [Serializable]
    public class Author : ITableLog
    {

        #region Properties

        public int Id { get; set; }

        public string Name { get; set; }

        #endregion

        #region Navigational Properties

        public virtual ICollection<Book> Books { get; set; }

        #endregion

        #region ITableLog Properties

        public string CreatorId { get; set; }

        public DateTime CreateDate { get; set; }

        public string LastEditorId { get; set; }

        public DateTime LastEditDate { get; set; }

        public bool IsDeleted { get; set; }

        #endregion

    }
}
