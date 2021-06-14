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
    public class InconformidadesAPIController : ApiController
    {
        private ColetaContext db = new ColetaContext();

        // GET: api/InconformidadesAPI
        public IQueryable<Inconformidade> GetInconformidades()
        {
            return db.Inconformidades;
        }

        // GET: api/InconformidadesAPI/5
        [ResponseType(typeof(Inconformidade))]
        public IHttpActionResult GetInconformidade(int id)
        {
            Inconformidade inconformidade = db.Inconformidades.Find(id);
            if (inconformidade == null)
            {
                return NotFound();
            }

            return Ok(inconformidade);
        }

        // PUT: api/InconformidadesAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutInconformidade(int id, Inconformidade inconformidade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != inconformidade.InconformidadeId)
            {
                return BadRequest();
            }

            db.Entry(inconformidade).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InconformidadeExists(id))
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

        // POST: api/InconformidadesAPI
        [ResponseType(typeof(Inconformidade))]
        public IHttpActionResult PostInconformidade(Inconformidade inconformidade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Inconformidades.Add(inconformidade);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = inconformidade.InconformidadeId }, inconformidade);
        }

        // DELETE: api/InconformidadesAPI/5
        [ResponseType(typeof(Inconformidade))]
        public IHttpActionResult DeleteInconformidade(int id)
        {
            Inconformidade inconformidade = db.Inconformidades.Find(id);
            if (inconformidade == null)
            {
                return NotFound();
            }

            db.Inconformidades.Remove(inconformidade);
            db.SaveChanges();

            return Ok(inconformidade);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InconformidadeExists(int id)
        {
            return db.Inconformidades.Count(e => e.InconformidadeId == id) > 0;
        }
    }
}