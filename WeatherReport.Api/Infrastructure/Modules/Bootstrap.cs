using Autofac;

namespace WeatherReport.Api.Infrastructure.Modules
{
    public class Bootstrap
    {
        public static IContainer Container()
        {
            var builder = new ContainerBuilder();


            builder.RegisterAssemblyModules(ApiDependencyModule.Assembly);

            return builder.Build();
        }
    }
}