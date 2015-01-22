using System;
using System.Web.Http;
using _06dVersioning.Models;
using _06dVersioning.Version;

namespace _06dVersioning.Controllers
{
    public class ThingController : ApiController
    {
        [HttpGet]
        [Route("api/things")]
        [Route("api/v2/things")]
        public IHttpActionResult GetV2()
        {
            return Request.GetVersion().Equals("v1", StringComparison.InvariantCultureIgnoreCase) ? 
                GetV1() : Ok(ThingRepository.Current.GetNew());
        }

        [HttpGet]
        [Route("api/v1/things")]
        public IHttpActionResult GetV1()
        {
            return Ok(ThingRepository.Current.Get());
        }
    }
}
