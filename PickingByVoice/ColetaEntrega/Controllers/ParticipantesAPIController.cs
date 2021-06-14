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
    public class ParticipantesAPIController : ApiController
    {
        private ColetaContext db = new ColetaContext();

        // GET: api/ParticipantesAPI
        public IQueryable<Participante> GetParticipantes()
        {
            ClsImportacao LCLS_Importacao = new ClsImportacao();
            LCLS_Importacao.SU_ProcessaEDI();
            return db.Participantes;
        }

        // GET: api/ParticipantesAPI/5
        [ResponseType(typeof(Participante))]
        [AllowAnonymous]
        public IHttpActionResult GetParticipante(int id)
        {
            Participante participante = db.Participantes.Find(id);
            if (participante == null)
            {
                return NotFound();
            }

            return Ok(participante);
        }

        // GET: api/ParticipantesAPI/5
        [ResponseType(typeof(Participante))]
        [AllowAnonymous]
        public Participante GetParticipanteCPFCNPJ(string cpfCnpj)
        {
            Participante participante = db.Participantes.Where(x => x.CgcCPF == cpfCnpj).FirstOrDefault();
            if (participante == null)
            {
                return null;
            }

            return participante;
        }

        // PUT: api/ParticipantesAPI/5
        [HttpPut]
        public IHttpActionResult PutParticipante(int id, Participante participante)
        {
            participante.DtManutencao = DateTime.Now;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != participante.ParticipanteId)
            {
                return BadRequest();
            }

            db.Entry(participante).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParticipanteExists(id))
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

        // POST: api/ParticipantesAPI
        //[ResponseType(typeof(string))]
        [HttpPost]
        public IHttpActionResult PostParticipante([FromBody]Participante participantes)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Participantes.Add(participantes);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = participantes.ParticipanteId }, participantes);
        }

        // DELETE: api/ParticipantesAPI/5
        [ResponseType(typeof(Participante))]
        public IHttpActionResult DeleteParticipante(int id)
        {
            Participante participante = db.Participantes.Find(id);
            if (participante == null)
            {
                return NotFound();
            }

            db.Participantes.Remove(participante);
            db.SaveChanges();

            return Ok(participante);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ParticipanteExists(int id)
        {
            return db.Participantes.Count(e => e.ParticipanteId == id) > 0;
        }

        //[ResponseType(typeof(Participante))]
        //public IHttpActionResult GetIdentificador(string identificador)
        //{
        //    //fazer processo para retornar isso
        //    getRetornoParticipanteUsuario obj = null;
        //    CentralController central = new CentralController();
        //    var participante = central.GetParticipanteUsuario(identificador);

        //    obj = new getRetornoParticipanteUsuario();
        //    obj.CgcCPF = participante.CgcCPF;
        //    obj.ParticipanteId = participante.ParticipanteId;
        //    obj.UsuarioId = participante.UsuarioId;
        //    obj.Email = participante.Email;

        //    return Ok(obj);
        //}

        //public class getRetornoParticipanteUsuario
        //{
        //    public int ParticipanteId { get; set; }
        //    public decimal CgcCPF { get; set; }
        //    public string Email { get; set; }
        //    public int UsuarioId { get; set; }
        //}

    }
}