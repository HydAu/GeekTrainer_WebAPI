using System.Linq;
using System.Web.Http;
using _05eRoleBasedAuthorization.Models;

namespace _05eRoleBasedAuthorization.Controllers
{
    [RoutePrefix("api/widgets")]
    public class WidgetsController : ApiController
    {
        private static readonly IWidgetRepository WidgetRepo = new WidgetRepository();
        
        [Route("")]   
        public IHttpActionResult Get()
        {
            return Ok(WidgetRepo.Get(User.IsInRole("iVision"), User.IsInRole("Microsoft")).ToList());
        }

        [Route("ivision")]
        [Authorize(Roles="ivision,admin")]
        public IHttpActionResult GetIVision()
        {
            return Ok(WidgetRepo.Get(true, false).ToList());
        }

        [Route("microsoft")]
        [Authorize(Roles="microsoft,admin")]
        public IHttpActionResult GetMicrosoft()
        {
            return Ok(WidgetRepo.Get(false, true).ToList());          
        }

        [Route("all")]
        [Authorize(Roles = "admin")]
        public IHttpActionResult GetAll()
        {
            return Ok(WidgetRepo.Get(true, true).ToList());
        }
    }
}
