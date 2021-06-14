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
    public class ItemColetaMovimentacaosAPIController : ApiController
    {
        private ColetaContext db = new ColetaContext();

        // GET: api/ItemColetaMovimentacaosAPI
        public IQueryable<ItemColetaMovimentacao> GetItemColetaMovimentacaos()
        {
            return db.ItemColetaMovimentacaos;
        }

        // GET: api/ItemColetaMovimentacaosAPI/5
        [ResponseType(typeof(ItemColetaMovimentacao))]
        public IHttpActionResult GetItemColetaMovimentacao(int id)
        {
            ItemColetaMovimentacao itemColetaMovimentacao = db.ItemColetaMovimentacaos.Find(id);
            if (itemColetaMovimentacao == null)
            {
                return NotFound();
            }

            return Ok(itemColetaMovimentacao);
        }

        // PUT: api/ItemColetaMovimentacaosAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutItemColetaMovimentacao(int id, ItemColetaMovimentacao itemColetaMovimentacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != itemColetaMovimentacao.ItemColetaId)
            {
                return BadRequest();
            }

            db.Entry(itemColetaMovimentacao).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemColetaMovimentacaoExists(id))
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

        // POST: api/ItemColetaMovimentacaosAPI
        [ResponseType(typeof(ItemColetaMovimentacao))]
        public IHttpActionResult PostItemColetaMovimentacao(ItemColetaMovimentacao itemColetaMovimentacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ItemColetaMovimentacaos.Add(itemColetaMovimentacao);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ItemColetaMovimentacaoExists(itemColetaMovimentacao.ItemColetaId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = itemColetaMovimentacao.ItemColetaId }, itemColetaMovimentacao);
        }

        // DELETE: api/ItemColetaMovimentacaosAPI/5
        [ResponseType(typeof(ItemColetaMovimentacao))]
        public IHttpActionResult DeleteItemColetaMovimentacao(int id)
        {
            ItemColetaMovimentacao itemColetaMovimentacao = db.ItemColetaMovimentacaos.Find(id);
            if (itemColetaMovimentacao == null)
            {
                return NotFound();
            }

            db.ItemColetaMovimentacaos.Remove(itemColetaMovimentacao);
            db.SaveChanges();

            return Ok(itemColetaMovimentacao);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ItemColetaMovimentacaoExists(int id)
        {
            return db.ItemColetaMovimentacaos.Count(e => e.ItemColetaId == id) > 0;
        }
    }
}