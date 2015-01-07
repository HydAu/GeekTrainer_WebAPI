using System.Web.Http;

namespace _03bRoutingActions.Controllers
{
    [RoutePrefix("api/custom")]
    public class AttributesController : ApiController
    {
        [HttpGet]
        [Route("")]
        public IHttpActionResult Weird()
        {
            return Ok(new { method = "defaultGet" });
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult Strange(int id)
        {
            return Ok(new { method = "byResource", id });
        }

        [Route("foo")] 
        [HttpDelete]
        public IHttpActionResult Foo()
        {
            return Ok(new { method = "fooDelete" });
        }

        [Route("bar/{id}")]
        [HttpDelete]
        public IHttpActionResult Bar(int id)
        {
            return Ok(new { method = "barDelete", id });
        }

        [Route("bar/{id}")] 
        public IHttpActionResult PostBar(int id)
        {
            return Ok(new { method = "barPost", id });
        }
    }
}
