using AudioStock.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AudioStock.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(Usuario usuario)
        {
            return View(usuario);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult IndexDos(string nombre, int? edad)
        {
            ViewBag.NombreUsuario = nombre;
            ViewBag.Edad = edad.Value;
            return View("IndexDos");
        }


        public IActionResult IndexTres()
        {
            //Usuario usuario = new Usuario();
            //usuario.NombreUsuario = "No necesito el GET, lo hace solo ! wala!";

            //return View("Index", usuario);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
