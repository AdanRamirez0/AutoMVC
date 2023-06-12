using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gen06_23ProyectoAutomovil.Models;

namespace Gen06_23ProyectoAutomovil.Controllers
{
    public class AutomovilsController : Controller
    {
        private readonly Gen06_23ProyectoAutoMVCContext _context;

        public AutomovilsController(Gen06_23ProyectoAutoMVCContext context)
        {
            _context = context;
        }

        // GET: Automovils
        public async Task<IActionResult> Index()
        {
            var gen06_23ProyectoAutoMVCContext = _context.Automovils.Include(a => a.EstatusAutomovil);
            return View(await gen06_23ProyectoAutoMVCContext.ToListAsync());
        }

        // GET: Automovils/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Automovils == null)
            {
                return NotFound();
            }

            var automovil = await _context.Automovils
                .Include(a => a.EstatusAutomovil)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (automovil == null)
            {
                return NotFound();
            }

            return View(automovil);
        }

        // GET: Automovils/Create
        public IActionResult Create()
        {
            ViewData["EstatusAutomovilId"] = new SelectList(_context.EstatusAutomovils, "Id", "Descripcion");
            return View();
        }

        // POST: Automovils/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Marca,Modelo,Color,CostoPorDia,EstatusAutomovilId")] Automovil automovil)
        {
            if (ModelState.IsValid)
            {
                _context.Add(automovil);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EstatusAutomovilId"] = new SelectList(_context.EstatusAutomovils, "Id", "Descripcion", automovil.EstatusAutomovilId);
            return View(automovil);
        }

        // GET: Automovils/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Automovils == null)
            {
                return NotFound();
            }

            var automovil = await _context.Automovils.FindAsync(id);
            if (automovil == null)
            {
                return NotFound();
            }
            ViewData["EstatusAutomovilId"] = new SelectList(_context.EstatusAutomovils, "Id", "Descripcion", automovil.EstatusAutomovilId);
            return View(automovil);
        }

        // POST: Automovils/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Marca,Modelo,Color,CostoPorDia,EstatusAutomovilId")] Automovil automovil)
        {
            if (id != automovil.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(automovil);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutomovilExists(automovil.Id))
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
            ViewData["EstatusAutomovilId"] = new SelectList(_context.EstatusAutomovils, "Id", "Descripcion", automovil.EstatusAutomovilId);
            return View(automovil);
        }

        // GET: Automovils/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Automovils == null)
            {
                return NotFound();
            }

            var automovil = await _context.Automovils
                .Include(a => a.EstatusAutomovil)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (automovil == null)
            {
                return NotFound();
            }

            return View(automovil);
        }

        // POST: Automovils/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Automovils == null)
            {
                return Problem("Entity set 'Gen06_23ProyectoAutoMVCContext.Automovils'  is null.");
            }
            var automovil = await _context.Automovils.FindAsync(id);
            if (automovil != null)
            {
                _context.Automovils.Remove(automovil);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutomovilExists(int id)
        {
          return _context.Automovils.Any(e => e.Id == id);
        }
    }
}
