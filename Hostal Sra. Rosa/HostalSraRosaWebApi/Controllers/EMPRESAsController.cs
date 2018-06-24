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
    public class EMPRESAsController : ApiController
    {
        private HostalSraRosaApiWebEntities db = new HostalSraRosaApiWebEntities();

        // GET: api/EMPRESAs
        public IQueryable<EMPRESA> GetEMPRESAs()
        {
            return db.EMPRESAs;
        }

        // GET: api/EMPRESAs/5
        [ResponseType(typeof(EMPRESA))]
        public IHttpActionResult GetEMPRESA(decimal id)
        {
            EMPRESA eMPRESA = db.EMPRESAs.Find(id);
            if (eMPRESA == null)
            {
                return NotFound();
            }

            return Ok(eMPRESA);
        }

        // PUT: api/EMPRESAs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEMPRESA(decimal id, EMPRESA eMPRESA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eMPRESA.EMPRESA_RUT)
            {
                return BadRequest();
            }

            db.Entry(eMPRESA).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EMPRESAExists(id))
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

        // POST: api/EMPRESAs
        [ResponseType(typeof(EMPRESA))]
        public IHttpActionResult PostEMPRESA(EMPRESA eMPRESA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EMPRESAs.Add(eMPRESA);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (EMPRESAExists(eMPRESA.EMPRESA_RUT))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = eMPRESA.EMPRESA_RUT }, eMPRESA);
        }

        // DELETE: api/EMPRESAs/5
        [ResponseType(typeof(EMPRESA))]
        public IHttpActionResult DeleteEMPRESA(decimal id)
        {
            EMPRESA eMPRESA = db.EMPRESAs.Find(id);
            if (eMPRESA == null)
            {
                return NotFound();
            }

            db.EMPRESAs.Remove(eMPRESA);
            db.SaveChanges();

            return Ok(eMPRESA);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EMPRESAExists(decimal id)
        {
            return db.EMPRESAs.Count(e => e.EMPRESA_RUT == id) > 0;
        }
    }
}