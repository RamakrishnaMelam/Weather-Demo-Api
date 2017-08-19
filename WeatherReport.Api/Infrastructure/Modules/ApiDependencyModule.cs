using System.Reflection;
using Autofac;
using WeatherReport.Api.Services;
using Module = Autofac.Module;

namespace WeatherReport.Api.Infrastructure.Modules
{
    public class ApiDependencyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ThisAssembly).AsImplementedInterfaces();
            builder.RegisterType<WeatherService>().As<IWeatherService>();
            builder
                .RegisterAssemblyTypes(ThisAssembly)
                .AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof(ApiDependencyModule).Assembly)
                .AsImplementedInterfaces()
                .InstancePerRequest();
        }
        public static Assembly Assembly => typeof(ApiDependencyModule).Assembly;
    }
}