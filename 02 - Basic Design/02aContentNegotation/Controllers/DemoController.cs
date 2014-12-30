using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using _02aContentNegotation.Models;

namespace _02aContentNegotation.Controllers
{
    public class DemoController : ApiController
    {
        private static readonly List<DemoItem> Items;

        static DemoController()
        {
            Items = new List<DemoItem>();
            for (var x = 0; x < 10; x++)
            {
                Items.Add(new DemoItem());
            }
        }

        // GET: api/Demo
        public IEnumerable<DemoItem> Get()
        {
            return Items;
        }

        // GET: api/Demo/5
        [ResponseType(typeof(DemoItem))]
        public IHttpActionResult Get(string id)
        {
            var item = Items.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                return Ok(item);
            }

            return NotFound();
        }

        // POST: api/Demo
        public IHttpActionResult Post([FromBody]string value)
        {
            throw new NotImplementedException();
        }

        // PUT: api/Demo/5
        public void Put(int id, [FromBody]string value)
        {
            throw new NotImplementedException();
        }

        // DELETE: api/Demo/5
        public IHttpActionResult Delete(string id)
        {
            var item = Items.FirstOrDefault(i => i.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            Items.Remove(item);
            return Ok();
        }
    }
}
