using System.Web.Http;
using System.Web.Http.ModelBinding;
using DemoCommon;
using _06cModelBinders.Models;

namespace _06cModelBinders.Controllers
{
    [RoutePrefix("api/vectors")]
    public class VectorsController : ApiController
    {
        [Route("nobinder")]
        [HttpPost]
        public IHttpActionResult NoModelBinder(DemoVector vector)
        {
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

        [Route("binder")]
        [HttpPost]
        public IHttpActionResult ModelBinder([ModelBinder(typeof(DemoVectorModelBinder))]DemoVector vector)
        {
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
