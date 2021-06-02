using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AudioStock.Models;

namespace AudioStock.Controllers
{
    public class EquipoesController : Controller
    {
        private readonly AudioStockContext _context;

        public EquipoesController(AudioStockContext context)
        {
            _context = context;
        }

        // GET: Equipoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Equipos.ToListAsync());
        }

        // GET: Equipoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipo = await _context.Equipos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (equipo == null)
            {
                return NotFound();
            }

            return View(equipo);
        }

        // GET: Equipoes/Create
        public IActionResult Create()
        {
            this.CompletarViewBag(new Equipo());
            return View();
        }

        // POST: Equipoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Modelo,SacNumero,Fecha,Estado,Observacion")] Equipo equipo)
        public async Task<IActionResult> Create(Equipo equipo)
        {
            if (ModelState.IsValid)
            {
                equipo.Marca = _context.Marcas.FirstOrDefault(o=>o.Id == equipo.IdMarcaSeleccionada);
                equipo.TipoEquipo = _context.TiposEquipos.FirstOrDefault(o => o.Id == equipo.IdTipoEquipoSeleccionado);
                _context.Add(equipo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            this.CompletarViewBag(equipo);
            return View(equipo);
        }

        // GET: Equipoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            var equipo = await _context.Equipos.FindAsync(id);

            this.CompletarViewBag(equipo);


            if (equipo == null)
            {
                return NotFound();
            }
            return View(equipo);
        }

        public void CompletarViewBag(Equipo equipo)

        {
            ViewBag.TipoEquipos = _context.TiposEquipos.ToList();
            ViewBag.Marcas = _context.Marcas.ToList();
            if (equipo.Marca != null)
                equipo.IdMarcaSeleccionada = equipo.Marca.Id;

            if (equipo.TipoEquipo != null)
                equipo.IdTipoEquipoSeleccionado = equipo.TipoEquipo.Id;
        }

        // POST: Equipoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Equipo equipo)
        {
            if (equipo.Id != equipo.Id)
            {
                return NotFound();
            }

            equipo.Marca = _context.Marcas.FirstOrDefault(o => o.Id == equipo.IdMarcaSeleccionada);
            equipo.TipoEquipo = _context.TiposEquipos.FirstOrDefault(o => o.Id == equipo.IdTipoEquipoSeleccionado);

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipoExists(equipo.Id))
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
            return View(equipo);
        }

        // GET: Equipoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipo = await _context.Equipos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (equipo == null)
            {
                return NotFound();
            }

            return View(equipo);
        }

        // POST: Equipoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var equipo = await _context.Equipos.FindAsync(id);
            _context.Equipos.Remove(equipo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EquipoExists(int id)
        {
            return _context.Equipos.Any(e => e.Id == id);
        }
    }
}
