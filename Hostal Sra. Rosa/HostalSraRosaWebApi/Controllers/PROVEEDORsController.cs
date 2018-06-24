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
    public class PROVEEDORsController : ApiController
    {
        private HostalSraRosaApiWebEntities db = new HostalSraRosaApiWebEntities();

        // GET: api/PROVEEDORs
        public IQueryable<PROVEEDOR> GetPROVEEDORs()
        {
            return db.PROVEEDORs;
        }

        // GET: api/PROVEEDORs/5
        [ResponseType(typeof(PROVEEDOR))]
        public IHttpActionResult GetPROVEEDOR(decimal id)
        {
            PROVEEDOR pROVEEDOR = db.PROVEEDORs.Find(id);
            if (pROVEEDOR == null)
            {
                return NotFound();
            }

            return Ok(pROVEEDOR);
        }

        // PUT: api/PROVEEDORs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPROVEEDOR(decimal id, PROVEEDOR pROVEEDOR)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pROVEEDOR.PROVEEDOR_ID)
            {
                return BadRequest();
            }

            db.Entry(pROVEEDOR).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PROVEEDORExists(id))
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

        // POST: api/PROVEEDORs
        [ResponseType(typeof(PROVEEDOR))]
        public IHttpActionResult PostPROVEEDOR(PROVEEDOR pROVEEDOR)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PROVEEDORs.Add(pROVEEDOR);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PROVEEDORExists(pROVEEDOR.PROVEEDOR_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = pROVEEDOR.PROVEEDOR_ID }, pROVEEDOR);
        }

        // DELETE: api/PROVEEDORs/5
        [ResponseType(typeof(PROVEEDOR))]
        public IHttpActionResult DeletePROVEEDOR(decimal id)
        {
            PROVEEDOR pROVEEDOR = db.PROVEEDORs.Find(id);
            if (pROVEEDOR == null)
            {
                return NotFound();
            }

            db.PROVEEDORs.Remove(pROVEEDOR);
            db.SaveChanges();

            return Ok(pROVEEDOR);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PROVEEDORExists(decimal id)
        {
            return db.PROVEEDORs.Count(e => e.PROVEEDOR_ID == id) > 0;
        }
    }
}