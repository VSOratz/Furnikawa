using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using ColetaEntrega.Context;
using ColetaEntrega.Models;

namespace ColetaEntrega.Controllers
{
    public class ItemColetasAPIController : ApiController
    {
        private ColetaContext db = new ColetaContext();

        // GET: api/ItemColetasAPI
        public IQueryable<ItemColeta> GetItemColeta()
        {
            return db.ItemColeta;
        }

        // GET: api/ItemColetasAPI/5
        [ResponseType(typeof(ItemColeta))]
        public IHttpActionResult GetItemColeta(int id)
        {
            getRetornoItemColeta[] obj = null;
            ItemColeta itemColeta = db.ItemColeta.Find(id);
            int indItem = 0;
            obj = new getRetornoItemColeta[1];

            if (itemColeta != null)
            {
                obj[0] = new getRetornoItemColeta();
                obj[0].notasItensColeta = new getRetornoItemColeta.getItens[1];
                obj[0].notasItensColeta[indItem] = new getRetornoItemColeta.getItens();

                obj[0].notasItensColeta[indItem].MestreColetaId = itemColeta.MestreColetaId;
                obj[0].notasItensColeta[indItem].ItemColetaId = itemColeta.ItemColetaId;
                obj[0].notasItensColeta[indItem].DhColeta = itemColeta.DhColeta;
                obj[0].notasItensColeta[indItem].Valor = itemColeta.Valor;
                obj[0].notasItensColeta[indItem].Quantidade = itemColeta.Quantidade;
                obj[0].notasItensColeta[indItem].Peso = itemColeta.Peso;
                obj[0].notasItensColeta[indItem].Nota = itemColeta.Nota;
                obj[0].notasItensColeta[indItem].Tipo_Coleta = itemColeta.Tipo_Coleta;
                obj[0].notasItensColeta[indItem].Status_Coleta = itemColeta.Status_Coleta;
                obj[0].notasItensColeta[indItem].ParticipanteId = itemColeta.ParticipanteId;
                obj[0].notasItensColeta[indItem].CnpjEmpresaDestino = itemColeta.CnpjEmpresaDestino;
                obj[0].notasItensColeta[indItem].EmpresaDestino = itemColeta.EmpresaDestino;
                obj[0].notasItensColeta[indItem].Rua = itemColeta.Rua;
                obj[0].notasItensColeta[indItem].Numero = itemColeta.Numero;
                obj[0].notasItensColeta[indItem].Complemento = itemColeta.Complemento;
                obj[0].notasItensColeta[indItem].Bairro = itemColeta.Bairro;
                obj[0].notasItensColeta[indItem].SgUser = itemColeta.SgUser;
                obj[0].notasItensColeta[indItem].DtManutencao = itemColeta.DtManutencao;
            }

            return Ok(obj.FirstOrDefault());
        }

        // PUT: api/ItemColetasAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutItemColeta(int id, ItemColeta itemColeta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != itemColeta.ItemColetaId)
            {
                return BadRequest();
            }

            db.Entry(itemColeta).State = EntityState.Modified;

            ItemColetaMovimentacao itemColetaMovimentacao = new ItemColetaMovimentacao();
            itemColetaMovimentacao.ItemColetaId = itemColeta.ItemColetaId;
            itemColetaMovimentacao.SgUser = this.User.Identity.Name;
            itemColetaMovimentacao.DhInclusao = DateTime.Now;
            itemColetaMovimentacao.StatusMovimentacao = string.Format("Alterou a nota: {0}", itemColeta.Nota);
            db.Entry(itemColetaMovimentacao).State = EntityState.Added;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemColetaExists(id))
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

