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
    public class UsuarioEmpresaHistoricoesAPIController : ApiController
    {
        private ColetaContext db = new ColetaContext();

        // GET: api/UsuarioEmpresaHistoricoesAPI
        public IQueryable<UsuarioEmpresaHistorico> GetUsuarioEmpresaHistoricos()
        {
            return db.UsuarioEmpresaHistoricos;
        }

        // GET: api/UsuarioEmpresaHistoricoesAPI/5
        [ResponseType(typeof(UsuarioEmpresaHistorico))]
        public IHttpActionResult GetUsuarioEmpresaHistorico(int id)
        {
            UsuarioEmpresaHistorico usuarioEmpresaHistorico = db.UsuarioEmpresaHistoricos.Find(id);
            if (usuarioEmpresaHistorico == null)
            {
                return NotFound();
            }

            return Ok(usuarioEmpresaHistorico);
        }

        // PUT: api/UsuarioEmpresaHistoricoesAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUsuarioEmpresaHistorico(int id, UsuarioEmpresaHistorico usuarioEmpresaHistorico)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usuarioEmpresaHistorico.UsuarioEmpresaHistoricoId)
            {
                return BadRequest();
            }

            db.Entry(usuarioEmpresaHistorico).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioEmpresaHistoricoExists(id))
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

        // POST: api/UsuarioEmpresaHistoricoesAPI
        [ResponseType(typeof(UsuarioEmpresaHistorico))]
        public IHttpActionResult PostUsuarioEmpresaHistorico(UsuarioEmpresaHistorico usuarioEmpresaHistorico)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UsuarioEmpresaHistoricos.Add(usuarioEmpresaHistorico);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = usuarioEmpresaHistorico.UsuarioEmpresaHistoricoId }, usuarioEmpresaHistorico);
        }

        // DELETE: api/UsuarioEmpresaHistoricoesAPI/5
        [ResponseType(typeof(UsuarioEmpresaHistorico))]
        public IHttpActionResult DeleteUsuarioEmpresaHistorico(int id)
        {
            UsuarioEmpresaHistorico usuarioEmpresaHistorico = db.UsuarioEmpresaHistoricos.Find(id);
            if (usuarioEmpresaHistorico == null)
            {
                return NotFound();
            }

            db.UsuarioEmpresaHistoricos.Remove(usuarioEmpresaHistorico);
            db.SaveChanges();

            return Ok(usuarioEmpresaHistorico);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsuarioEmpresaHistoricoExists(int id)
        {
            return db.UsuarioEmpresaHistoricos.Count(e => e.UsuarioEmpresaHistoricoId == id) > 0;
        }
    }
}