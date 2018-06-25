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
using HostalSraRosaWebApi;

namespace HostalSraRosaWebApi.Controllers
{
    public class HUESPEDsController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/HUESPEDs
        public IQueryable<HUESPED> GetHUESPED()
        {
            return db.HUESPED;
        }

        // GET: api/HUESPEDs/5
        [ResponseType(typeof(HUESPED))]
        public IHttpActionResult GetHUESPED(decimal id)
        {
            HUESPED hUESPED = db.HUESPED.Find(id);
            if (hUESPED == null)
            {
                return NotFound();
            }

            return Ok(hUESPED);
        }

        // PUT: api/HUESPEDs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHUESPED(decimal id, HUESPED hUESPED)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hUESPED.HUESPED_RUT)
            {
                return BadRequest();
            }

            db.Entry(hUESPED).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HUESPEDExists(id))
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

        // POST: api/HUESPEDs
        [ResponseType(typeof(HUESPED))]
        public IHttpActionResult PostHUESPED(HUESPED hUESPED)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HUESPED.Add(hUESPED);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (HUESPEDExists(hUESPED.HUESPED_RUT))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = hUESPED.HUESPED_RUT }, hUESPED);
        }

        // DELETE: api/HUESPEDs/5
        [ResponseType(typeof(HUESPED))]
        public IHttpActionResult DeleteHUESPED(decimal id)
        {
            HUESPED hUESPED = db.HUESPED.Find(id);
            if (hUESPED == null)
            {
                return NotFound();
            }

            db.HUESPED.Remove(hUESPED);
            db.SaveChanges();

            return Ok(hUESPED);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HUESPEDExists(decimal id)
        {
            return db.HUESPED.Count(e => e.HUESPED_RUT == id) > 0;
        }
    }
}