using System.Web.Http;
using Searchinator.Service.App_Start;

namespace Searchinator.Service
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configure(JsonFormatterConfig.Register);
        }
    }
}
