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
            new GrupoProdutoModel() { Id=1, Nome="Livros", Ativo=true },
            new GrupoProdutoModel() { Id=2, Nome="Mouses", Ativo=true },
            new GrupoProdutoModel() { Id=3, Nome="Monitores", Ativo=false }
        };
        [Authorize]
        public ActionResult GrupoCliente()
        {
            return View();
        }
        [Authorize]
        public ActionResult GrupoProduto()
        {
            return View(_listaGrupoProduto);
        }
    }
}