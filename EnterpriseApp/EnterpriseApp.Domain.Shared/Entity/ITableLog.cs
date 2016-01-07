using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseApp.Domain.Shared.Entity
{

    public interface ITableLog
    {

        string CreatorId { get; set; }

        DateTime CreateDate { get; set; }

        string LastEditorId { get; set; }

        DateTime LastEditDate { get; set; }

        bool IsDeleted { get; set; }

    }


}
