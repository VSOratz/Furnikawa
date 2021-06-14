using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PickingByVoice.Classes;

namespace PickingByVoice.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ListaExpedicaosController LCLS_Importacao = new ListaExpedicaosController();
            LCLS_Importacao.FU_GerarListaEDI();

            //Utilidades.FU_VerificaNotificacao();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}