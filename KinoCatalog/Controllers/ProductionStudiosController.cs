using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KinoCatalog.Data;
using KinoCatalog.Models;

namespace KinoCatalog.Controllers
{
    public class ProductionStudiosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductionStudiosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProductionStudios
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProductionStudio.ToListAsync());
        }

        // GET: ProductionStudios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productionStudio = await _context.ProductionStudio
                .FirstOrDefaultAsync(m => m.StudioID == id);
            if (productionStudio == null)
            {
                return NotFound();
            }

            return View(productionStudio);
        }

        // GET: ProductionStudios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductionStudios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudioID,Name")] ProductionStudio productionStudio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productionStudio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productionStudio);
        }

        // GET: ProductionStudios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productionStudio = await _context.ProductionStudio.FindAsync(id);
            if (productionStudio == null)
            {
                return NotFound();
            }
            return View(productionStudio);
        }

        // POST: ProductionStudios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudioID,Name")] ProductionStudio productionStudio)
        {
            if (id != productionStudio.StudioID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productionStudio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductionStudioExists(productionStudio.StudioID))
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
            return View(productionStudio);
        }

        // GET: ProductionStudios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productionStudio = await _context.ProductionStudio
                .FirstOrDefaultAsync(m => m.StudioID == id);
            if (productionStudio == null)
            {
                return NotFound();
            }

            return View(productionStudio);
        }

        // POST: ProductionStudios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productionStudio = await _context.ProductionStudio.FindAsync(id);
            if (productionStudio != null)
            {
                _context.ProductionStudio.Remove(productionStudio);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductionStudioExists(int id)
        {
            return _context.ProductionStudio.Any(e => e.StudioID == id);
        }
    }
}
