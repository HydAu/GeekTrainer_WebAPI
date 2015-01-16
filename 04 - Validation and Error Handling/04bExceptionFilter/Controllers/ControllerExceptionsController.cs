using System;
using System.Web.Http;
using _04bExceptionFilter.Filters;

namespace _04bExceptionFilter.Controllers
{
    [NotImplementedFilter]
    [RoutePrefix("api/controller")]
    public class ControllerExceptionsController : ApiController
    {
        [HttpGet]
        [Route("notImplemented")]
        public IHttpActionResult NotImplemented()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("notImplemented/explicit")]
        public IHttpActionResult NotImplementedExplicit()
        {
            return BadRequest("Not implemented.");
        }

        [HttpGet]
        [Route("notImplemented/filter")]
        public IHttpActionResult NotImplementedFilter()
        {
            throw new NotImplementedException();
        }
    }
}
