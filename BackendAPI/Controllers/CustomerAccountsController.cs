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
    public class CustomerAccountsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/CustomerAccounts
        public IQueryable<CustomerAccount> GetCustomerAccounts()
        {
            return db.CustomerAccounts;
        }

        // GET: api/CustomerAccounts/5
        [ResponseType(typeof(CustomerAccount))]
        public IHttpActionResult GetCustomerAccount(string id)
        {
            CustomerAccount customerAccount = db.CustomerAccounts.Find(id);
            if (customerAccount == null)
            {
                return NotFound();
            }

            return Ok(customerAccount);
        }

        // PUT: api/CustomerAccounts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCustomerAccount(string id, CustomerAccount customerAccount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customerAccount.Id)
            {
                return BadRequest();
            }

            db.Entry(customerAccount).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerAccountExists(id))
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

        // POST: api/CustomerAccounts
        [ResponseType(typeof(CustomerAccount))]
        public IHttpActionResult PostCustomerAccount(CustomerAccount customerAccount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CustomerAccounts.Add(customerAccount);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CustomerAccountExists(customerAccount.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = customerAccount.Id }, customerAccount);
        }

        // DELETE: api/CustomerAccounts/5
        [ResponseType(typeof(CustomerAccount))]
        public IHttpActionResult DeleteCustomerAccount(string id)
        {
            CustomerAccount customerAccount = db.CustomerAccounts.Find(id);
            if (customerAccount == null)
            {
                return NotFound();
            }

            db.CustomerAccounts.Remove(customerAccount);
            db.SaveChanges();

            return Ok(customerAccount);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomerAccountExists(string id)
        {
            return db.CustomerAccounts.Count(e => e.Id == id) > 0;
        }
    }
}