using Common.Config;
using Quartz;
using Serilog;
using System;

namespace Common.ServiceLogic
{
    public class Schedule : ISchedule
    {
        private readonly IScheduler scheduler;

        private readonly ILogger logger;

        private readonly ISettingsHelper settingsHelper;

        public Schedule(IScheduler scheduler, ILogger logger, ISettingsHelper settingsHelper)
        {
            this.scheduler = scheduler;
            this.logger = logger;
            this.settingsHelper = settingsHelper;
        }

        public void StartSchedule()
        {
            this.scheduler.Start();
        }

        public async void ScheduleService(Type jobType)
        {
            var name = jobType.Name;
            try
            {
                var cron = GetCroneExpression();

                var job = JobBuilder.Create(jobType).Build();

                ITrigger trigger = TriggerBuilder.Create()
                 .WithIdentity("trigger" + name)
                 .WithCronSchedule(cron)
                 .Build();

                await scheduler.ScheduleJob(job, trigger);
            }
            catch (Exception ex)
            {
                logger.Error(ex, $"Error occured while creating trigger for {name}");
            }
        }

        private string GetCroneExpression()
        {
            var cron = settingsHelper.ReadValue("CronSchedule");
            logger.Information($"Read cron expression is : {cron}");
            return cron;
        }

    }
}
