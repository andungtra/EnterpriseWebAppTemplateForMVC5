using EnterpriseApp.Domain.Log.Entity;
using EnterpriseApp.Domain.Log.Service;
using EnterpriseApp.Domain.Log.ValueObject;
using EnterpriseApp.Domain.Shared.Helper;
using EnterpriseApp.Domain.Shared.Repository;
using EnterpriseApp.Domain.Shared.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseApp.Application.Service.Log
{
    public class ServiceExceptionLog : IServiceExceptionLog
    {

        private readonly IHelperContext _context;
        private readonly IRepositoryForCUD<ExceptionLog> _exceptionLogRepository;

        public ServiceExceptionLog(
            IHelperContext context,
            IRepositoryForCUD<ExceptionLog> exceptionLogRepository
        )
        {
            this._context = context;
            this._exceptionLogRepository = exceptionLogRepository;
        }

        public OperationResult InsertExceptionLog(ExceptionLogLevel level, string source, string message)
        {
            return this._exceptionLogRepository.Insert(this._GenerateExceptionLog(level, source, message));

        }

        public async Task<OperationResult> InsertExceptionLogAsync(ExceptionLogLevel level, string source, string message)
        {
            OperationResult result = await this._exceptionLogRepository.InsertAsync(this._GenerateExceptionLog(level, source, message));

            return result;
        }

        private ExceptionLog _GenerateExceptionLog(ExceptionLogLevel level, string source, string message)
        {
            ExceptionLog exceptionLog = new ExceptionLog();

            exceptionLog.Level = level;
            exceptionLog.Message = message;
            exceptionLog.Source = source;
            exceptionLog.Date = DateTime.UtcNow;
            exceptionLog.IP = this._context.GetIP();
            exceptionLog.UserId = this._context.GetUserId();

            return exceptionLog;

        }

    }

}
