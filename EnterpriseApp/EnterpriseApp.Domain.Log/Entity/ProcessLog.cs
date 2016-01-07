using EnterpriseApp.Domain.Log.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseApp.Domain.Log.Entity
{
    [Serializable]
    public class ProcessLog
    {

        #region Properties

        public int Id { get; set; }

        public string ObjectName { get; set; }

        public string ObjectPrimaryKey { get; set; }

        public string Object { get; set; }

        public ProcessType ProcessType { get; set; }

        public DateTime Date { get; set; }

        public string UserId { get; set; }

        public string IP { get; set; }

        #endregion

    }
}
