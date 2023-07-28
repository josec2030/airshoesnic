using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AirShoesNic01.Data;
using AirShoesNic01.Models;

namespace AirShoesNic01.Controllers
{
    public class Informacion_del_envioController : Controller
    {
        private readonly AirShoesNic01Context _context;

        public Informacion_del_envioController(AirShoesNic01Context context)
        {
            _context = context;
        }

        // GET: Informacion_del_envio
        public async Task<IActionResult> Index()
        {
            var airShoesNic01Context = _context.Informacion_del_envio.Include(i => i.Pedido);
            return View(await airShoesNic01Context.ToListAsync());
        }

        // GET: Informacion_del_envio/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Informacion_del_envio == null)
            {
                return NotFound();
            }

            var informacion_del_envio = await _context.Informacion_del_envio
                .Include(i => i.Pedido)
                .FirstOrDefaultAsync(m => m.id == id);
            if (informacion_del_envio == null)
            {
                return NotFound();
            }

            return View(informacion_del_envio);
        }

        // GET: Informacion_del_envio/Create
        public IActionResult Create()
        {
            ViewData["Pedidoid"] = new SelectList(_context.Set<Pedido>(), "id", "id");
            return View();
        }

        // POST: Informacion_del_envio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Tipo_de_Envio,Estado_de_envio,Pedidoid")] Informacion_del_envio informacion_del_envio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(informacion_del_envio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Pedidoid"] = new SelectList(_context.Set<Pedido>(), "id", "id", informacion_del_envio.Pedidoid);
            return View(informacion_del_envio);
        }

        // GET: Informacion_del_envio/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Informacion_del_envio == null)
            {
                return NotFound();
            }

            var informacion_del_envio = await _context.Informacion_del_envio.FindAsync(id);
            if (informacion_del_envio == null)
            {
                return NotFound();
            }
            ViewData["Pedidoid"] = new SelectList(_context.Set<Pedido>(), "id", "id", informacion_del_envio.Pedidoid);
            return View(informacion_del_envio);
        }

        // POST: Informacion_del_envio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Tipo_de_Envio,Estado_de_envio,Pedidoid")] Informacion_del_envio informacion_del_envio)
        {
            if (id != informacion_del_envio.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(informacion_del_envio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Informacion_del_envioExists(informacion_del_envio.id))
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
            ViewData["Pedidoid"] = new SelectList(_context.Set<Pedido>(), "id", "id", informacion_del_envio.Pedidoid);
            return View(informacion_del_envio);
        }

        // GET: Informacion_del_envio/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Informacion_del_envio == null)
            {
                return NotFound();
            }

            var informacion_del_envio = await _context.Informacion_del_envio
                .Include(i => i.Pedido)
                .FirstOrDefaultAsync(m => m.id == id);
            if (informacion_del_envio == null)
            {
                return NotFound();
            }

            return View(informacion_del_envio);
        }

        // POST: Informacion_del_envio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Informacion_del_envio == null)
            {
                return Problem("Entity set 'AirShoesNic01Context.Informacion_del_envio'  is null.");
            }
            var informacion_del_envio = await _context.Informacion_del_envio.FindAsync(id);
            if (informacion_del_envio != null)
            {
                _context.Informacion_del_envio.Remove(informacion_del_envio);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Informacion_del_envioExists(int id)
        {
          return (_context.Informacion_del_envio?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
