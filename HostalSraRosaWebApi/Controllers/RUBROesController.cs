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
    public class RUBROesController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/RUBROes
        public IQueryable<RUBRO> GetRUBRO()
        {
            return db.RUBRO;
        }

        // GET: api/RUBROes/5
        [ResponseType(typeof(RUBRO))]
        public IHttpActionResult GetRUBRO(decimal id)
        {
            RUBRO rUBRO = db.RUBRO.Find(id);
            if (rUBRO == null)
            {
                return NotFound();
            }

            return Ok(rUBRO);
        }

        // PUT: api/RUBROes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRUBRO(decimal id, RUBRO rUBRO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rUBRO.RUBRO_ID)
            {
                return BadRequest();
            }

            db.Entry(rUBRO).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RUBROExists(id))
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

        // POST: api/RUBROes
        [ResponseType(typeof(RUBRO))]
        public IHttpActionResult PostRUBRO(RUBRO rUBRO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RUBRO.Add(rUBRO);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (RUBROExists(rUBRO.RUBRO_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = rUBRO.RUBRO_ID }, rUBRO);
        }

        // DELETE: api/RUBROes/5
        [ResponseType(typeof(RUBRO))]
        public IHttpActionResult DeleteRUBRO(decimal id)
        {
            RUBRO rUBRO = db.RUBRO.Find(id);
            if (rUBRO == null)
            {
                return NotFound();
            }

            db.RUBRO.Remove(rUBRO);
            db.SaveChanges();

            return Ok(rUBRO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RUBROExists(decimal id)
        {
            return db.RUBRO.Count(e => e.RUBRO_ID == id) > 0;
        }
    }
}