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
    public class FACTURAsController : ApiController
    {
        private HostalSraRosaApiWebEntities db = new HostalSraRosaApiWebEntities();

        // GET: api/FACTURAs
        public IQueryable<FACTURA> GetFACTURAs()
        {
            return db.FACTURAs;
        }

        // GET: api/FACTURAs/5
        [ResponseType(typeof(FACTURA))]
        public IHttpActionResult GetFACTURA(decimal id)
        {
            FACTURA fACTURA = db.FACTURAs.Find(id);
            if (fACTURA == null)
            {
                return NotFound();
            }

            return Ok(fACTURA);
        }

        // PUT: api/FACTURAs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFACTURA(decimal id, FACTURA fACTURA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fACTURA.FACTURA_ID)
            {
                return BadRequest();
            }

            db.Entry(fACTURA).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FACTURAExists(id))
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

        // POST: api/FACTURAs
        [ResponseType(typeof(FACTURA))]
        public IHttpActionResult PostFACTURA(FACTURA fACTURA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FACTURAs.Add(fACTURA);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (FACTURAExists(fACTURA.FACTURA_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = fACTURA.FACTURA_ID }, fACTURA);
        }

        // DELETE: api/FACTURAs/5
        [ResponseType(typeof(FACTURA))]
        public IHttpActionResult DeleteFACTURA(decimal id)
        {
            FACTURA fACTURA = db.FACTURAs.Find(id);
            if (fACTURA == null)
            {
                return NotFound();
            }

            db.FACTURAs.Remove(fACTURA);
            db.SaveChanges();

            return Ok(fACTURA);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FACTURAExists(decimal id)
        {
            return db.FACTURAs.Count(e => e.FACTURA_ID == id) > 0;
        }
    }
}