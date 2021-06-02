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
    public class _MarcasController : Controller
    {
        // GET: MarcasController
        public ActionResult Index()
        {

            return View(BaseDatos.Marcas);
        }

        // GET: MarcasController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MarcasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MarcasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Marca modelo)
        {
            try
            {
                //Me faltaria el id!
                BaseDatos.Marcas.Add(modelo);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MarcasController/Edit/5
        public ActionResult Edit(int id)
        {
            var modeloAEditar = BaseDatos.Marcas.FirstOrDefault(o => o.Id == id);
            return View(modeloAEditar);
        }

        // POST: MarcasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Marca marca)
        {
            try
            {
                var modeloAEditar = BaseDatos.Marcas.FirstOrDefault(o => o.Id == marca.Id);
                modeloAEditar.Descripcion = marca.Descripcion;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MarcasController/Delete/5
        public ActionResult Delete(int id)
        {
            var modeloAEditar = BaseDatos.Marcas.FirstOrDefault(o => o.Id == id);
            BaseDatos.Marcas.Remove(modeloAEditar);
            return View();
        }

        // POST: MarcasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
