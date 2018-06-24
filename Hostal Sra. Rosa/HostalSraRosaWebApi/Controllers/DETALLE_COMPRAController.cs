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
    public class DETALLE_COMPRAController : ApiController
    {
        private HostalSraRosaApiWebEntities db = new HostalSraRosaApiWebEntities();

        // GET: api/DETALLE_COMPRA
        public IQueryable<DETALLE_COMPRA> GetDETALLE_COMPRA()
        {
            return db.DETALLE_COMPRA;
        }

        // GET: api/DETALLE_COMPRA/5
        [ResponseType(typeof(DETALLE_COMPRA))]
        public IHttpActionResult GetDETALLE_COMPRA(decimal id)
        {
            DETALLE_COMPRA dETALLE_COMPRA = db.DETALLE_COMPRA.Find(id);
            if (dETALLE_COMPRA == null)
            {
                return NotFound();
            }

            return Ok(dETALLE_COMPRA);
        }

        // PUT: api/DETALLE_COMPRA/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDETALLE_COMPRA(decimal id, DETALLE_COMPRA dETALLE_COMPRA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dETALLE_COMPRA.DETALLE_COMPRA_ID)
            {
                return BadRequest();
            }

            db.Entry(dETALLE_COMPRA).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DETALLE_COMPRAExists(id))
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

        // POST: api/DETALLE_COMPRA
        [ResponseType(typeof(DETALLE_COMPRA))]
        public IHttpActionResult PostDETALLE_COMPRA(DETALLE_COMPRA dETALLE_COMPRA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DETALLE_COMPRA.Add(dETALLE_COMPRA);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DETALLE_COMPRAExists(dETALLE_COMPRA.DETALLE_COMPRA_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = dETALLE_COMPRA.DETALLE_COMPRA_ID }, dETALLE_COMPRA);
        }

        // DELETE: api/DETALLE_COMPRA/5
        [ResponseType(typeof(DETALLE_COMPRA))]
        public IHttpActionResult DeleteDETALLE_COMPRA(decimal id)
        {
            DETALLE_COMPRA dETALLE_COMPRA = db.DETALLE_COMPRA.Find(id);
            if (dETALLE_COMPRA == null)
            {
                return NotFound();
            }

            db.DETALLE_COMPRA.Remove(dETALLE_COMPRA);
            db.SaveChanges();

            return Ok(dETALLE_COMPRA);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DETALLE_COMPRAExists(decimal id)
        {
            return db.DETALLE_COMPRA.Count(e => e.DETALLE_COMPRA_ID == id) > 0;
        }
    }
}