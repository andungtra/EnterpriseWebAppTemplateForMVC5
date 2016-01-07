using EnterpriseApp.Domain.Log.ValueObject;
using EnterpriseApp.Domain.Shared.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseApp.Domain.Log.Service
{
    public interface IServiceProcessLog
    {

        OperationResult InsertProcessLog(object o, string primaryKeyName, ProcessType processType);

        OperationResult InsertProcessLog(object[] o, string primaryKeyName, ProcessType processType);

        Task<OperationResult> InsertProcessLogAsync(object o, string primaryKeyName, ProcessType processType);

        Task<OperationResult> InsertProcessLogAsync(object[] o, string primaryKeyName, ProcessType processType);


    }
}
