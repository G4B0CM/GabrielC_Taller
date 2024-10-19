using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GabrielC_Taller.Data;
using GabrielC_Taller.Models;

namespace GabrielC_Taller.Controllers
{
    public class JugadorController : Controller
    {
        private readonly GabrielC_TallerContext _context;

        public JugadorController(GabrielC_TallerContext context)
        {
            _context = context;
        }

        // GET: Jugador
        public async Task<IActionResult> Index(int? EquipoId)
        {
            ViewBag.IDEquipo = new SelectList(await _context.Equipo.ToListAsync(), "Id", "Nombre");
            var jugadores = _context.Jugador.ToListAsync();
            if(EquipoId != 0)
            {
                var jugadoresDeUnEquipo = _context.Jugador.Where(j => j.IDEquipo.Equals(EquipoId));
                return View(await jugadoresDeUnEquipo.ToListAsync());
            }
            else
                return View(await jugadores);


        }

        // GET: Jugador/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jugador = await _context.Jugador
                .Include(j => j.Equipo)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (jugador == null)
            {
                return NotFound();
            }

            return View(jugador);
        }

        // GET: Jugador/Create
        public IActionResult Create()
        {
            // Obtener la lista de equipos para el dropdown
            ViewData["IDEquipo"] = new SelectList(_context.Equipo, "Id", "Nombre");
            return View();
        }

        // POST: Jugador/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nombre,Posicion,Edad,IDEquipo")] Jugador jugador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jugador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            // Reobtenemos la lista de equipos si hay errores
            ViewData["IDEquipo"] = new SelectList(_context.Equipo, "Id", "Nombre", jugador.IDEquipo);
            return View(jugador);
        }

        // GET: Jugador/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jugador = await _context.Jugador.FindAsync(id);
            if (jugador == null)
            {
                return NotFound();
            }
            // Obtener la lista de equipos para el dropdown
            ViewData["IDEquipo"] = new SelectList(_context.Equipo, "Id", "Nombre", jugador.IDEquipo);
            return View(jugador);
        }

        // POST: Jugador/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nombre,Posicion,Edad,IDEquipo")] Jugador jugador)
        {
            if (id != jugador.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jugador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JugadorExists(jugador.ID))
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
            // Reobtenemos la lista de equipos si hay errores
            ViewData["IDEquipo"] = new SelectList(_context.Equipo, "Id", "Nombre", jugador.IDEquipo);
            return View(jugador);
        }

        // GET: Jugador/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jugador = await _context.Jugador
                .Include(j => j.Equipo)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (jugador == null)
            {
                return NotFound();
            }

            return View(jugador);
        }

        // POST: Jugador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jugador = await _context.Jugador.FindAsync(id);
            if (jugador != null)
            {
                _context.Jugador.Remove(jugador);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JugadorExists(int id)
        {
            return _context.Jugador.Any(e => e.ID == id);
        }
    }
}
