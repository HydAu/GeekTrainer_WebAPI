using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using _01bScaffolding.Models;

namespace _01bScaffolding.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using _01bScaffolding.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<UserInfoViewModel>("UserInfoViewModels");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class UserInfoViewModelsController : ODataController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: odata/UserInfoViewModels
        [EnableQuery]
        public IQueryable<UserInfoViewModel> GetUserInfoViewModels()
        {
            return db.UserInfoViewModels;
        }

        // GET: odata/UserInfoViewModels(5)
        [EnableQuery]
        public SingleResult<UserInfoViewModel> GetUserInfoViewModel([FromODataUri] string key)
        {
            return SingleResult.Create(db.UserInfoViewModels.Where(userInfoViewModel => userInfoViewModel.Email == key));
        }

        // PUT: odata/UserInfoViewModels(5)
        public async Task<IHttpActionResult> Put([FromODataUri] string key, Delta<UserInfoViewModel> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            UserInfoViewModel userInfoViewModel = await db.UserInfoViewModels.FindAsync(key);
            if (userInfoViewModel == null)
            {
                return NotFound();
            }

            patch.Put(userInfoViewModel);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserInfoViewModelExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(userInfoViewModel);
        }

        // POST: odata/UserInfoViewModels
        public async Task<IHttpActionResult> Post(UserInfoViewModel userInfoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UserInfoViewModels.Add(userInfoViewModel);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserInfoViewModelExists(userInfoViewModel.Email))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(userInfoViewModel);
        }

        // PATCH: odata/UserInfoViewModels(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] string key, Delta<UserInfoViewModel> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            UserInfoViewModel userInfoViewModel = await db.UserInfoViewModels.FindAsync(key);
            if (userInfoViewModel == null)
            {
                return NotFound();
            }

            patch.Patch(userInfoViewModel);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserInfoViewModelExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(userInfoViewModel);
        }

        // DELETE: odata/UserInfoViewModels(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] string key)
        {
            UserInfoViewModel userInfoViewModel = await db.UserInfoViewModels.FindAsync(key);
            if (userInfoViewModel == null)
            {
                return NotFound();
            }

            db.UserInfoViewModels.Remove(userInfoViewModel);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserInfoViewModelExists(string key)
        {
            return db.UserInfoViewModels.Count(e => e.Email == key) > 0;
        }
    }
}
