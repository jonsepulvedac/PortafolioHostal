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
    public class HABITACIONsController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/HABITACIONs
        public IQueryable<HABITACION> GetHABITACION()
        {
            return db.HABITACION;
        }

        // GET: api/HABITACIONs/5
        [ResponseType(typeof(HABITACION))]
        public IHttpActionResult GetHABITACION(decimal id)
        {
            HABITACION hABITACION = db.HABITACION.Find(id);
            if (hABITACION == null)
            {
                return NotFound();
            }

            return Ok(hABITACION);
        }

        // PUT: api/HABITACIONs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHABITACION(decimal id, HABITACION hABITACION)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hABITACION.HABITACION_NRO)
            {
                return BadRequest();
            }

            db.Entry(hABITACION).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HABITACIONExists(id))
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

        // POST: api/HABITACIONs
        [ResponseType(typeof(HABITACION))]
        public IHttpActionResult PostHABITACION(HABITACION hABITACION)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HABITACION.Add(hABITACION);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (HABITACIONExists(hABITACION.HABITACION_NRO))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = hABITACION.HABITACION_NRO }, hABITACION);
        }

        // DELETE: api/HABITACIONs/5
        [ResponseType(typeof(HABITACION))]
        public IHttpActionResult DeleteHABITACION(decimal id)
        {
            HABITACION hABITACION = db.HABITACION.Find(id);
            if (hABITACION == null)
            {
                return NotFound();
            }

            db.HABITACION.Remove(hABITACION);
            db.SaveChanges();

            return Ok(hABITACION);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HABITACIONExists(decimal id)
        {
            return db.HABITACION.Count(e => e.HABITACION_NRO == id) > 0;
        }
    }
}