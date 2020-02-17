
using Common.BusinessLogic;
using Quartz;
using Serilog;
using System.Threading.Tasks;

namespace Common.Jobs
{
    public class TemplateJob : IJob
    {
        private readonly ILogger logger;
        private readonly IDbLogic dbLogic;

        public TemplateJob(ILogger logger, IDbLogic dbLogic)// inject other what ypu need
        {
            this.logger = logger;
            this.dbLogic = dbLogic;
        }


        public Task Execute(IJobExecutionContext context)
        {
            logger.Information("Job is working23");

            return Task.CompletedTask;
        }
    }
}
