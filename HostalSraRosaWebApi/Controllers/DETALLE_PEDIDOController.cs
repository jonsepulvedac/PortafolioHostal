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
    public class DETALLE_PEDIDOController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/DETALLE_PEDIDO
        public IQueryable<DETALLE_PEDIDO> GetDETALLE_PEDIDO()
        {
            return db.DETALLE_PEDIDO;
        }

        // GET: api/DETALLE_PEDIDO/5
        [ResponseType(typeof(DETALLE_PEDIDO))]
        public IHttpActionResult GetDETALLE_PEDIDO(decimal id)
        {
            DETALLE_PEDIDO dETALLE_PEDIDO = db.DETALLE_PEDIDO.Find(id);
            if (dETALLE_PEDIDO == null)
            {
                return NotFound();
            }

            return Ok(dETALLE_PEDIDO);
        }

        // PUT: api/DETALLE_PEDIDO/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDETALLE_PEDIDO(decimal id, DETALLE_PEDIDO dETALLE_PEDIDO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dETALLE_PEDIDO.DETALLE_PEDIDO_ID)
            {
                return BadRequest();
            }

            db.Entry(dETALLE_PEDIDO).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DETALLE_PEDIDOExists(id))
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

        // POST: api/DETALLE_PEDIDO
        [ResponseType(typeof(DETALLE_PEDIDO))]
        public IHttpActionResult PostDETALLE_PEDIDO(DETALLE_PEDIDO dETALLE_PEDIDO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DETALLE_PEDIDO.Add(dETALLE_PEDIDO);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DETALLE_PEDIDOExists(dETALLE_PEDIDO.DETALLE_PEDIDO_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = dETALLE_PEDIDO.DETALLE_PEDIDO_ID }, dETALLE_PEDIDO);
        }

        // DELETE: api/DETALLE_PEDIDO/5
        [ResponseType(typeof(DETALLE_PEDIDO))]
        public IHttpActionResult DeleteDETALLE_PEDIDO(decimal id)
        {
            DETALLE_PEDIDO dETALLE_PEDIDO = db.DETALLE_PEDIDO.Find(id);
            if (dETALLE_PEDIDO == null)
            {
                return NotFound();
            }

            db.DETALLE_PEDIDO.Remove(dETALLE_PEDIDO);
            db.SaveChanges();

            return Ok(dETALLE_PEDIDO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DETALLE_PEDIDOExists(decimal id)
        {
            return db.DETALLE_PEDIDO.Count(e => e.DETALLE_PEDIDO_ID == id) > 0;
        }
    }
}