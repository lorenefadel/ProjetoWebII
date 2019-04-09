using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sistema.Models;

namespace Sistema.Controllers
{
    public class GeralController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult ListaObjetivo()
        {

            ViewBag.ListaObjetivos = new ObjetivoModel().ListarObjetivos();

            return View();
        }

        [HttpGet]
        public IActionResult CadastroObjetivo(int? id)
        {
            ViewBag.ListaDisciplinas = new CompetenciaModel().GetDisciplinas().Select(c => new SelectListItem() { Text = c.Descricao, Value = c.Id.ToString() }).ToList();

            if (id != null)
            {
                //Carregar registro do objetivo em ViewBag
                ViewBag.Objetivo = new ObjetivoModel().RetornarObjetivo(id);
            }
            return View();
        }

        [HttpPost]
        public IActionResult CadastroObjetivo(ObjetivoModel objetivo)
        {
            if (ModelState.IsValid)
            {
                objetivo.Gravar();
                return RedirectToAction("ListaObjetivo");
            }
            return View();
        }

        public IActionResult ExcluirObjt(int id)
        {
            ViewData["IdExcluir"] = id;

            return View();
        }

        public IActionResult ExcluirObjetivo(int id)
        {
            new ObjetivoModel().Excluir(id);
            return View();
        }

        public IActionResult ListaDisciplina()
        {

            ViewBag.ListaDisciplinas = new DisciplinaModel().ListarDisciplinas();

            return View();
        }

        [HttpGet]
        public IActionResult CadastroDisciplina(int? id)
        {
            ViewBag.ListaProfessores = new DisciplinaModel().GetProfessores().Select(c => new SelectListItem() { Text = c.Nome, Value = c.Id.ToString() }).ToList();
            ViewBag.ListaCursos = new DisciplinaModel().GetCursos().Select(c => new SelectListItem() { Text = c.Descricao, Value = c.Id.ToString() }).ToList();
            ViewBag.ListaTurmas = new DisciplinaModel().GetTurmas().Select(c => new SelectListItem() { Text = c.Codigo, Value = c.Id.ToString() }).ToList();

            if (id != null)
            {
                //Carregar registro de disciplinas em ViewBag
                ViewBag.Disciplina = new DisciplinaModel().RetornarDisciplina(id);
            }
            return View();
        }

        [HttpPost]
        public IActionResult CadastroDisciplina(DisciplinaModel disciplina)
        {
            if (ModelState.IsValid)
            {
                disciplina.Gravar();
                return RedirectToAction("ListaDisciplina");
            }
            return View();
        }

        public IActionResult ExcluirDisp(int id)
        {
            ViewData["IdExcluir"] = id;

            return View();
        }

        public IActionResult ExcluirDisciplina(int id)
        {
            new DisciplinaModel().Excluir(id);
            return View();
        }

        public IActionResult ListaHabilidade()
        {

            ViewBag.ListaHabilidades = new HabilidadeModel().ListarHabilidades();

            return View();
        }

        [HttpGet]
        public IActionResult CadastroHabilidade(int? id)
        {
            ViewBag.ListaDisciplinas = new CompetenciaModel().GetDisciplinas().Select(c => new SelectListItem() { Text = c.Descricao, Value = c.Id.ToString() }).ToList();

            if (id != null)
            {
                //Carregar registro de habilidades em ViewBag
                ViewBag.Habilidade = new HabilidadeModel().RetornarHabilidade(id);
            }
            return View();
        }

        [HttpPost]
        public IActionResult CadastroHabilidade(HabilidadeModel habilidade)
        {
            if (ModelState.IsValid)
            {
                habilidade.Gravar();
                return RedirectToAction("ListaHabilidade");
            }
            return View();
        }

        public IActionResult ExcluirHabi(int id)
        {
            ViewData["IdExcluir"] = id;

            return View();
        }

        public IActionResult ExcluirHabilidade(int id)
        {
            new HabilidadeModel().Excluir(id);
            return View();
        }

        public IActionResult ListaTurma()
        {

            ViewBag.ListaTurmas = new TurmaModel().ListarTurmas();

            return View();
        }

        [HttpGet]
        public IActionResult CadastroTurma(int? id)
        {
            if (id != null)
            {
                //Carregar registro de turmas em ViewBag
                ViewBag.Turma = new TurmaModel().RetornarTurma(id);
            }
            return View();
        }

        [HttpPost]
        public IActionResult CadastroTurma(TurmaModel turma)
        {
            if (ModelState.IsValid)
            {
                turma.Gravar();
                return RedirectToAction("ListaTurma");
            }
            return View();
        }

        public IActionResult ExcluirTurm(int id)
        {
            ViewData["IdExcluir"] = id;

            return View();
        }

        public IActionResult ExcluirTurma(int id)
        {
            new TurmaModel().Excluir(id);
            return View();
        }
        public IActionResult ListaCompetencia()
        {

            ViewBag.ListaCompetencias = new CompetenciaModel().ListarCompetencias();

            return View();
        }

        [HttpGet]
        public IActionResult CadastroCompetencia(int? id)
        {
            ViewBag.ListaDisciplinas = new CompetenciaModel().GetDisciplinas().Select(c => new SelectListItem() { Text = c.Descricao, Value = c.Id.ToString() }).ToList();
            if (id != null)
            {
                //Carregar registro de competencias em ViewBag
                ViewBag.Competencia = new CompetenciaModel().RetornarCompetencia(id);
            }
            return View();
        }

        [HttpPost]
        public IActionResult CadastroCompetencia(CompetenciaModel competencia)
        {
            if (ModelState.IsValid)
            {
                competencia.Gravar();
                return RedirectToAction("ListaCompetencia");
            }
            return View();
        }

        public IActionResult ExcluirComp(int id)
        {
            ViewData["IdExcluir"] = id;

            return View();
        }

        public IActionResult ExcluirCompetencia(int id)
        {
            new CompetenciaModel().Excluir(id);
            return View();
        }

        public IActionResult ListaCurso()
        {

            ViewBag.ListaCursos = new CursoModel().ListarCursos();

            return View();
        }

        [HttpGet]
        public IActionResult CadastroCurso(int? id)
        {
            ViewBag.ListaCoordenadores = new CursoModel().GetCoordenadores().Select(c => new SelectListItem() { Text = c.Nome, Value = c.Id.ToString() }).ToList();

            if (id != null)
            {
                //Carregar registro de cursos em ViewBag
                ViewBag.Curso = new CursoModel().RetornarCurso(id);
            }
            return View();
        }

        [HttpPost]
        public IActionResult CadastroCurso(CursoModel curso)
        {
            if (ModelState.IsValid)
            {
                curso.Gravar();
                return RedirectToAction("ListaCurso");
            }
            return View();
        }

        public IActionResult ExcluirCurs(int id)
        {
            ViewData["IdExcluir"] = id;

            return View();
        }

        public IActionResult ExcluirCurso(int id)
        {
            new CursoModel().Excluir(id);
            return View();
        }
    }
}
