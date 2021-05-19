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
            BaseDatos.IniciarUsuario();
            return View();
        }

        [HttpPost]
        public IActionResult Index(Usuario usuario)
        {
            bool encontro = false;
            foreach (Usuario usuario2 in BaseDatos.ListaUsuarios)
            {
                if (usuario2.Password == usuario.NombreUsuario &&
                    usuario2.NombreUsuario == usuario.Password)
                {
                    encontro = true;
                    break;
                }
            }

            //if (usuario.NombreUsuario == "a@a.com")
            if (encontro)
            {
                ViewBag.Mensaje = "Usuario Correcto";
                return View();
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
