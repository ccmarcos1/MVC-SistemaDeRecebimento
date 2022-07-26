using SistemaRecebimento.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaRecebimento.Controllers
{
    public class CadastroController : Controller
    {
        private static List<GrupoProdutoModel> _listaGrupoProduto = new List<GrupoProdutoModel>()
        {
            new GrupoProdutoModel() { Id=1, Nome="Livros", Quantidade=3 },
            new GrupoProdutoModel() { Id=2, Nome="Mouses", Quantidade=2 },
            new GrupoProdutoModel() { Id=3, Nome="Monitores", Quantidade=1 }
        };

        [Authorize]
        public ActionResult GrupoProduto()
        {
            return View(GrupoProdutoModel.RecuperarLista(null));
        }
        [Authorize]
        public ActionResult GrupoCliente()
        {
            return View();
        }
    }
}