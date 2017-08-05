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
using BackendAPI.Models;

namespace BackendAPI.Controllers
{
    public class ATMsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/ATMs
        public IQueryable<ATM> GetATMs()
        {
            return db.ATMs;
        }

        // GET: api/ATMs/5
        [ResponseType(typeof(ATM))]
        public IHttpActionResult GetATM(string id)
        {
            ATM aTM = db.ATMs.Find(id);
            if (aTM == null)
            {
                return NotFound();
            }

            return Ok(aTM);
        }

        // PUT: api/ATMs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutATM(string id, ATM aTM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aTM.Id)
            {
                return BadRequest();
            }

            db.Entry(aTM).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ATMExists(id))
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

        // POST: api/ATMs
        [ResponseType(typeof(ATM))]
        public IHttpActionResult PostATM(ATM aTM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ATMs.Add(aTM);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ATMExists(aTM.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = aTM.Id }, aTM);
        }

        // DELETE: api/ATMs/5
        [ResponseType(typeof(ATM))]
        public IHttpActionResult DeleteATM(string id)
        {
            ATM aTM = db.ATMs.Find(id);
            if (aTM == null)
            {
                return NotFound();
            }

            db.ATMs.Remove(aTM);
            db.SaveChanges();

            return Ok(aTM);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ATMExists(string id)
        {
            return db.ATMs.Count(e => e.Id == id) > 0;
        }
    }
}