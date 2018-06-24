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
    public class EMPLEADOesController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/EMPLEADOes
        public IQueryable<EMPLEADO> GetEMPLEADO()
        {
            return db.EMPLEADO;
        }

        // GET: api/EMPLEADOes/5
        [ResponseType(typeof(EMPLEADO))]
        public IHttpActionResult GetEMPLEADO(decimal id)
        {
            EMPLEADO eMPLEADO = db.EMPLEADO.Find(id);
            if (eMPLEADO == null)
            {
                return NotFound();
            }

            return Ok(eMPLEADO);
        }

        // PUT: api/EMPLEADOes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEMPLEADO(decimal id, EMPLEADO eMPLEADO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eMPLEADO.EMPLEADO_RUT)
            {
                return BadRequest();
            }

            db.Entry(eMPLEADO).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EMPLEADOExists(id))
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

        // POST: api/EMPLEADOes
        [ResponseType(typeof(EMPLEADO))]
        public IHttpActionResult PostEMPLEADO(EMPLEADO eMPLEADO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EMPLEADO.Add(eMPLEADO);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (EMPLEADOExists(eMPLEADO.EMPLEADO_RUT))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = eMPLEADO.EMPLEADO_RUT }, eMPLEADO);
        }

        // DELETE: api/EMPLEADOes/5
        [ResponseType(typeof(EMPLEADO))]
        public IHttpActionResult DeleteEMPLEADO(decimal id)
        {
            EMPLEADO eMPLEADO = db.EMPLEADO.Find(id);
            if (eMPLEADO == null)
            {
                return NotFound();
            }

            db.EMPLEADO.Remove(eMPLEADO);
            db.SaveChanges();

            return Ok(eMPLEADO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EMPLEADOExists(decimal id)
        {
            return db.EMPLEADO.Count(e => e.EMPLEADO_RUT == id) > 0;
        }
    }
}