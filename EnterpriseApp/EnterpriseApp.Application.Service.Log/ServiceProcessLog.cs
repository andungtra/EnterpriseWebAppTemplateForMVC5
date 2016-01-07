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
    public class ServiceProcessLog : IServiceProcessLog
    {
        private readonly IHelperContext _context;
        private readonly IHelperSerializer _serializer;
        private readonly IRepositoryForCUD<ProcessLog> _processLogRepository;

        public ServiceProcessLog(
            IHelperContext context,
            IHelperSerializer serializer,
            IRepositoryForCUD<ProcessLog> processLogRepository
        )
        {
            this._context = context;
            this._serializer = serializer;
            this._processLogRepository = processLogRepository;
        }


        public OperationResult InsertProcessLog(object o, string primaryKeyName, ProcessType processType)
        {
            return this._processLogRepository.Insert(this._GenerateProcessLog(o, primaryKeyName, processType));
        }

        public OperationResult InsertProcessLog(object[] o, string primaryKeyName, ProcessType processType)
        {
            IList<ProcessLog> processLogObjects = new List<ProcessLog>();

            foreach (object ob in o)
            {
                processLogObjects.Add(this._GenerateProcessLog(ob, primaryKeyName, processType));
            }

            return this._processLogRepository.Insert(processLogObjects);
        }

        public async Task<OperationResult> InsertProcessLogAsync(object o, string primaryKeyName, ProcessType processType)
        {
            OperationResult result = await this._processLogRepository.InsertAsync(this._GenerateProcessLog(o, primaryKeyName, processType));

            return result;
        }

        public async Task<OperationResult> InsertProcessLogAsync(object[] o, string primaryKeyName, ProcessType processType)
        {
            IList<ProcessLog> processLogObjects = new List<ProcessLog>();

            foreach (object ob in o)
            {
                processLogObjects.Add(this._GenerateProcessLog(ob, primaryKeyName, processType));
            }

            OperationResult result = await this._processLogRepository.InsertAsync(processLogObjects);

            return result;
        }

        private ProcessLog _GenerateProcessLog(object o, string primaryKeyName, ProcessType processType)
        {
            ProcessLog processLog = new ProcessLog();

            processLog.IP = this._context.GetIP();
            processLog.Object = this._serializer.SerializeObjectWithXMLFormatter(o);
            processLog.ObjectName = o.GetType().FullName;
            processLog.ObjectPrimaryKey = primaryKeyName;
            processLog.Date = DateTime.UtcNow;
            processLog.ProcessType = processType;
            processLog.UserId = this._context.GetUserName();

            return processLog;

        }

    }

}
