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
    public class DocumentosAPIController : ApiController
    {
        private ColetaContext db = new ColetaContext();

        // GET: api/DocumentosAPI
        public IQueryable<Documento> GetDocumentos()
        {
            return db.Documentos;
        }

        // GET: api/DocumentosAPI/5
        [ResponseType(typeof(Documento))]
        public IHttpActionResult GetDocumento(int id)
        {
            Documento documento = db.Documentos.Find(id);
            if (documento == null)
            {
                return NotFound();
            }

            return Ok(documento);
        }

        // PUT: api/DocumentosAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDocumento(int id, Documento documento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != documento.DocumentoId)
            {
                return BadRequest();
            }

            db.Entry(documento).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocumentoExists(id))
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

        // POST: api/DocumentosAPI
        [ResponseType(typeof(Documento))]
        public IHttpActionResult PostDocumento(Documento documento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Documentos.Add(documento);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = documento.DocumentoId }, documento);
        }

        // DELETE: api/DocumentosAPI/5
        [ResponseType(typeof(Documento))]
        public IHttpActionResult DeleteDocumento(int id)
        {
            Documento documento = db.Documentos.Find(id);
            if (documento == null)
            {
                return NotFound();
            }

            db.Documentos.Remove(documento);
            db.SaveChanges();

            return Ok(documento);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DocumentoExists(int id)
        {
            return db.Documentos.Count(e => e.DocumentoId == id) > 0;
        }
    }
}