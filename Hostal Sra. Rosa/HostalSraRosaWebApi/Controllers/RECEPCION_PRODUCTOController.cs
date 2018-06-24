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
    public class RECEPCION_PRODUCTOController : ApiController
    {
        private HostalSraRosaApiWebEntities db = new HostalSraRosaApiWebEntities();

        // GET: api/RECEPCION_PRODUCTO
        public IQueryable<RECEPCION_PRODUCTO> GetRECEPCION_PRODUCTO()
        {
            return db.RECEPCION_PRODUCTO;
        }

        // GET: api/RECEPCION_PRODUCTO/5
        [ResponseType(typeof(RECEPCION_PRODUCTO))]
        public IHttpActionResult GetRECEPCION_PRODUCTO(decimal id)
        {
            RECEPCION_PRODUCTO rECEPCION_PRODUCTO = db.RECEPCION_PRODUCTO.Find(id);
            if (rECEPCION_PRODUCTO == null)
            {
                return NotFound();
            }

            return Ok(rECEPCION_PRODUCTO);
        }

        // PUT: api/RECEPCION_PRODUCTO/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRECEPCION_PRODUCTO(decimal id, RECEPCION_PRODUCTO rECEPCION_PRODUCTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rECEPCION_PRODUCTO.RECEPCION_PRODUCTO_ID)
            {
                return BadRequest();
            }

            db.Entry(rECEPCION_PRODUCTO).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RECEPCION_PRODUCTOExists(id))
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

        // POST: api/RECEPCION_PRODUCTO
        [ResponseType(typeof(RECEPCION_PRODUCTO))]
        public IHttpActionResult PostRECEPCION_PRODUCTO(RECEPCION_PRODUCTO rECEPCION_PRODUCTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RECEPCION_PRODUCTO.Add(rECEPCION_PRODUCTO);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (RECEPCION_PRODUCTOExists(rECEPCION_PRODUCTO.RECEPCION_PRODUCTO_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = rECEPCION_PRODUCTO.RECEPCION_PRODUCTO_ID }, rECEPCION_PRODUCTO);
        }

        // DELETE: api/RECEPCION_PRODUCTO/5
        [ResponseType(typeof(RECEPCION_PRODUCTO))]
        public IHttpActionResult DeleteRECEPCION_PRODUCTO(decimal id)
        {
            RECEPCION_PRODUCTO rECEPCION_PRODUCTO = db.RECEPCION_PRODUCTO.Find(id);
            if (rECEPCION_PRODUCTO == null)
            {
                return NotFound();
            }

            db.RECEPCION_PRODUCTO.Remove(rECEPCION_PRODUCTO);
            db.SaveChanges();

            return Ok(rECEPCION_PRODUCTO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RECEPCION_PRODUCTOExists(decimal id)
        {
            return db.RECEPCION_PRODUCTO.Count(e => e.RECEPCION_PRODUCTO_ID == id) > 0;
        }
    }
}