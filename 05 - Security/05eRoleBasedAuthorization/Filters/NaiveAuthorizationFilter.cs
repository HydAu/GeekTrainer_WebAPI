using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace _05eRoleBasedAuthorization.Filters
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
                    var roles = new List<string> {"User"};
                    if (user.EndsWith("microsoft.com"))
                    {
                        roles.Add("Microsoft");
                    }
                    if (user.EndsWith("ivision.com"))
                    {
                        roles.Add("iVision");
                    }
                    if (user.StartsWith("admin"))
                    {
                        roles.Add("admin");
                    }
                    Thread.CurrentPrincipal =
                        HttpContext.Current.User =
                            new GenericPrincipal(new GenericIdentity(user), roles.ToArray());
                }
            }
            base.OnAuthorization(actionContext);
        }
    }
}