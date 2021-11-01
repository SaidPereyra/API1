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
using API1.Models;

namespace API1.Controllers
{
    public class UsuarioController : ApiController
    {
        private DBEntities db = new DBEntities();

        // GET: api/Usuario
        public IQueryable<DB_Usuarios> GetDB_Usuarios()
        {
            return db.DB_Usuarios;
        }

        // GET: api/Usuario/5
        [ResponseType(typeof(DB_Usuarios))]
        public IHttpActionResult GetDB_Usuarios(int id)
        {
            DB_Usuarios dB_Usuarios = db.DB_Usuarios.Find(id);
            if (dB_Usuarios == null)
            {
                return NotFound();
            }

            return Ok(dB_Usuarios);
        }

        // PUT: api/Usuario/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDB_Usuarios(int id, DB_Usuarios dB_Usuarios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dB_Usuarios.Id)
            {
                return BadRequest();
            }

            db.Entry(dB_Usuarios).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DB_UsuariosExists(id))
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

        // POST: api/Usuario
        [ResponseType(typeof(DB_Usuarios))]
        public IHttpActionResult PostDB_Usuarios(DB_Usuarios dB_Usuarios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DB_Usuarios.Add(dB_Usuarios);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dB_Usuarios.Id }, dB_Usuarios);
        }

        // DELETE: api/Usuario/5
        [ResponseType(typeof(DB_Usuarios))]
        public IHttpActionResult DeleteDB_Usuarios(int id)
        {
            DB_Usuarios dB_Usuarios = db.DB_Usuarios.Find(id);
            if (dB_Usuarios == null)
            {
                return NotFound();
            }

            db.DB_Usuarios.Remove(dB_Usuarios);
            db.SaveChanges();

            return Ok(dB_Usuarios);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DB_UsuariosExists(int id)
        {
            return db.DB_Usuarios.Count(e => e.Id == id) > 0;
        }
    }
}