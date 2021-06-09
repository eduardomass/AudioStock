﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AudioStock.Models;

namespace AudioStock.Controllers
{
    public class TipoEquipoesController : Controller
    {
        private readonly AudioStockContext _context;

        public TipoEquipoesController(AudioStockContext context)
        {
            _context = context;
        }

        // GET: TipoEquipoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoEquipos.ToListAsync());
        }

        // GET: TipoEquipoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoEquipo = await _context.TipoEquipos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoEquipo == null)
            {
                return NotFound();
            }

            return View(tipoEquipo);
        }

        // GET: TipoEquipoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoEquipoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion,Observaciones")] TipoEquipo tipoEquipo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoEquipo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoEquipo);
        }

        // GET: TipoEquipoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoEquipo = await _context.TipoEquipos.FindAsync(id);
            if (tipoEquipo == null)
            {
                return NotFound();
            }
            return View(tipoEquipo);
        }

        // POST: TipoEquipoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion,Observaciones")] TipoEquipo tipoEquipo)
        {
            if (id != tipoEquipo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoEquipo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoEquipoExists(tipoEquipo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tipoEquipo);
        }

        // GET: TipoEquipoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoEquipo = await _context.TipoEquipos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoEquipo == null)
            {
                return NotFound();
            }

            return View(tipoEquipo);
        }

        // POST: TipoEquipoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoEquipo = await _context.TipoEquipos.FindAsync(id);
            _context.TipoEquipos.Remove(tipoEquipo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoEquipoExists(int id)
        {
            return _context.TipoEquipos.Any(e => e.Id == id);
        }
    }
}
