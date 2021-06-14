using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PickingByVoice.Models;

namespace PickingByVoice.Controllers
{
    public class ListaExpedicaosController : Controller
    {
        private ControleContext db = new ControleContext();

        // GET: ListaExpedicaos
        public ActionResult Index()
        {
            ClsImportacao LCLS_Importacao = new ClsImportacao();
            LCLS_Importacao.SU_ImportaArquivo();
            return View(db.ListaExpedicaos.ToList());
        }

        // GET: ListaExpedicaos/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListaExpedicao listaExpedicao = db.ListaExpedicaos.Find(id);
            if (listaExpedicao == null)
            {
                return HttpNotFound();
            }
            return View(listaExpedicao);
        }

        // GET: ListaExpedicaos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ListaExpedicaos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ListaId,ListaNum,ListaSeq,MaterialCod,MaterialDes,EnderecoCod,EnderecoDes,QtdeSolicitada,QtdeSeparada,DhInicio,DhFim,FgExclusivo,UserId,FgStatus,FgQtdeSeparada")] ListaExpedicao listaExpedicao)
        {
            if (ModelState.IsValid)
            {
                db.ListaExpedicaos.Add(listaExpedicao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(listaExpedicao);
        }

        // GET: ListaExpedicaos/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListaExpedicao listaExpedicao = db.ListaExpedicaos.Find(id);
            if (listaExpedicao == null)
            {
                return HttpNotFound();
            }
            return View(listaExpedicao);
        }

        // POST: ListaExpedicaos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ListaId,ListaNum,ListaSeq,MaterialCod,MaterialDes,EnderecoCod,EnderecoDes,QtdeSolicitada,QtdeSeparada,DhInicio,DhFim,FgExclusivo,UserId,FgStatus,FgQtdeSeparada")] ListaExpedicao listaExpedicao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(listaExpedicao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(listaExpedicao);
        }

        // GET: ListaExpedicaos/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListaExpedicao listaExpedicao = db.ListaExpedicaos.Find(id);
            if (listaExpedicao == null)
            {
                return HttpNotFound();
            }
            return View(listaExpedicao);
        }

        // POST: ListaExpedicaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            ListaExpedicao listaExpedicao = db.ListaExpedicaos.Find(id);
            db.ListaExpedicaos.Remove(listaExpedicao);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public void FU_GerarListaEDI()
        {
            DataTable LDTT_EDI_IMPORTA_MESTRE = null;
            DataTable LDTT_EDI_IMPORTA_ITEM = null;
            UsuarioController LCUC_Usuario = new UsuarioController();
            Usuario LUSR_Usuario = new Usuario();
            EDI_IMPORTA_MESTRE LCLS_EDI_IMPORTA_MESTRE = null;
            ListaExpedicao LCLS_LISTAEXPEDICAO = null;
            EDI_IMPORTA_ITEM[] LARR_EDI_IMPORTA_ITEM = null;
            EDI_IMPORTA_ITEM LCLS_EDI_IMPORTA_ITEM = null;
            ControleContext db = new ControleContext();
            Int32 LINT_IdMestre;

            try
            {
                #region Busca Listas importadas
                var result = from EDIIMPORTA_MESTRE in db.EDI_IMPORTA_MESTRE
                             where
                             //EDIIMPORTA_MESTRE.Cadastro == ((cadastro == DateTime.MinValue) ? cli.Cadastro : cadastro) &&
                             //EDIIMPORTA_MESTRE.Cpf == (string.IsNullOrEmpty(cpf) ? cli.Cpf : cpf) &&
                             //EDIIMPORTA_MESTRE.Nome == (string.IsNullOrEmpty(nome) ? cli.Nome : nome)
                             //select EDIIMPORTA_MESTRE;
                             EDIIMPORTA_MESTRE.Status == ("A")
                             select EDIIMPORTA_MESTRE;

                List<EDI_IMPORTA_MESTRE> LIST_EDI_IMPORTA_MESTRES = new List<EDI_IMPORTA_MESTRE>();
                LIST_EDI_IMPORTA_MESTRES = result.ToList();

                List<EDI_IMPORTA_ITEM> LIST_EDI_IMPORTA_ITEM = new List<EDI_IMPORTA_ITEM>();

                if (LIST_EDI_IMPORTA_MESTRES.Count() > 0)
                {
                    for (int LINT_COUNT = 0; LIST_EDI_IMPORTA_MESTRES.Count > LINT_COUNT; LINT_COUNT++)
                    {
                        LINT_IdMestre = LIST_EDI_IMPORTA_MESTRES[LINT_COUNT].ID_IMPORTAMESTRE;

                        var VAR_IMPORTAITEM = from EDIIMPORTA_ITEM in db.EDI_IMPORTA_ITEM
                                              where
                                                  EDIIMPORTA_ITEM.ID_IMPORTAMESTRE == LINT_IdMestre
                                              select EDIIMPORTA_ITEM;

                        LIST_EDI_IMPORTA_ITEM = VAR_IMPORTAITEM.ToList();
                    }
                }
                #endregion

                if (LIST_EDI_IMPORTA_ITEM.Count() > 0)
                {
                    for (int LINT_COUNT = 0; LIST_EDI_IMPORTA_ITEM.Count > LINT_COUNT; LINT_COUNT++)
                    {
                        #region Busca Usuario para incluir na lista
                        LUSR_Usuario = LCUC_Usuario.GetUsuario(LIST_EDI_IMPORTA_ITEM[LINT_COUNT].SGUSER);
                        #endregion

                        LCLS_LISTAEXPEDICAO = new ListaExpedicao();
                        //LCLS_LISTAEXPEDICAO.ListaId = Convert.ToInt32(LAST_LinhaSeparada[0].Replace("\"", ""));
                        LCLS_LISTAEXPEDICAO.ListaNum = LIST_EDI_IMPORTA_ITEM[LINT_COUNT].NRLISTA.ToString();
                        LCLS_LISTAEXPEDICAO.ListaSeq = LIST_EDI_IMPORTA_ITEM[LINT_COUNT].SEQITEM.ToString();
                        LCLS_LISTAEXPEDICAO.MaterialCod = LIST_EDI_IMPORTA_ITEM[LINT_COUNT].CDPRODUTO.ToString();
                        LCLS_LISTAEXPEDICAO.MaterialDes = LIST_EDI_IMPORTA_ITEM[LINT_COUNT].DESCPRODUTO.ToString();
                        LCLS_LISTAEXPEDICAO.EnderecoCod = "";
                        LCLS_LISTAEXPEDICAO.EnderecoDes = LIST_EDI_IMPORTA_ITEM[LINT_COUNT].DESCENDERECO.ToString();
                        LCLS_LISTAEXPEDICAO.QtdeSolicitada = LIST_EDI_IMPORTA_ITEM[LINT_COUNT].QTPEDIDO.ToString();
                        LCLS_LISTAEXPEDICAO.QtdeSeparada = "0";
                        LCLS_LISTAEXPEDICAO.FgExclusivo = "N";
                        LCLS_LISTAEXPEDICAO.FgStatus = LIST_EDI_IMPORTA_ITEM[LINT_COUNT].STATUS.ToString();
                        LCLS_LISTAEXPEDICAO.FgQtdeSeparada = "N";
                        LCLS_LISTAEXPEDICAO.UserId = LUSR_Usuario;
                        db.ListaExpedicaos.Add(LCLS_LISTAEXPEDICAO);
                    }
                    db.SaveChanges();
                }
                
            }
            catch (Exception ex)
            { throw new Exception(ex.Message); }
            finally
            {


            }
        }
    }
}
