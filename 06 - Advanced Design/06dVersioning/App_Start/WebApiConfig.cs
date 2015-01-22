using System.Web.Http;
using System.Web.Http.Dispatcher;
using _06dVersioning.Version;

namespace _06dVersioning
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{version}/{id}",
                defaults: new { version = RouteParameter.Optional, id = RouteParameter.Optional }
            );       
          
            config.Services.Replace(typeof(IHttpControllerSelector), new VersionControllerSelector(config));
        }
    }
}
