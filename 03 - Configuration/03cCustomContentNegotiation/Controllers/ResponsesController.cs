using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using _03cCustomContentNegotiation.Models;

namespace _03cCustomContentNegotiation.Controllers
{
    public class ResponsesController : ApiController
    {
        public IHttpActionResult Get()
        {
            return Ok(Request.Headers.Accept.Any(h => h.MediaType.EndsWith("+full"))
                ? new SimpleResponseWithDate("You got it!")
                : new SimpleResponse("You got it!"));
        }

        public IHttpActionResult Post(string message)
        {
            var path = string.Format("{0}/1", Request.RequestUri.AbsolutePath);
            return Ok(Request.Headers.Accept.Any(h => h.MediaType.EndsWith("hal+json"))
                ? (object) new SimpleHateoasResponse
                {
                    Message = message,
                    _links =
                        new Links
                        {
                            self = new SingleLink
                            {
                                href = path
                            }
                        }
                }
                : new SimpleResponse(message));
        }
    }
}