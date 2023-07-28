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
    public class Detalle_del_pedidoController : Controller
    {
        private readonly AirShoesNic01Context _context;

        public Detalle_del_pedidoController(AirShoesNic01Context context)
        {
            _context = context;
        }

        // GET: Detalle_del_pedido
        public async Task<IActionResult> Index()
        {
            var airShoesNic01Context = _context.Detalle_del_pedido.Include(d => d.pedido);
            return View(await airShoesNic01Context.ToListAsync());
        }

        // GET: Detalle_del_pedido/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Detalle_del_pedido == null)
            {
                return NotFound();
            }

            var detalle_del_pedido = await _context.Detalle_del_pedido
                .Include(d => d.pedido)
                .FirstOrDefaultAsync(m => m.id == id);
            if (detalle_del_pedido == null)
            {
                return NotFound();
            }

            return View(detalle_del_pedido);
        }

        // GET: Detalle_del_pedido/Create
        public IActionResult Create()
        {
            ViewData["pedidoid"] = new SelectList(_context.Set<Pedido>(), "id", "id");
            return View();
        }

        // POST: Detalle_del_pedido/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Costo_unitario,Cantidad,Subtotal,pedidoid")] Detalle_del_pedido detalle_del_pedido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalle_del_pedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["pedidoid"] = new SelectList(_context.Set<Pedido>(), "id", "id", detalle_del_pedido.pedidoid);
            return View(detalle_del_pedido);
        }

        // GET: Detalle_del_pedido/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Detalle_del_pedido == null)
            {
                return NotFound();
            }

            var detalle_del_pedido = await _context.Detalle_del_pedido.FindAsync(id);
            if (detalle_del_pedido == null)
            {
                return NotFound();
            }
            ViewData["pedidoid"] = new SelectList(_context.Set<Pedido>(), "id", "id", detalle_del_pedido.pedidoid);
            return View(detalle_del_pedido);
        }

        // POST: Detalle_del_pedido/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Costo_unitario,Cantidad,Subtotal,pedidoid")] Detalle_del_pedido detalle_del_pedido)
        {
            if (id != detalle_del_pedido.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalle_del_pedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Detalle_del_pedidoExists(detalle_del_pedido.id))
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
            ViewData["pedidoid"] = new SelectList(_context.Set<Pedido>(), "id", "id", detalle_del_pedido.pedidoid);
            return View(detalle_del_pedido);
        }

        // GET: Detalle_del_pedido/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Detalle_del_pedido == null)
            {
                return NotFound();
            }

            var detalle_del_pedido = await _context.Detalle_del_pedido
                .Include(d => d.pedido)
                .FirstOrDefaultAsync(m => m.id == id);
            if (detalle_del_pedido == null)
            {
                return NotFound();
            }

            return View(detalle_del_pedido);
        }

        // POST: Detalle_del_pedido/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Detalle_del_pedido == null)
            {
                return Problem("Entity set 'AirShoesNic01Context.Detalle_del_pedido'  is null.");
            }
            var detalle_del_pedido = await _context.Detalle_del_pedido.FindAsync(id);
            if (detalle_del_pedido != null)
            {
                _context.Detalle_del_pedido.Remove(detalle_del_pedido);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Detalle_del_pedidoExists(int id)
        {
          return (_context.Detalle_del_pedido?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
