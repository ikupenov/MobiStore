using System.Web.Http;

using MobiStore.Web.App_Start;

namespace MobiStore.Web
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            DatabaseConfig.Initialize();
        }
    }
}