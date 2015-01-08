using System.Linq;
using System.Web.Http;
using _03cCustomContentNegotiation.Models;

namespace _03cCustomContentNegotiation.Controllers
{
    public class ResponsesController : ApiController
    {
        public IHttpActionResult Get()
        {
            return Ok(Request.Headers.Accept.Any(h => h.MediaType.EndsWith("+full")) ? 
                new SimpleResponseWithDate("You got it!") 
                : new SimpleResponse("You got it!"));
        }
    }
}
