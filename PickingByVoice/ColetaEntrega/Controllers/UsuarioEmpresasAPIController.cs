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
using ColetaEntrega.Context;
using ColetaEntrega.Models;

namespace ColetaEntrega.Controllers
{
    public class UsuarioEmpresasAPIController : ApiController
    {
        private ColetaContext db = new ColetaContext();

        // GET: api/UsuarioEmpresasAPI
        public IQueryable<UsuarioEmpresa> GetUsuarioEmpresas()
        {
            return db.UsuarioEmpresas;
        }

        // GET: api/UsuarioEmpresasAPI/5
        [ResponseType(typeof(UsuarioEmpresa))]
        public IHttpActionResult GetUsuarioEmpresa(int id)
        {
            UsuarioEmpresa usuarioEmpresa = db.UsuarioEmpresas.Find(id);
            if (usuarioEmpresa == null)
            {
                return NotFound();
            }

            return Ok(usuarioEmpresa);
        }

        // PUT: api/UsuarioEmpresasAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUsuarioEmpresa(int id, UsuarioEmpresa usuarioEmpresa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usuarioEmpresa.UsuarioId)
            {
                return BadRequest();
            }

            db.Entry(usuarioEmpresa).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioEmpresaExists(id))
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

        // POST: api/UsuarioEmpresasAPI
        [ResponseType(typeof(UsuarioEmpresa))]
        public IHttpActionResult PostUsuarioEmpresa(UsuarioEmpresa usuarioEmpresa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UsuarioEmpresas.Add(usuarioEmpresa);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (UsuarioEmpresaExists(usuarioEmpresa.UsuarioId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = usuarioEmpresa.UsuarioId }, usuarioEmpresa);
        }

        // DELETE: api/UsuarioEmpresasAPI/5
        [ResponseType(typeof(UsuarioEmpresa))]
        public IHttpActionResult DeleteUsuarioEmpresa(int id)
        {
            UsuarioEmpresa usuarioEmpresa = db.UsuarioEmpresas.Find(id);
            if (usuarioEmpresa == null)
            {
                return NotFound();
            }

            db.UsuarioEmpresas.Remove(usuarioEmpresa);
            db.SaveChanges();

            return Ok(usuarioEmpresa);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsuarioEmpresaExists(int id)
        {
            return db.UsuarioEmpresas.Count(e => e.UsuarioId == id) > 0;
        }
    }
}