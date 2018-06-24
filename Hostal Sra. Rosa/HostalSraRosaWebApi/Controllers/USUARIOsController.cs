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
    public class USUARIOsController : ApiController
    {
        private HostalSraRosaApiWebEntities db = new HostalSraRosaApiWebEntities();

        // GET: api/USUARIOs
        public IQueryable<USUARIO> GetUSUARIOs()
        {
            return db.USUARIOs;
        }

        // GET: api/USUARIOs/5
        [ResponseType(typeof(USUARIO))]
        public IHttpActionResult GetUSUARIO(string id)
        {
            USUARIO uSUARIO = db.USUARIOs.Find(id);
            if (uSUARIO == null)
            {
                return NotFound();
            }

            return Ok(uSUARIO);
        }

        // PUT: api/USUARIOs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUSUARIO(string id, USUARIO uSUARIO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != uSUARIO.USUARIO_NOMBRE_USUARIO)
            {
                return BadRequest();
            }

            db.Entry(uSUARIO).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!USUARIOExists(id))
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

        // POST: api/USUARIOs
        [ResponseType(typeof(USUARIO))]
        public IHttpActionResult PostUSUARIO(USUARIO uSUARIO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.USUARIOs.Add(uSUARIO);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (USUARIOExists(uSUARIO.USUARIO_NOMBRE_USUARIO))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = uSUARIO.USUARIO_NOMBRE_USUARIO }, uSUARIO);
        }

        // DELETE: api/USUARIOs/5
        [ResponseType(typeof(USUARIO))]
        public IHttpActionResult DeleteUSUARIO(string id)
        {
            USUARIO uSUARIO = db.USUARIOs.Find(id);
            if (uSUARIO == null)
            {
                return NotFound();
            }

            db.USUARIOs.Remove(uSUARIO);
            db.SaveChanges();

            return Ok(uSUARIO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool USUARIOExists(string id)
        {
            return db.USUARIOs.Count(e => e.USUARIO_NOMBRE_USUARIO == id) > 0;
        }
    }
}