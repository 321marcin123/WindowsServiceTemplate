using Autofac;
using Common.BusinessLogic;
using Common.Config.ContainerBuilderExtensions;
using Common.Models;
using Common.ServiceLogic;

namespace Common.Config
{
    public class IoCConfig : Module
    {


        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType(typeof(Processing))
               .AsImplementedInterfaces();

            builder.RegisterType(typeof(ApplicationDbContext))
                .AsImplementedInterfaces();

            builder.RegisterType(typeof(DbLogic))
                .AsImplementedInterfaces();

            builder.RegisterType(typeof(SettingsHelper))
               .AsImplementedInterfaces();

            builder.RegisterScheduler();

            builder.RegisterSerilog();

            builder.RegisterAutoMapper();
        }
    }
}