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
using System.Web.Http.Description;

namespace ColetaEntrega.Controllers
{
    [RoutePrefix("api/central")]
    public class CentralController : ApiController
    {
        private ColetaContext db = new ColetaContext();

        // GET: api/central/GetListaColetas
        [ResponseType(typeof(MestreColeta))]
        public List<MestreColeta> GetListaColetas(int idParticipante, string status)
        {
            var mestreColeta = db.MestreCarga
                                .Where(x => x.ParticipanteId == idParticipante &&
                                (string.IsNullOrEmpty(status) ? x.Status_Coleta == "A" : x.Status_Coleta == status));
            if (mestreColeta == null)
            {
                return null;
            }

            return mestreColeta.ToList();
        }

        // GET: api/central/GetListaColetasItens?mestreid=1&status=A
        [ResponseType(typeof(ItemColeta))]
        public List<ItemColeta> GetListaColetasItens(int mestreid, string status)
        {
            var itemColeta = db.ItemColeta
                                .Where(x => x.MestreColetaId == mestreid &&
                                (string.IsNullOrEmpty(status) ? x.Status_Coleta == "A" : x.Status_Coleta == status));
            if (itemColeta == null)
            {
                return null;
            }

            return itemColeta.ToList();
        }

        // GET: api/central/GetParticipanteUsuario?identificador=???
        [ResponseType(typeof(Participante))]
        public Participante GetParticipanteUsuario(string identificador)
        {
            Participante participante_DTO = new Participante();

            string cgccpf = identificador;
            var participante = db.Participantes
                                .Join(db.Usuarios, e => e.ParticipanteId, d => d.ParticipanteId,
                                (e, d) => new
                                {
                                    e.ParticipanteId,
                                    e.CgcCPF,
                                    e.Email,
                                    d.UsuarioId
                                })
                                .Where(x => x.CgcCPF == cgccpf ||
                                 x.Email == identificador).FirstOrDefault();

            if (participante != null)
            {
                participante_DTO.ParticipanteId = participante.ParticipanteId;
                participante_DTO.CgcCPF = participante.CgcCPF;
                participante_DTO.Email = participante.Email;
                participante_DTO.UsuarioId = participante.UsuarioId;
            }
            else
            {
                return null;
            }

            return participante_DTO;
        }

        [ResponseType(typeof(void))]
        //[HttpPut]
        public IHttpActionResult PutIniciarItemMestreColeta(int idItem)
        {
            ItemColeta itemColeta = new ItemColeta();
            MestreColeta mestreColeta = new MestreColeta();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            itemColeta = db.ItemColeta
                                .Where(x => x.ItemColetaId == idItem).FirstOrDefault();

            if (itemColeta == null) throw new Exception("Não foi encontrado Coleta com esse ID" + idItem.ToString());

            itemColeta.Status_Coleta = "I";
            itemColeta.DtManutencao = DateTime.Now;
            db.Entry(itemColeta).State = EntityState.Modified;

            mestreColeta = db.MestreCarga
                                .Where(x => x.MestreColetaId == itemColeta.MestreColetaId).FirstOrDefault();

            if (mestreColeta == null) throw new Exception("Não foi encontrado Mestre da Coleta com esse ID" + itemColeta.MestreColetaId.ToString());

            mestreColeta.Status_Coleta = "E";
            mestreColeta.DtManutencao = DateTime.Now;
            db.Entry(mestreColeta).State = EntityState.Modified;

            ItemColetaMovimentacao itemColetaMovimentacao = new ItemColetaMovimentacao();
            itemColetaMovimentacao.ItemColetaId = itemColeta.ItemColetaId;
            itemColetaMovimentacao.SgUser = this.User.Identity.Name;
            itemColetaMovimentacao.DhInclusao = DateTime.Now;
            itemColetaMovimentacao.StatusMovimentacao = string.Format("Iniciou a entrega da nota: {0}", itemColeta.Nota);
            db.Entry(itemColetaMovimentacao).State = EntityState.Added;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemColetaExists(idItem))
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

        [ResponseType(typeof(void))]
        //[HttpPut]
        public IHttpActionResult PutFinalizarItemMestreColeta(int idItem)
        {
            ItemColeta itemColeta = new ItemColeta();
            MestreColeta mestreColeta = new MestreColeta();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            itemColeta = db.ItemColeta
                                .Where(x => x.ItemColetaId == idItem).FirstOrDefault();

            if (itemColeta == null) throw new Exception("Não foi encontrado Coleta com esse ID" + idItem.ToString());

            itemColeta.Status_Coleta = "F";
            itemColeta.DtManutencao = DateTime.Now;
            db.Entry(itemColeta).State = EntityState.Modified;

            db.SaveChanges();

            if (db.ItemColeta.Count(e => e.MestreColetaId == itemColeta.MestreColetaId && e.Status_Coleta != "F") == 0)
            {
                mestreColeta = db.MestreCarga
                                    .Where(x => x.MestreColetaId == itemColeta.MestreColetaId).FirstOrDefault();

                if (mestreColeta == null) throw new Exception("Não foi encontrado Mestre da Coleta com esse ID" + itemColeta.MestreColetaId.ToString());

                mestreColeta.Status_Coleta = "F";
                mestreColeta.DtManutencao = DateTime.Now;
                db.Entry(mestreColeta).State = EntityState.Modified;
            }

            ItemColetaMovimentacao itemColetaMovimentacao = new ItemColetaMovimentacao();
            itemColetaMovimentacao.ItemColetaId = itemColeta.ItemColetaId;
            itemColetaMovimentacao.SgUser = this.User.Identity.Name;
            itemColetaMovimentacao.DhInclusao = DateTime.Now;
            itemColetaMovimentacao.StatusMovimentacao = string.Format("Finalizou a entrega da nota: {0}", itemColeta.Nota);
            db.Entry(itemColetaMovimentacao).State = EntityState.Added;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemColetaExists(idItem))
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

        private bool ItemColetaExists(int id)
        {
            return db.ItemColeta.Count(e => e.ItemColetaId == id) > 0;
        }


        [ResponseType(typeof(Participante))]
        public bool GetSenhaUsuario(int usuarioID, string senha)
        {
            var usuario = db.Usuarios
                                .Where(x => x.UsuarioId == usuarioID &&
                                x.Senha == senha &&
                                x.Ativo == "S").FirstOrDefault();
            if (usuario == null)
            {
                return false;
            }

            return true;
        }
        public class Participante
        {
            public int ParticipanteId { get; set; }
            public string CgcCPF { get; set; }
            public string Email { get; set; }
            public int UsuarioId { get; set; }
        }
    }
}
