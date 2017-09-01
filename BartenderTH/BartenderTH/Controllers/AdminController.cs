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
using BartenderTH.Models;

namespace BartenderTH.Controllers
{
    public class AdminController : ApiController
    {
        private OrdersContext db = new OrdersContext();

        // GET: api/Admin
        public IQueryable<drinks> Getdrinks()
        {
            return db.drinks;
        }

        // GET: api/Admin/5
        [ResponseType(typeof(drinks))]
        public IHttpActionResult Getdrinks(int id)
        {
            drinks drinks = db.drinks.Find(id);
            if (drinks == null)
            {
                return NotFound();
            }

            return Ok(drinks);
        }

        // PUT: api/Admin/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putdrinks(int id, drinks drinks)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != drinks.Id)
            {
                return BadRequest();
            }

            db.Entry(drinks).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!drinksExists(id))
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

        // POST: api/Admin
        [ResponseType(typeof(drinks))]
        public IHttpActionResult Postdrinks(drinks drinks)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.drinks.Add(drinks);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = drinks.Id }, drinks);
        }

        // DELETE: api/Admin/5
        [ResponseType(typeof(drinks))]
        public IHttpActionResult Deletedrinks(int id)
        {
            drinks drinks = db.drinks.Find(id);
            if (drinks == null)
            {
                return NotFound();
            }

            db.drinks.Remove(drinks);
            db.SaveChanges();

            return Ok(drinks);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool drinksExists(int id)
        {
            return db.drinks.Count(e => e.Id == id) > 0;
        }
    }
}