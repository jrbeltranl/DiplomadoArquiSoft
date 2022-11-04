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
using UsersMicroService.Models;

namespace UsersMicroService.Controllers
{
    public class RolUsuariosController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/RolUsuarios
        public IQueryable<RolUsuario> GetRolUsuario()
        {
            return db.RolUsuario;
        }

        // GET: api/RolUsuarios/5
        [ResponseType(typeof(RolUsuario))]
        public IHttpActionResult GetRolUsuario(int id)
        {
            RolUsuario rolUsuario = db.RolUsuario.Find(id);
            if (rolUsuario == null)
            {
                return NotFound();
            }

            return Ok(rolUsuario);
        }

        // PUT: api/RolUsuarios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRolUsuario(int id, RolUsuario rolUsuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rolUsuario.ID)
            {
                return BadRequest();
            }

            db.Entry(rolUsuario).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RolUsuarioExists(id))
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

        // POST: api/RolUsuarios
        [ResponseType(typeof(RolUsuario))]
        public IHttpActionResult PostRolUsuario(RolUsuario rolUsuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RolUsuario.Add(rolUsuario);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = rolUsuario.ID }, rolUsuario);
        }

        // DELETE: api/RolUsuarios/5
        [ResponseType(typeof(RolUsuario))]
        public IHttpActionResult DeleteRolUsuario(int id)
        {
            RolUsuario rolUsuario = db.RolUsuario.Find(id);
            if (rolUsuario == null)
            {
                return NotFound();
            }

            db.RolUsuario.Remove(rolUsuario);
            db.SaveChanges();

            return Ok(rolUsuario);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RolUsuarioExists(int id)
        {
            return db.RolUsuario.Count(e => e.ID == id) > 0;
        }
    }
}