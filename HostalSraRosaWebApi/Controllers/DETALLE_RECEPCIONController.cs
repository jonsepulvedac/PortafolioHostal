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
    public class DETALLE_RECEPCIONController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/DETALLE_RECEPCION
        public IQueryable<DETALLE_RECEPCION> GetDETALLE_RECEPCION()
        {
            return db.DETALLE_RECEPCION;
        }

        // GET: api/DETALLE_RECEPCION/5
        [ResponseType(typeof(DETALLE_RECEPCION))]
        public IHttpActionResult GetDETALLE_RECEPCION(decimal id)
        {
            DETALLE_RECEPCION dETALLE_RECEPCION = db.DETALLE_RECEPCION.Find(id);
            if (dETALLE_RECEPCION == null)
            {
                return NotFound();
            }

            return Ok(dETALLE_RECEPCION);
        }

        // PUT: api/DETALLE_RECEPCION/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDETALLE_RECEPCION(decimal id, DETALLE_RECEPCION dETALLE_RECEPCION)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dETALLE_RECEPCION.DETALLE_RECEPCION_ID)
            {
                return BadRequest();
            }

            db.Entry(dETALLE_RECEPCION).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DETALLE_RECEPCIONExists(id))
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

        // POST: api/DETALLE_RECEPCION
        [ResponseType(typeof(DETALLE_RECEPCION))]
        public IHttpActionResult PostDETALLE_RECEPCION(DETALLE_RECEPCION dETALLE_RECEPCION)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DETALLE_RECEPCION.Add(dETALLE_RECEPCION);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DETALLE_RECEPCIONExists(dETALLE_RECEPCION.DETALLE_RECEPCION_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = dETALLE_RECEPCION.DETALLE_RECEPCION_ID }, dETALLE_RECEPCION);
        }

        // DELETE: api/DETALLE_RECEPCION/5
        [ResponseType(typeof(DETALLE_RECEPCION))]
        public IHttpActionResult DeleteDETALLE_RECEPCION(decimal id)
        {
            DETALLE_RECEPCION dETALLE_RECEPCION = db.DETALLE_RECEPCION.Find(id);
            if (dETALLE_RECEPCION == null)
            {
                return NotFound();
            }

            db.DETALLE_RECEPCION.Remove(dETALLE_RECEPCION);
            db.SaveChanges();

            return Ok(dETALLE_RECEPCION);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DETALLE_RECEPCIONExists(decimal id)
        {
            return db.DETALLE_RECEPCION.Count(e => e.DETALLE_RECEPCION_ID == id) > 0;
        }
    }
}