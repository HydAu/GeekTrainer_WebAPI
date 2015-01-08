using System.Web.Http;
using _03bRoutingActions.Models;

namespace _03bRoutingActions.Controllers
{
    public class ConventionsController : ApiController
    {
        // api/Conventions
        public IHttpActionResult Get()
        {
            return Ok(new SimpleResponse("defaultGet"));
        }

        // api/Conventions/1
        public IHttpActionResult Get(int id)
        {
            return Ok(new SimpleResponse(id, "byResource"));
        }

        // api/Conventions 
        [HttpDelete]
        public IHttpActionResult Foo()
        {
            return Ok(new SimpleResponse("fooDelete"));
        }

        // api/Conventions/1
        [HttpDelete]
        public IHttpActionResult Bar(int id)
        {
            return Ok(new SimpleResponse(id, "barDelete"));
        }

        // api/Conventions/1 
        public IHttpActionResult PostBar(int id)
        {
            return Ok(new SimpleResponse(id, "barPost"));
        }
    }
}
