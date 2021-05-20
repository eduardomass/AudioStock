using AudioStock.AD;
using AudioStock.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudioStock.Controllers
{
    public class TipoEquipoController : Controller
    {
        // GET: TipoEquipoController
        public ActionResult Index()
        {
            return View(BaseDatos.TiposEquipos);
        }

        
        // GET: TipoEquipoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoEquipoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipoEquipo modelo)
        {
            try
            {
                BaseDatos.TiposEquipos.Add(modelo);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TipoEquipoController/Edit/5
        public ActionResult Edit(int id)
        {
            foreach (TipoEquipo item in BaseDatos.TiposEquipos)
            {
                if (item.Id == id)
                {
                    return View(item);
                }
            }
            //var modelo = BaseDatos.TiposEquipos.FirstOrDefault(o => o.Id == id);
            return RedirectToAction(nameof(Create));
        }

        // POST: TipoEquipoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TipoEquipo modelo)
        {
            try
            {
                foreach (TipoEquipo item in BaseDatos.TiposEquipos)
                {
                    if (item.Id == modelo.Id)
                    {
                        item.Descripcion = modelo.Descripcion;
                        item.Observaciones = modelo.Observaciones;
                        break;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TipoEquipoController/Delete/5
        public ActionResult Delete(int id)
        {
            foreach (TipoEquipo item in BaseDatos.TiposEquipos)
            {
                if (item.Id == id)
                {
                    return View(item);
                }
            }
            return View();
        }

        // POST: TipoEquipoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                BaseDatos.TiposEquipos.Remove(
                    BaseDatos.Buscar(id));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
