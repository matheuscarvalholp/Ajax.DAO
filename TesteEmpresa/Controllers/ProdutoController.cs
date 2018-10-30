using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteEmpresa.Models;

namespace TesteEmpresa.Controllers
{
    public class ProdutoController : Controller
    {
        DAO dao = new DAO();

        // GET: Produto
        public ActionResult Index()
        {
            var lista = dao.MostrarProdutos();
            return View(lista);
        }
        public ActionResult InserirProduto()
        {
            return View();
        }
        public ActionResult CadastrarProduto(string descricao, string quantidade, string valor)
        {
            dao.InserirProduto(descricao, Convert.ToInt32(quantidade), decimal.Parse(valor)); /*dao VAI RECEBER AS FUNÇOES QUE VÃO VIR DO JQUERY INSERIR PRODUTO*/
            return RedirectToAction("Index");
        }
        public ActionResult DeletarProduto(int id)
        {
            dao.DeletarProduto(id);
            return RedirectToAction("Index");
        }
        public ActionResult EditarProduto(int id)
        {
            
            var lista = dao.MostrarProdutos(id);
            return View(lista[0]);
        }
        public ActionResult Edit(int id, string descricao, int quantidade, decimal valor)
        {
            dao.Editar(id, descricao, quantidade, valor);
            return RedirectToAction("Index");
        }
    }
}