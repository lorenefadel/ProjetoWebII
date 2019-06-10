using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sistema.Models;
using System.Collections.Generic;
using System.Linq;

namespace Sistema.Controllers
{
    public class PlanoDeAulaController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.ListaPlanosDeAula = new PlanoDeAulaModel().ListarPlanosDeAula();

            return View();
        }

        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            if (id != null)
            {
                PlanoDeAulaModel PlanoDeAula = new PlanoDeAulaModel().RetornarPlanoDeAula(id);

                return View("DetalhesCadastro", PlanoDeAula);
            }

            ViewBag.ListaDisciplinas = new DisciplinaModel().ListarDisciplinas().Select(c => new SelectListItem() { Text = c.Descricao, Value = c.Id.ToString() }).ToList();

            return View();
        }

        [HttpPost]
        public IActionResult DetalhesCadastro(PlanoDeAulaModel PlanoDeAula)
        {
            PlanoDeAula.UpdateFields();

            return View(PlanoDeAula);
        }

        [HttpPost]
        public IActionResult Cadastro(
            PlanoDeAulaModel PlanoDeAula, 
            List<ConteudoPlanoDeAula> conteudo,
            List<AvaliacaoPlanoDeAula> notas,
            List<string> basica,
            List<string> complementar
        )
        {
            if (ModelState.IsValid)
            {
                PlanoDeAula.Gravar(conteudo, basica, complementar, notas);

                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Excluir(int id)
        {
            ViewData["IdExcluir"] = id;

            return View();
        }

        public IActionResult ExcluirPlanoDeAula(int id)
        {
            new PlanoDeAulaModel().Excluir(id);

            return View();
        }
    }
}