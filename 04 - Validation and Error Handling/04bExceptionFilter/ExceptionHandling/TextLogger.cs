using System.Diagnostics;
using System.Web.Http.ExceptionHandling;

namespace _04bExceptionFilter.ExceptionHandling
{
    public class TextLogger : ExceptionLogger 
    {
        public override void Log(ExceptionLoggerContext context)
        {
            Debug.WriteLine(string.Format("From the global logger: {0}", 
                context.Exception.Message));
            base.Log(context);
        }
    }
}


