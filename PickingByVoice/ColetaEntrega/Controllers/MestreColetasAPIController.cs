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
    public class MestreColetasAPIController : ApiController
    {
        private ColetaContext db = new ColetaContext();
        public class getRetornoMestreColetaParicipante
        {
            public int idMestreColeta { get; set; }
            public int idEmpresa { get; set; }
            public int nrEntrega { get; set; }
            public string nmEmpresaColeta { get; set; }
            public int qtNotas { get; set; }
            public decimal vlNotas { get; set; }
            public DateTime dtMestreColeta { get; set; }
            public DateTime dtLimite { get; set; }
            public getNotasMestreColeta[] notasMestreColeta { get; set; }

            public class getNotasMestreColeta
            {
                public int idNota { get; set; }
                public int idMestreColeta { get; set; }
                public int idItemColeta { get; set; }
                public int nrNota { get; set; }
                public decimal vlNota { get; set; }
                public string Status_Coleta { get; set; }
            }
        }

        // GET: api/MestreColetasAPI
        public IQueryable<MestreColeta> GetMestreCarga()
        {
            return db.MestreCarga;
        }

        // GET: api/MestreColetasAPI/5
        [ResponseType(typeof(MestreColeta))]
        public IHttpActionResult GetMestreColeta(int id)
        {
            MestreColeta mestreColeta = db.MestreCarga.Find(id);
            if (mestreColeta == null)
            {
                return NotFound();
            }

            return Ok(mestreColeta);
        }
        // GET: api/MestreColetasAPI/5
        [ResponseType(typeof(MestreColeta))]
        public IHttpActionResult GetMestreColetaParticipante(int idSession, int idParticipante, string p_params)
        {
            //fazer processo para retornar isso
            Participante empresaParticipante = new Participante();
            UsuarioEmpresa usuarioEmpresa = new UsuarioEmpresa();
            getRetornoMestreColetaParicipante[] obj = null;
            CentralController central = new CentralController();
            var coletas = central.GetListaColetas(idParticipante, p_params);
            int totalColeta = coletas.Count();
            int indMestre = 0;
            int indItem = 0;
            foreach (var mestre in coletas)
            {
                //Fazer uma classe de retorno, somente para trazer os dados com os nomes prontos
                obj = new getRetornoMestreColetaParicipante[totalColeta];
                obj[indMestre] = new getRetornoMestreColetaParicipante();
                obj[indMestre].idMestreColeta = mestre.MestreColetaId;
                obj[indMestre].nrEntrega = Convert.ToInt32(mestre.NrRomaneio);
                obj[indMestre].qtNotas = mestre.ItemColeta.Count();

                var somaNFes = mestre.ItemColeta.GroupBy(g => new
                {
                    g.MestreColetaId
                }).Select(s => new
                {
                    mestreColetaid = s.Key,
                    totalNota = s.Sum(c => c.Valor),
                }).FirstOrDefault();

                obj[indMestre].vlNotas = Convert.ToDecimal(somaNFes.totalNota);
                obj[indMestre].notasMestreColeta = new getRetornoMestreColetaParicipante.getNotasMestreColeta[mestre.ItemColeta.Count()];

                foreach (var item in mestre.ItemColeta)
                {
                    obj[indMestre].notasMestreColeta[indItem] = new getRetornoMestreColetaParicipante.getNotasMestreColeta();
                    obj[indMestre].notasMestreColeta[indItem].idMestreColeta = item.MestreColetaId;
                    obj[indMestre].notasMestreColeta[indItem].idItemColeta = item.ItemColetaId;
                    obj[indMestre].notasMestreColeta[indItem].idNota = item.ItemColetaId;
                    obj[indMestre].notasMestreColeta[indItem].nrNota = Convert.ToInt32(item.Nota);
                    obj[indMestre].notasMestreColeta[indItem].vlNota = Convert.ToDecimal(item.Valor);
                    obj[indMestre].notasMestreColeta[indItem].Status_Coleta = item.Status_Coleta;

                    string cnpjEmpresaDestino = item.CnpjEmpresaDestino;
                    empresaParticipante = db.Participantes.Where(w => w.CgcCPF == cnpjEmpresaDestino).FirstOrDefault();
                    usuarioEmpresa = db.UsuarioEmpresas.Where(w => w.ParticipanteId == empresaParticipante.ParticipanteId).FirstOrDefault();
                    obj[indMestre].idEmpresa = usuarioEmpresa.UsuarioId;
                    obj[indMestre].nmEmpresaColeta = empresaParticipante.NmRazaoSocial;

                    indItem++;
                }
            }

            return Ok(obj);
        }
        // PUT: api/MestreColetasAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMestreColeta(int id, MestreColeta mestreColeta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mestreColeta.MestreColetaId)
            {
                return BadRequest();
            }

            db.Entry(mestreColeta).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MestreColetaExists(id))
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

        // POST: api/MestreColetasAPI
        [ResponseType(typeof(MestreColeta))]
        public IHttpActionResult PostMestreColeta(MestreColeta mestreColeta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MestreCarga.Add(mestreColeta);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = mestreColeta.MestreColetaId }, mestreColeta);
        }

        // DELETE: api/MestreColetasAPI/5
        [ResponseType(typeof(MestreColeta))]
        public IHttpActionResult DeleteMestreColeta(int id)
        {
            MestreColeta mestreColeta = db.MestreCarga.Find(id);
            if (mestreColeta == null)
            {
                return NotFound();
            }

            db.MestreCarga.Remove(mestreColeta);
            db.SaveChanges();

            return Ok(mestreColeta);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MestreColetaExists(int id)
        {
            return db.MestreCarga.Count(e => e.MestreColetaId == id) > 0;
        }
    }
}