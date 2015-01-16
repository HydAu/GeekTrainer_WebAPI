using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using _04bExceptionFilter.ExceptionHandling;
using _04bExceptionFilter.Filters;

namespace _04bExceptionFilter
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

            config.Filters.Add(new LoggingFilterAttribute());

            config.Services.Add(typeof(IExceptionLogger), new TextLogger());
            config.Services.Replace(typeof(IExceptionHandler), new TextHandler());
        }
    }
}
