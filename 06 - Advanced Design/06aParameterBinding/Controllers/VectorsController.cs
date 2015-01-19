using System.Web.Http;
using DemoCommon;

namespace _06aParameterBinding.Controllers
{
    [RoutePrefix("api/vectors")]
    public class VectorsController : ApiController
    {
        [HttpPost]
        [Route("querystring")]
        public IHttpActionResult PostQuery(string name, DemoVector vector)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest("Name is required.");
            }

            if (vector == null)
            {
                return BadRequest("Vector is required.");
            }

            if (ModelState.IsValid)
            {
                return Ok(vector);
            }

            return BadRequest(ModelState);
        }

        [HttpPost]
        [Route("standard/{name}")]
        public IHttpActionResult Post(string name, DemoVector vector)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest("Name is required.");
            }


            if (vector == null)
            {
                return BadRequest("Vector is required.");
            }
            
            if (ModelState.IsValid)
            {
                return Ok(vector);
            }
            
            return BadRequest(ModelState);
        }

        [HttpPost]
        [Route("backwards")]
        public IHttpActionResult PostIt([FromBody]string name, [FromUri]DemoVector vector)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest("Name is required.");
            }


            if (vector == null)
            {
                return BadRequest("Vector is required.");
            }
            
            if (ModelState.IsValid)
            {
                return Ok(vector);
            }

            return BadRequest(ModelState);
        }
    }
}
