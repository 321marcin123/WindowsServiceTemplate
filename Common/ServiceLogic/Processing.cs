using Common.Jobs;
using Serilog;

namespace Common.ServiceLogic
{
    public class Processing : IProcessing
    {
        private readonly ILogger logger;

        private readonly ISchedule schedule;

        public Processing(ILogger logger, ISchedule schedule)
        {
            this.logger = logger;
            this.schedule = schedule;
        }

        public void StartProcessing()
        {
            try
            {
                logger.Information("processStarted");
                schedule.ScheduleService(typeof(TemplateJob));

                logger.Debug("log something");
                logger.Debug("StartProcessing");
                schedule.StartSchedule();
            }
            catch (System.Exception ex)
            {
                this.logger.Error(ex, "Start process failed (contains schedule service and startSchedule methods)");
            }

        }

        public void StopProcessing()
        {

        }


    }

}
