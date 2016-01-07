using EnterpriseApp.Domain.Log.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseApp.Domain.Log.Entity
{
    [Serializable]
    public class ExceptionLog
    {

        #region Properties

        public int Id { get; set; }

        public string Source { get; set; }

        public string Message { get; set; }

        public ExceptionLogLevel Level { get; set; }

        public string UserId { get; set; }

        public string IP { get; set; }

        public DateTime Date { get; set; }

        #endregion

    }
}
