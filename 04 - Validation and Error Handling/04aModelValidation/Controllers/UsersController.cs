using System.Web.Http;
using _04aModelValidation.Models;

namespace _04aModelValidation.Controllers
{
    public class UsersController : ApiController
    {
        public IHttpActionResult Post(User newUser)
        {
            if (newUser == null)
            {
                return BadRequest();
            }

            if ("Jeremy".Equals(newUser.Name) && newUser.Age != 40)
            {
                ModelState.AddModelError("newUser", "Don't lie about Jeremy's age!");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            newUser.Id = 1;
            return Ok(newUser);
        }
    }
}
