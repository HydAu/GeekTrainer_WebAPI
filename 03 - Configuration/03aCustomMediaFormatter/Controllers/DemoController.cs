using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using _03aCustomMediaFormatter.Models;

namespace _03aCustomMediaFormatter.Controllers
{
    public class DemoController : ApiController
    {
        private static readonly List<DemoItem> Items;

        static DemoController()
        {
            Items = new List<DemoItem>();
            var random = new Random();
            for (var x = 0; x < 10; x++)
            {
                var item = new DemoItem {Number = random.Next(1, 100)};
                item.Text = string.Format("Generated text {0}", item.Number);
                Items.Add(item);

            }
        }

        public IEnumerable<DemoItem> Get()
        {
            return Items;
        }

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

        [ResponseType(typeof(DemoItem))]
        public IHttpActionResult Post([FromBody]DemoItem value)
        {
            if (value == null)
            {
                return BadRequest("Item cannot be null.");
            }

            if (Items.Exists(i => i.Id == value.Id))
            {
                return BadRequest("Id must be unique.");
            }

            Items.Add(value);
            return Ok(value);
        }

        [ResponseType(typeof(DemoItem))]
        public IHttpActionResult Put(string id, [FromBody]DemoItem value)
        {
            if (value == null)
            {
                return BadRequest("Item cannot be null.");
            }

            var item = Items.FirstOrDefault(i => i.Id == value.Id);
            if (item == null)
            {
                return NotFound();
            }
            item.Number = value.Number;
            item.Text = value.Text;
            return Ok(item);
        }

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
