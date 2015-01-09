using System;
using System.Net;
using System.Web.Http;
using _04aModelValidation.Models;

namespace _04aModelValidation.Controllers
{
    public class HelpersController : ApiController
    {
        public IHttpActionResult Get(int test)
        {
            var user = new User
            {
                Name = "Lizze",
                Age = 15
            };

            var uri = new Uri("/api/bogus", UriKind.Relative);

            switch (test)
            {
                case 1:
                    return Conflict();
                case 2:
                    return Created(uri, user);
                case 3:
                    return CreatedAtRoute("DefaultApi", new {id = 1}, user);
                case 4:
                    return InternalServerError(new Exception("Oops!"));
                case 5:
                    return NotFound();
                case 6:
                    return Ok();
                case 7:
                    return Redirect(uri);
                case 8:
                    return StatusCode(HttpStatusCode.Ambiguous);
                default:
                    return BadRequest();
            }
        }
    }
}
