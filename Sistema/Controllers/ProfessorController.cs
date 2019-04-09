using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sistema.Models;

namespace Sistema.Controllers
{
    public class ProfessorController : Controller
    {
        public IActionResult Index()
        {

            ViewBag.ListaProfessores = new ProfessorModel().ListarProfessores();

            return View();
        }

        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            if (id != null)
            {
                //Carregar registro do professor em ViewBag
                ViewBag.Professor = new ProfessorModel().RetornarProfessor(id);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(ProfessorModel professor)
        {
            if (ModelState.IsValid)
            {
                professor.Gravar();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Excluir(int id)
        {
            ViewData["IdExcluir"] = id;

            return View();
        }

        public IActionResult ExcluirProfessor(int id)
        {
            new ProfessorModel().Excluir(id);
            return View();
        }
    }
}