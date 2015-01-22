using System.Web.Http;

namespace _06dVersioning.Controllers
{
    public class VersionsController : ApiController
    {
        public IHttpActionResult Get()
        {
            return Ok(ThingRepository.Current.GetNew());
        }
    }
}
