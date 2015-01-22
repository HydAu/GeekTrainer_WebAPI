using System.Web.Http;

namespace _06dVersioning.Controllers
{
    public class VersionsV1Controller : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(ThingRepository.Current.Get());
        }
    }
}
