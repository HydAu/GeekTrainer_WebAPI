using System.Web;
using System.Web.Http;

namespace _05aHostAuthentication.API
{
    [RoutePrefix("api/auth")]
    public class AuthenticationController : ApiController
    {
        [Route("")]
        public IHttpActionResult GetNoAuth()
        {
            return Ok(new
            {
                HttpContext.Current.User.Identity.IsAuthenticated,
                HttpContext.Current.User.Identity.Name
            });
        }

        [Route("secured")]
        [Authorize]
        public IHttpActionResult GetAuth()
        {
            return Ok(new
            {
                HttpContext.Current.User.Identity.IsAuthenticated,
                HttpContext.Current.User.Identity.Name
            });
        }
    }
}
