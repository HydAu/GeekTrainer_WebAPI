using System.Web.Http;
using _05eRoleBasedAuthorization.Filters;

namespace _05eRoleBasedAuthorization
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

            config.Filters.Add(new NaiveAuthorizationFilterAttribute());
        }
    }
}
