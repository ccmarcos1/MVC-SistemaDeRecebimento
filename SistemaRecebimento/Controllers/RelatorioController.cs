using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaRecebimento.Controllers
{
    public class RelatorioController : Controller
    {
        [Authorize]
        public ActionResult GrupoRecebimento()
        {
            return View();
        }
        [Authorize]
        public ActionResult GrupoConciliacao()
        {
            return View();
        }
    }
}