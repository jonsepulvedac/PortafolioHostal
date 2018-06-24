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
    public class DETALLE_FACTURAController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/DETALLE_FACTURA
        public IQueryable<DETALLE_FACTURA> GetDETALLE_FACTURA()
        {
            return db.DETALLE_FACTURA;
        }

        // GET: api/DETALLE_FACTURA/5
        [ResponseType(typeof(DETALLE_FACTURA))]
        public IHttpActionResult GetDETALLE_FACTURA(decimal id)
        {
            DETALLE_FACTURA dETALLE_FACTURA = db.DETALLE_FACTURA.Find(id);
            if (dETALLE_FACTURA == null)
            {
                return NotFound();
            }

            return Ok(dETALLE_FACTURA);
        }

        // PUT: api/DETALLE_FACTURA/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDETALLE_FACTURA(decimal id, DETALLE_FACTURA dETALLE_FACTURA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dETALLE_FACTURA.DETALLE_FACTURA_ID)
            {
                return BadRequest();
            }

            db.Entry(dETALLE_FACTURA).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DETALLE_FACTURAExists(id))
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

        // POST: api/DETALLE_FACTURA
        [ResponseType(typeof(DETALLE_FACTURA))]
        public IHttpActionResult PostDETALLE_FACTURA(DETALLE_FACTURA dETALLE_FACTURA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DETALLE_FACTURA.Add(dETALLE_FACTURA);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DETALLE_FACTURAExists(dETALLE_FACTURA.DETALLE_FACTURA_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = dETALLE_FACTURA.DETALLE_FACTURA_ID }, dETALLE_FACTURA);
        }

        // DELETE: api/DETALLE_FACTURA/5
        [ResponseType(typeof(DETALLE_FACTURA))]
        public IHttpActionResult DeleteDETALLE_FACTURA(decimal id)
        {
            DETALLE_FACTURA dETALLE_FACTURA = db.DETALLE_FACTURA.Find(id);
            if (dETALLE_FACTURA == null)
            {
                return NotFound();
            }

            db.DETALLE_FACTURA.Remove(dETALLE_FACTURA);
            db.SaveChanges();

            return Ok(dETALLE_FACTURA);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DETALLE_FACTURAExists(decimal id)
        {
            return db.DETALLE_FACTURA.Count(e => e.DETALLE_FACTURA_ID == id) > 0;
        }
    }
}