using EnterpriseApp.Application.Service.Log;
using EnterpriseApp.DataAccess.EFContext;
using EnterpriseApp.DataAccess.EFRepository;
using EnterpriseApp.Domain.Log.Entity;
using EnterpriseApp.Domain.Log.Service;
using EnterpriseApp.Domain.Log.ValueObject;
using EnterpriseApp.Domain.Shared.Repository;
using log4net.Appender;
using log4net.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace EnterpriseApp.Presentation.Web.Helper
{
    public class ExceptionLogAppender : AppenderSkeleton
    {
        private IServiceExceptionLog _exceptionLogService;

        /// <summary>
        /// 
        /// </summary>
        public ExceptionLogAppender()
        {
            IDbContextForCUD dbContext = ApplicationDbContextForCUD.CreateApplicationDbContextForCUD();
            IRepositoryForCUD<ExceptionLog> repository = new RepositoryForCUD<ExceptionLog>(dbContext);
            this._exceptionLogService = new ServiceExceptionLog(new HelperContextHttp(), repository);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loggingEvent"></param>
        protected override void Append(LoggingEvent loggingEvent)
        {
            try
            {
                ExceptionLogLevel level = ExceptionLogLevel.ERROR;

                switch (loggingEvent.Level.Name)
                {
                    case "DEBUG":
                        level = ExceptionLogLevel.DEBUG;
                        break;
                    case "WARN":
                        level = ExceptionLogLevel.WARNING;
                        break;
                    case "INFO":
                        level = ExceptionLogLevel.INFO;
                        break;
                    case "ERROR":
                        level = ExceptionLogLevel.ERROR;
                        break;
                    case "FATAL":
                        level = ExceptionLogLevel.FATAL;
                        break;
                    default:
                        break;
                }

                Task result = this._exceptionLogService.InsertExceptionLogAsync(level, loggingEvent.LoggerName, RenderLoggingEvent(loggingEvent));

            }
            catch (Exception)
            {
                // burda dosya seviyesinde log yazabilirsin
                throw;
            }
        }

    }

}