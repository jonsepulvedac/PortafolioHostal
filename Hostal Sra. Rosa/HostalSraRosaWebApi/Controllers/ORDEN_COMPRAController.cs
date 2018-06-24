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
    public class ORDEN_COMPRAController : ApiController
    {
        private HostalSraRosaApiWebEntities db = new HostalSraRosaApiWebEntities();

        // GET: api/ORDEN_COMPRA
        public IQueryable<ORDEN_COMPRA> GetORDEN_COMPRA()
        {
            return db.ORDEN_COMPRA;
        }

        // GET: api/ORDEN_COMPRA/5
        [ResponseType(typeof(ORDEN_COMPRA))]
        public IHttpActionResult GetORDEN_COMPRA(decimal id)
        {
            ORDEN_COMPRA oRDEN_COMPRA = db.ORDEN_COMPRA.Find(id);
            if (oRDEN_COMPRA == null)
            {
                return NotFound();
            }

            return Ok(oRDEN_COMPRA);
        }

        // PUT: api/ORDEN_COMPRA/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutORDEN_COMPRA(decimal id, ORDEN_COMPRA oRDEN_COMPRA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != oRDEN_COMPRA.ORDEN_COMPRA_ID)
            {
                return BadRequest();
            }

            db.Entry(oRDEN_COMPRA).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ORDEN_COMPRAExists(id))
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

        // POST: api/ORDEN_COMPRA
        [ResponseType(typeof(ORDEN_COMPRA))]
        public IHttpActionResult PostORDEN_COMPRA(ORDEN_COMPRA oRDEN_COMPRA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ORDEN_COMPRA.Add(oRDEN_COMPRA);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ORDEN_COMPRAExists(oRDEN_COMPRA.ORDEN_COMPRA_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = oRDEN_COMPRA.ORDEN_COMPRA_ID }, oRDEN_COMPRA);
        }

        // DELETE: api/ORDEN_COMPRA/5
        [ResponseType(typeof(ORDEN_COMPRA))]
        public IHttpActionResult DeleteORDEN_COMPRA(decimal id)
        {
            ORDEN_COMPRA oRDEN_COMPRA = db.ORDEN_COMPRA.Find(id);
            if (oRDEN_COMPRA == null)
            {
                return NotFound();
            }

            db.ORDEN_COMPRA.Remove(oRDEN_COMPRA);
            db.SaveChanges();

            return Ok(oRDEN_COMPRA);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ORDEN_COMPRAExists(decimal id)
        {
            return db.ORDEN_COMPRA.Count(e => e.ORDEN_COMPRA_ID == id) > 0;
        }
    }
}