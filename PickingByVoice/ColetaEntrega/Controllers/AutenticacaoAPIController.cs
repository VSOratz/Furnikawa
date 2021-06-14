using ColetaEntrega.Context;
using ColetaEntrega.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ColetaEntrega.Controllers
{
    public class AutenticacaoAPIController : ApiController
    {
        private ColetaContext db = new ColetaContext();
        // GET: api/AutenticacaoAPI
        public IEnumerable<string> Get()
        {
            //importa arquivo
            ClsImportacao objclsInsportacao = new ClsImportacao();
            objclsInsportacao.SU_ProcessaEDI();

            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        // GET: api/AutenticacaoAPI/GetPrimeiroAcesso
        public IEnumerable<string> GetPrimeiroAcesso(string dsEmail)
        {
            //retorna 
            //se existe usuario retorna true, se nao false,
            // e retorna o id do Participante - usuario
            CentralController central = new CentralController();
            var participante = central.GetParticipanteUsuario(dsEmail);

            if (participante != null)
            {
                getRetornoParticipanteUsuario obj = new getRetornoParticipanteUsuario();
                obj.CgcCPF = participante.CgcCPF;
                obj.ParticipanteId = participante.ParticipanteId;
                obj.UsuarioId = participante.UsuarioId;
                obj.Email = participante.Email;

                return new string[] { "true", participante.ParticipanteId.ToString(), participante.UsuarioId.ToString() };
            }
            else
            {
                return new string[] { "false", "0" };
            }
        }

        [HttpGet]
        // GET: api/AutenticacaoAPI/GetValidaUsuarioSenha
        public IEnumerable<string> GetValidaUsuarioSenha(string login, string senha)
        {
            //retorna 
            //se existe usuario retorna true, se nao false,
            // e retorna o id do Participante - usuario
            CentralController central = new CentralController();
            var participante = central.GetParticipanteUsuario(login);

            if (participante != null)
            {
                if (central.GetSenhaUsuario(participante.UsuarioId, senha)) return new string[] { "true", participante.UsuarioId.ToString() };
                else return new string[] { "false", "0" };
            }
            else return new string[] { "false", "0" };

        }


        [HttpPut]
        public IHttpActionResult PutSenhaUsuario(int id, Usuario usuario)
        {
            //lembrar de fazer metodo de verificacao da antiga senha

            usuario.DhAlteracao = DateTime.Now;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usuario.ParticipanteId)
            {
                return BadRequest();
            }

            db.Entry(usuario).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
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

        private bool UsuarioExists(int id)
        {
            return db.Usuarios.Count(e => e.UsuarioId == id) > 0;
        }

        public class getRetornoParticipanteUsuario
        {
            public int ParticipanteId { get; set; }
            public string CgcCPF { get; set; }
            public string Email { get; set; }
            public int UsuarioId { get; set; }
        }

        // POST: api/AutenticacaoAPI
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/AutenticacaoAPI/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/AutenticacaoAPI/5
        public void Delete(int id)
        {
        }
    }
}
