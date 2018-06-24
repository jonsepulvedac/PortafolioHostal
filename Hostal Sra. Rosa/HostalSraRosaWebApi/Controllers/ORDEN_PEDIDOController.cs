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
    public class ORDEN_PEDIDOController : ApiController
    {
        private HostalSraRosaApiWebEntities db = new HostalSraRosaApiWebEntities();

        // GET: api/ORDEN_PEDIDO
        public IQueryable<ORDEN_PEDIDO> GetORDEN_PEDIDO()
        {
            return db.ORDEN_PEDIDO;
        }

        // GET: api/ORDEN_PEDIDO/5
        [ResponseType(typeof(ORDEN_PEDIDO))]
        public IHttpActionResult GetORDEN_PEDIDO(decimal id)
        {
            ORDEN_PEDIDO oRDEN_PEDIDO = db.ORDEN_PEDIDO.Find(id);
            if (oRDEN_PEDIDO == null)
            {
                return NotFound();
            }

            return Ok(oRDEN_PEDIDO);
        }

        // PUT: api/ORDEN_PEDIDO/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutORDEN_PEDIDO(decimal id, ORDEN_PEDIDO oRDEN_PEDIDO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != oRDEN_PEDIDO.ORDEN_PEDIDO_ID)
            {
                return BadRequest();
            }

            db.Entry(oRDEN_PEDIDO).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ORDEN_PEDIDOExists(id))
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

        // POST: api/ORDEN_PEDIDO
        [ResponseType(typeof(ORDEN_PEDIDO))]
        public IHttpActionResult PostORDEN_PEDIDO(ORDEN_PEDIDO oRDEN_PEDIDO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ORDEN_PEDIDO.Add(oRDEN_PEDIDO);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ORDEN_PEDIDOExists(oRDEN_PEDIDO.ORDEN_PEDIDO_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = oRDEN_PEDIDO.ORDEN_PEDIDO_ID }, oRDEN_PEDIDO);
        }

        // DELETE: api/ORDEN_PEDIDO/5
        [ResponseType(typeof(ORDEN_PEDIDO))]
        public IHttpActionResult DeleteORDEN_PEDIDO(decimal id)
        {
            ORDEN_PEDIDO oRDEN_PEDIDO = db.ORDEN_PEDIDO.Find(id);
            if (oRDEN_PEDIDO == null)
            {
                return NotFound();
            }

            db.ORDEN_PEDIDO.Remove(oRDEN_PEDIDO);
            db.SaveChanges();

            return Ok(oRDEN_PEDIDO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ORDEN_PEDIDOExists(decimal id)
        {
            return db.ORDEN_PEDIDO.Count(e => e.ORDEN_PEDIDO_ID == id) > 0;
        }
    }
}