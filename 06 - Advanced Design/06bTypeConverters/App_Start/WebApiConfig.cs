using System.ComponentModel;
using System.Web.Http;
using DemoCommon;
using _06bTypeConverters.Models;

namespace _06bTypeConverters
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
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            TypeDescriptor.AddAttributes(typeof (DemoVector), 
                new TypeConverterAttribute(typeof (DemoVectorConverter)));
        }
    }
}
