﻿using AudioStock.AD;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudioStock.Controllers
{
    public class MarcasController : Controller
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
        public ActionResult Create(IFormCollection collection)
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

        // GET: MarcasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MarcasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: MarcasController/Delete/5
        public ActionResult Delete(int id)
        {
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
