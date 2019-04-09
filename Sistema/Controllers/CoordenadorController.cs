using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sistema.Models;

namespace Sistema.Controllers
{
    public class CoordenadorController : Controller
    {
        public IActionResult Index()
        {

            ViewBag.ListaCoordenadores = new CoordenadorModel().ListarCoordenadores();

            return View();
        }

        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            if (id != null)
            {
                //Carregar registro do coordenador em ViewBag
                ViewBag.Coordenador = new CoordenadorModel().RetornarCoordenador(id);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(CoordenadorModel coordenador)
        {
            if (ModelState.IsValid)
            {
                coordenador.Gravar();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Excluir(int id)
        {
            ViewData["IdExcluir"] = id;

            return View();
        }

        public IActionResult ExcluirCoordenador(int id)
        {
            new CoordenadorModel().Excluir(id);
            return View();
        }
    }
}