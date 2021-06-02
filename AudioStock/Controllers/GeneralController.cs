using AudioStock.AD;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudioStock.Controllers
{
    public class GeneralController : Controller
    {
        public IActionResult Index()
        {

            return View(BaseDatos.Equipos);
        }
    }
}
