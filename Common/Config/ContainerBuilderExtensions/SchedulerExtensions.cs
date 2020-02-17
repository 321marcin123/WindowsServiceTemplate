namespace Common.Config.ContainerBuilderExtensions
{
    using Autofac;
    using Autofac.Extras.Quartz;
    using Common.Jobs;
    using Common.ServiceLogic;

    public static class SchedulerExtensions
    {

        public static void RegisterScheduler(this ContainerBuilder builder)
        {
            builder.RegisterType(typeof(Schedule)).AsImplementedInterfaces();

            builder.RegisterModule(new QuartzAutofacFactoryModule());

            // register all jobs like this here: 
            builder.RegisterModule(new QuartzAutofacJobsModule(typeof(TemplateJob).Assembly));

        }


    }
}
