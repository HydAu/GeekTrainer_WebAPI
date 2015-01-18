using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace _05dAuthorizationFilter.Filters
{
    public class NaiveAuthorizationFilterAttribute : AuthorizationFilterAttribute 
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            IEnumerable<string> userValues;
            if (actionContext.Request.Headers.TryGetValues("UserName", out userValues))
            {

                var user = userValues.FirstOrDefault();
                if (!string.IsNullOrEmpty(user))
                {
                    Thread.CurrentPrincipal =
                        HttpContext.Current.User =
                            new GenericPrincipal(new GenericIdentity(user), new[] {"User"});
                }
            }
            base.OnAuthorization(actionContext);
        }
    }
}