using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace _04bExceptionFilter.Filters
{
    public class NotImplementedFilterAttribute : ExceptionFilterAttribute 
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception is NotImplementedException)
            {
                var msg = actionExecutedContext.Exception.Message;
                var resp = new HttpResponseMessage(HttpStatusCode.NotImplemented)
                {
                    Content = new StringContent(msg),
                    ReasonPhrase = "Because the filter caught it."
                };
                actionExecutedContext.Response = resp;
            }
            else
            {
                base.OnException(actionExecutedContext);
            }
        }
    }
}