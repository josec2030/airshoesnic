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
    public class Carrito_de_comprasController : Controller
    {
        private readonly AirShoesNic01Context _context;

        public Carrito_de_comprasController(AirShoesNic01Context context)
        {
            _context = context;
        }

        // GET: Carrito_de_compras
        public async Task<IActionResult> Index()
        {
              return _context.Carrito_de_compras != null ? 
                          View(await _context.Carrito_de_compras.ToListAsync()) :
                          Problem("Entity set 'AirShoesNic01Context.Carrito_de_compras'  is null.");
        }

        // GET: Carrito_de_compras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Carrito_de_compras == null)
            {
                return NotFound();
            }

            var carrito_de_compras = await _context.Carrito_de_compras
                .FirstOrDefaultAsync(m => m.id == id);
            if (carrito_de_compras == null)
            {
                return NotFound();
            }

            return View(carrito_de_compras);
        }

        // GET: Carrito_de_compras/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Carrito_de_compras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Fecha_de_entrega,Direccion,Cantidad,Clienteid")] Carrito_de_compras carrito_de_compras)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carrito_de_compras);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carrito_de_compras);
        }

        // GET: Carrito_de_compras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Carrito_de_compras == null)
            {
                return NotFound();
            }

            var carrito_de_compras = await _context.Carrito_de_compras.FindAsync(id);
            if (carrito_de_compras == null)
            {
                return NotFound();
            }
            return View(carrito_de_compras);
        }

        // POST: Carrito_de_compras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Fecha_de_entrega,Direccion,Cantidad,Clienteid")] Carrito_de_compras carrito_de_compras)
        {
            if (id != carrito_de_compras.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carrito_de_compras);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Carrito_de_comprasExists(carrito_de_compras.id))
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
            return View(carrito_de_compras);
        }

        // GET: Carrito_de_compras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Carrito_de_compras == null)
            {
                return NotFound();
            }

            var carrito_de_compras = await _context.Carrito_de_compras
                .FirstOrDefaultAsync(m => m.id == id);
            if (carrito_de_compras == null)
            {
                return NotFound();
            }

            return View(carrito_de_compras);
        }

        // POST: Carrito_de_compras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Carrito_de_compras == null)
            {
                return Problem("Entity set 'AirShoesNic01Context.Carrito_de_compras'  is null.");
            }
            var carrito_de_compras = await _context.Carrito_de_compras.FindAsync(id);
            if (carrito_de_compras != null)
            {
                _context.Carrito_de_compras.Remove(carrito_de_compras);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Carrito_de_comprasExists(int id)
        {
          return (_context.Carrito_de_compras?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
