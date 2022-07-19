using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaRecebimento.Controllers
{
    public class RecebimentoController : Controller
    {
        [Authorize]
        public ActionResult Recebimento()
        {
            return View();
        }
    }
}