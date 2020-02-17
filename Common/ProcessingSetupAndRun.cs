using Autofac;
using Common.ServiceLogic;
using Serilog;
using System;

namespace Common
{
    public class ProcessingSetupAndRun
    {

        private IProcessing logic;

        private ILogger logger;

        public void Setup()
        {
            try
            {
                var builder = new ContainerBuilder();

                builder.RegisterAssemblyModules(typeof(ProcessingSetupAndRun).Assembly);
                // allow to register Modules from ContainerBuilderExtensions folder before container will build

                var container = builder.Build();

                using (var scope = container.BeginLifetimeScope())
                {
                    logic = scope.Resolve<IProcessing>();

                    logger = scope.Resolve<ILogger>();


                    logger.Information("all dependencies was resolved properly");
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Autofac resolving or some builder components register failed");
            }
        }

        public void Run()
        {
            if (this.logic == null)
            {
                this.Setup();
            }
            logic.StartProcessing();
        }


    }
}
