using System.Diagnostics;
using System.Web.Http.Filters;

namespace _04bExceptionFilter.Filters
{
    public class LoggingFilterAttribute : ExceptionFilterAttribute 
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            Debug.WriteLine("{0}-{1}: {2}", actionExecutedContext.ActionContext.ControllerContext.Controller.GetType(),
                actionExecutedContext.ActionContext.ActionDescriptor.ActionName,
                actionExecutedContext.Exception.Message);
            base.OnException(actionExecutedContext);
        }
    }
}