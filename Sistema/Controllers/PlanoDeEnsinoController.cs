using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sistema.Models;
using System.Collections.Generic;
using System.Linq;

namespace Sistema.Controllers
{
    public class PlanoDeEnsinoController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.ListaPlanosDeEnsino = new PlanoDeEnsinoModel().ListarPlanosDeEnsino();

            return View();
        }

        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            if (id != null)
            {
                PlanoDeEnsinoModel PlanoDeEnsino = new PlanoDeEnsinoModel().RetornarPlanoDeEnsino(id);

                ViewBag.ListaObjetivos = new ObjetivoModel().ListarObjetivos().Where(s => s.IdDisciplina == PlanoDeEnsino.IdDisciplina.Value.ToString()).Select(c => new SelectListItem() { Text = c.Descricao, Value = c.Id.ToString() }).ToList();
                ViewBag.ListaCompetencias = new CompetenciaModel().ListarCompetencias().Where(s => s.IdDisciplina == PlanoDeEnsino.IdDisciplina.Value.ToString()).Select(c => new SelectListItem() { Text = c.Descricao, Value = c.Id.ToString() }).ToList();
                ViewBag.ListaHabilidades = new HabilidadeModel().ListarHabilidades().Where(s => s.IdDisciplina == PlanoDeEnsino.IdDisciplina.Value.ToString()).Select(c => new SelectListItem() { Text = c.Descricao, Value = c.Id.ToString() }).ToList();

                return View("DetalhesCadastro", PlanoDeEnsino);
            }

            ViewBag.ListaDisciplinas = new DisciplinaModel().ListarDisciplinas().Select(c => new SelectListItem() { Text = c.Descricao, Value = c.Id.ToString() }).ToList();
            ViewBag.ListaProfessores = new ProfessorModel().ListarProfessores().Select(c => new SelectListItem() { Text = c.Nome, Value = c.Id.ToString() }).ToList();

            return View();
        }

        [HttpPost]
        public IActionResult DetalhesCadastro(PlanoDeEnsinoModel PlanoDeEnsino)
        {
            ViewBag.ListaObjetivos = new ObjetivoModel().ListarObjetivos().Where(s => s.IdDisciplina == PlanoDeEnsino.IdDisciplina.Value.ToString()).Select(c => new SelectListItem() { Text = c.Descricao, Value = c.Id.ToString() }).ToList();
            ViewBag.ListaCompetencias = new CompetenciaModel().ListarCompetencias().Where(s => s.IdDisciplina == PlanoDeEnsino.IdDisciplina.Value.ToString()).Select(c => new SelectListItem() { Text = c.Descricao, Value = c.Id.ToString() }).ToList();
            ViewBag.ListaHabilidades = new HabilidadeModel().ListarHabilidades().Where(s => s.IdDisciplina == PlanoDeEnsino.IdDisciplina.Value.ToString()).Select(c => new SelectListItem() { Text = c.Descricao, Value = c.Id.ToString() }).ToList();

            PlanoDeEnsino.UpdateFields();

            return View(PlanoDeEnsino);
        }

        [HttpPost]
        public IActionResult Cadastro(
            PlanoDeEnsinoModel PlanoDeEnsino, 
            List<int> objetivos, 
            List<int> competencias, 
            List<int> habilidades,
            List<string> basica,
            List<string> complementar,
            List<string> nde
        )
        {
            if (ModelState.IsValid)
            {
                PlanoDeEnsino.Gravar(objetivos, competencias, habilidades, basica, complementar, nde);

                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Excluir(int id)
        {
            ViewData["IdExcluir"] = id;

            return View();
        }

        public IActionResult ExcluirPlanoDeEnsino(int id)
        {
            new PlanoDeEnsinoModel().Excluir(id);

            return View();
        }
    }
}