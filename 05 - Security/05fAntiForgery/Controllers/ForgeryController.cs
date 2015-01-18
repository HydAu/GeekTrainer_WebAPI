using System.Web.Http;

namespace _05fAntiForgery.Controllers
{
    [RoutePrefix("api/forgery")]
    public class ForgeryController : ApiController
    {
        [Route("")]
        public IHttpActionResult Post()
        {
            return Ok("The request was successful!");
        }
    }
}
