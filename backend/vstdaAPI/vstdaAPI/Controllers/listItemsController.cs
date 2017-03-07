using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using vstdaAPI.Models;
using vstdaAPI.data;
using System.Web.Http.Cors;

namespace vstdaAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class listItemsController : ApiController
    {
        private listItemDataContext db = new listItemDataContext();

        // GET: api/listItems
        public IQueryable<listItem> GetlistItems()
        {
            return db.listItems;
        }

        // GET: api/listItems/5
        [ResponseType(typeof(listItem))]
        public IHttpActionResult GetlistItem(int id)
        {
            listItem listItem = db.listItems.Find(id);
            if (listItem == null)
            {
                return NotFound();
            }

            return Ok(listItem);
        }

        // PUT: api/listItems/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutlistItem(int id, listItem listItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != listItem.listItemId)
            {
                return BadRequest();
            }

            db.Entry(listItem).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!listItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/listItems
        [ResponseType(typeof(listItem))]
        public IHttpActionResult PostlistItem(listItem listItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.listItems.Add(listItem);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = listItem.listItemId }, listItem);
        }

        // DELETE: api/listItems/5
        [ResponseType(typeof(listItem))]
        public IHttpActionResult DeletelistItem(int id)
        {
            listItem listItem = db.listItems.Find(id);
            if (listItem == null)
            {
                return NotFound();
            }

            db.listItems.Remove(listItem);
            db.SaveChanges();

            return Ok(listItem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool listItemExists(int id)
        {
            return db.listItems.Count(e => e.listItemId == id) > 0;
        }
    }
}