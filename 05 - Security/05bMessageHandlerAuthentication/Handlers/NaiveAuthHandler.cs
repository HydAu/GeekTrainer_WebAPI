using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace _05bMessageHandlerAuthentication.Handlers
{
    public class NaiveAuthHandler : DelegatingHandler 
    {
        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, 
            CancellationToken cancellationToken)
        {
            IEnumerable<string> userValues;
            if (!request.Headers.TryGetValues("UserName", out userValues))
            {
                return base.SendAsync(request, cancellationToken);
            }

            var user = userValues.FirstOrDefault();
            if (!string.IsNullOrEmpty(user))
            {
                Thread.CurrentPrincipal = 
                    HttpContext.Current.User = 
                    new GenericPrincipal(new GenericIdentity(user), new[] {"User"});
            }

            return base.SendAsync(request, cancellationToken);
        }
    }
}