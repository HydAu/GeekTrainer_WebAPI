using System;
using System.Web.Http;
using _04bExceptionFilter.Filters;

namespace _04bExceptionFilter.Controllers
{
    [RoutePrefix("api/local")]
    public class LocalExceptionsController : ApiController
    {
        [HttpGet]
        [Route("notImplemented")]
        public IHttpActionResult NotImplemented()
        {
            throw new NotImplementedException("Not implemented isn't, er, implemented.");
        }

        [HttpGet]
        [Route("notImplemented/explicit")]
        public IHttpActionResult NotImplementedExplicit()
        {
            return BadRequest("Not implemented.");
        }

        [HttpGet]
        [Route("notImplemented/filter")]
        [NotImplementedFilter]
        public IHttpActionResult NotImplementedFilter()
        {
            throw new NotImplementedException("The filter action isn't implemented either.");
        }

        [HttpGet]
        [Route("notImplemented/exception")]
        [NotImplementedFilter]
        public IHttpActionResult Exception()
        {
            throw new Exception("This is a generic exception.");
        }

    }
}
