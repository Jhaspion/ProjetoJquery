using System.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjetoProdutos.Models;

namespace ProjetoProdutos.Controllers
{
    public class ProdutosController : Controller
    {
        ProdutosDao dao = new ProdutosDao();
        // GET: Produtos
        public ActionResult Index()
        {
            var lista = dao.ExibiProdutos();
            return View(lista);
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Salvar(string descricao, int valor)
        {
            dao.InserirRegistro(descricao,valor);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            dao.DeletarRegistro(id);
            return RedirectToAction("Index");
        }
    }
}