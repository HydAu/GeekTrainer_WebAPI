using System.Web.Http;
using DemoCommon;

namespace _06bTypeConverters.Controllers
{
    [RoutePrefix("api/vectors")]
    public class VectorsController : ApiController
    {
        [Route("{vector}")]
        [HttpGet]
        public IHttpActionResult VectorFromUri(DemoVector vector)
        {
            if (vector == null)
            {
                return BadRequest("Vector cannot be null.");
            }

            if (ModelState.IsValid)
            {
                return Ok(vector);
            }

            return BadRequest(ModelState);
        }
    }
}
