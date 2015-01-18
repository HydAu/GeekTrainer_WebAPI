using System.Web;
using System.Web.Http;
using _05dAuthorizationFilter.Filters;

namespace _05dAuthorizationFilter.Controllers
{
    [NaiveAuthorizationFilter]
    [RoutePrefix("api/auth")]
    public class AuthorizationController : ApiController
    {
        [Route("")]
        public IHttpActionResult GetAuth()
        {
            return Ok(
                new
                {
                    HttpContext.Current.User.Identity.IsAuthenticated,
                    HttpContext.Current.User.Identity.Name
                });
        }

        [Route("secured")]
        [Authorize]
        public IHttpActionResult GetWithAuth()
        {
            return Ok(
                new
                {
                    HttpContext.Current.User.Identity.IsAuthenticated,
                    HttpContext.Current.User.Identity.Name
                });
        }
    }
}
