using System.Web.Http;
using WeatherReport.Api.Infrastructure.Modules;

namespace WeatherReport.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Bootstrap.Container();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}