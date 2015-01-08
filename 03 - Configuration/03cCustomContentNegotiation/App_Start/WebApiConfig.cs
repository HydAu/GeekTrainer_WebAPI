using System.Web.Http;
using _03cCustomContentNegotiation.Models;

namespace _03cCustomContentNegotiation
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
                routeTemplate: "api/{controller}"
            );

            config.Formatters.Insert(0, new MyXmlMediaTypeFormatter()); 
            config.Formatters.Insert(0, new MyJsonMediaTypeFormatter());            
        }
    }
}
