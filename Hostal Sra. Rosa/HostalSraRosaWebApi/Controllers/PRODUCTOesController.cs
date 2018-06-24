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
    public class PRODUCTOesController : ApiController
    {
        private HostalSraRosaApiWebEntities db = new HostalSraRosaApiWebEntities();

        // GET: api/PRODUCTOes
        public IQueryable<PRODUCTO> GetPRODUCTOes()
        {
            return db.PRODUCTOes;
        }

        // GET: api/PRODUCTOes/5
        [ResponseType(typeof(PRODUCTO))]
        public IHttpActionResult GetPRODUCTO(decimal id)
        {
            PRODUCTO pRODUCTO = db.PRODUCTOes.Find(id);
            if (pRODUCTO == null)
            {
                return NotFound();
            }

            return Ok(pRODUCTO);
        }

        // PUT: api/PRODUCTOes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPRODUCTO(decimal id, PRODUCTO pRODUCTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pRODUCTO.PRODUCTO_ID)
            {
                return BadRequest();
            }

            db.Entry(pRODUCTO).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PRODUCTOExists(id))
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

        // POST: api/PRODUCTOes
        [ResponseType(typeof(PRODUCTO))]
        public IHttpActionResult PostPRODUCTO(PRODUCTO pRODUCTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PRODUCTOes.Add(pRODUCTO);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PRODUCTOExists(pRODUCTO.PRODUCTO_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = pRODUCTO.PRODUCTO_ID }, pRODUCTO);
        }

        // DELETE: api/PRODUCTOes/5
        [ResponseType(typeof(PRODUCTO))]
        public IHttpActionResult DeletePRODUCTO(decimal id)
        {
            PRODUCTO pRODUCTO = db.PRODUCTOes.Find(id);
            if (pRODUCTO == null)
            {
                return NotFound();
            }

            db.PRODUCTOes.Remove(pRODUCTO);
            db.SaveChanges();

            return Ok(pRODUCTO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PRODUCTOExists(decimal id)
        {
            return db.PRODUCTOes.Count(e => e.PRODUCTO_ID == id) > 0;
        }
    }
}