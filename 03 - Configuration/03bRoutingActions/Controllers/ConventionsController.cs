using System.Web.Http;

namespace _03bRoutingActions.Controllers
{
    public class ConventionsController : ApiController
    {
        // api/Conventions
        public IHttpActionResult Get()
        {
            return Ok(new {method = "defaultGet" });
        }

        // api/Conventions/1
        public IHttpActionResult Get(int id)
        {
            return Ok(new {method = "byResource", id});
        }

        // api/Conventions 
        [HttpDelete]
        public IHttpActionResult Foo()
        {
            return Ok(new { method = "fooDelete" });
        }

        // api/Conventions/1
        [HttpDelete]
        public IHttpActionResult Bar(int id)
        {
            return Ok(new { method = "barDelete", id });
        }

        // api/Conventions/1 
        public IHttpActionResult PostBar(int id)
        {
            return Ok(new { method = "barPost", id });
        }
    }
}
