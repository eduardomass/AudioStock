using AudioStock.AD;
using AudioStock.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudioStock.Controllers
{
    public class UserController : Controller
    {
        
        [HttpGet]
        public IActionResult Index()
        {
            AudioStockContext audio = new AudioStockContext();
            audio.Usuarios.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Index(Usuario usuario)
        {
            bool encontro = false;
            foreach (Usuario usuario2 in BaseDatos.Usuarios)
            {
                if (usuario2.Password == usuario.Password &&
                    usuario2.NombreUsuario == usuario.NombreUsuario)
                {
                    encontro = true;
                    break;
                }
            }

            //if (usuario.NombreUsuario == "a@a.com")
            if (encontro)
            {
                ViewBag.Mensaje = "Usuario Correcto";
                //return View();
                return RedirectToAction("Index", "General");
            }
            else
            {
                ViewBag.Mensaje = "Usuario Incorrecto";
                return View("Index");
            }

        }

        //public IActionResult Login(Usuario usuario)
        //{
        //    if (usuario.NombreUsuario == "a@a.com")
        //    {
        //        return View();
        //    }
        //    else
        //    {
        //        return View("Index");
        //    }

        //}
    }
}