        // POST: api/ItemColetasAPI
        [ResponseType(typeof(ItemColeta))]
        public IHttpActionResult PostItemColeta(ItemColeta itemColeta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ItemColeta.Add(itemColeta);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = itemColeta.ItemColetaId }, itemColeta);
        }

        // DELETE: api/ItemColetasAPI/5
        [ResponseType(typeof(ItemColeta))]
        public IHttpActionResult DeleteItemColeta(int id)
        {
            ItemColeta itemColeta = db.ItemColeta.Find(id);
            if (itemColeta == null)
            {
                return NotFound();
            }

            db.ItemColeta.Remove(itemColeta);
            db.SaveChanges();

            return Ok(itemColeta);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ItemColetaExists(int id)
        {
            return db.ItemColeta.Count(e => e.ItemColetaId == id) > 0;
        }

        [ResponseType(typeof(ItemColeta))]
        public IHttpActionResult GetItemColeta(int idMestre, string p_params)
        {
            //fazer processo para retornar isso
            getRetornoItemColeta[] obj = null;
            CentralController central = new CentralController();
            var coletas = central.GetListaColetasItens(idMestre, p_params);
            int totalColeta = coletas.Count();

            int indItem = 0;
            if (totalColeta > 0)
            {
                obj = new getRetornoItemColeta[totalColeta];
                obj[0] = new getRetornoItemColeta();
                obj[0].notasItensColeta = new getRetornoItemColeta.getItens[totalColeta];
                foreach (var item in coletas)
                {
                    obj[0].notasItensColeta[indItem] = new getRetornoItemColeta.getItens();
                    obj[0].notasItensColeta[indItem].MestreColetaId = item.MestreColetaId;
                    obj[0].notasItensColeta[indItem].ItemColetaId = item.ItemColetaId;
                    obj[0].notasItensColeta[indItem].DhColeta = item.DhColeta;
                    obj[0].notasItensColeta[indItem].Valor = item.Valor;
                    obj[0].notasItensColeta[indItem].Quantidade = item.Quantidade;
                    obj[0].notasItensColeta[indItem].Peso = item.Peso;
                    obj[0].notasItensColeta[indItem].Nota = item.Nota;
                    obj[0].notasItensColeta[indItem].Tipo_Coleta = item.Tipo_Coleta;
                    obj[0].notasItensColeta[indItem].Status_Coleta = item.Status_Coleta;
                    obj[0].notasItensColeta[indItem].ParticipanteId = item.ParticipanteId;
                    obj[0].notasItensColeta[indItem].CnpjEmpresaDestino = item.CnpjEmpresaDestino;
                    obj[0].notasItensColeta[indItem].EmpresaDestino = item.EmpresaDestino;
                    obj[0].notasItensColeta[indItem].Rua = item.Rua;
                    obj[0].notasItensColeta[indItem].Numero = item.Numero;
                    obj[0].notasItensColeta[indItem].Complemento = item.Complemento;
                    obj[0].notasItensColeta[indItem].Bairro = item.Bairro;
                    obj[0].notasItensColeta[indItem].SgUser = item.SgUser;
                    obj[0].notasItensColeta[indItem].DtManutencao = item.DtManutencao;

                    indItem++;
                }
            }
            return Ok(obj);
        }


        public class getRetornoItemColeta
        {
            public getItens[] notasItensColeta { get; set; }

            public class getItens
            {
                public int ItemColetaId { get; set; }
                public DateTime DhColeta { get; set; }
                public decimal Valor { get; set; }
                public decimal Quantidade { get; set; }
                public decimal Peso { get; set; }
                public decimal Nota { get; set; }
                public int MestreColetaId { get; set; }
                public string Tipo_Coleta { get; set; }
                public string Status_Coleta { get; set; }
                public int ParticipanteId { get; set; }
                public string CnpjEmpresaDestino { get; set; }
                public string EmpresaDestino { get; set; }
                public string Rua { get; set; }
                public decimal Numero { get; set; }
                public string Complemento { get; set; }
                public string Bairro { get; set; }
                public string SgUser { get; set; }
                public DateTime DtManutencao { get; set; }

            }
        }
    }
}