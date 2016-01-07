using EnterpriseApp.Domain.Log.ValueObject;
using EnterpriseApp.Domain.Shared.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseApp.Domain.Log.Service
{
    public interface IServiceExceptionLog
    {

        OperationResult InsertExceptionLog(ExceptionLogLevel level, string source, string message);

        Task<OperationResult> InsertExceptionLogAsync(ExceptionLogLevel level, string source, string message);

    }
}
