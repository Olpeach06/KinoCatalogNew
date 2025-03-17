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
    public class FilmsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FilmsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Films
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Film.Include(f => f.Actor).Include(f => f.Country).Include(f => f.Genre).Include(f => f.Studio);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Films/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film = await _context.Film
                .Include(f => f.Actor)
                .Include(f => f.Country)
                .Include(f => f.Genre)
                .Include(f => f.Studio)
                .FirstOrDefaultAsync(m => m.FilmID == id);
            if (film == null)
            {
                return NotFound();
            }

            return View(film);
        }

        // GET: Films/Create
        public IActionResult Create()
        {
            ViewData["ActorID"] = new SelectList(_context.Actor, "ActorID", "FirstName");
            ViewData["CountryID"] = new SelectList(_context.Country, "CountryID", "Name");
            ViewData["GenreID"] = new SelectList(_context.Set<Genre>(), "GenreID", "Name");
            ViewData["StudioID"] = new SelectList(_context.Set<ProductionStudio>(), "StudioID", "Name");
            return View();
        }

        // POST: Films/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FilmID,Title,Description,ReleaseYear,Duration,Rating,PosterURL,GenreID,CountryID,ActorID,StudioID")] Film film)
        {
            if (ModelState.IsValid)
            {
                _context.Add(film);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ActorID"] = new SelectList(_context.Actor, "ActorID", "FirstName", film.ActorID);
            ViewData["CountryID"] = new SelectList(_context.Country, "CountryID", "Name", film.CountryID);
            ViewData["GenreID"] = new SelectList(_context.Set<Genre>(), "GenreID", "Name", film.GenreID);
            ViewData["StudioID"] = new SelectList(_context.Set<ProductionStudio>(), "StudioID", "Name", film.StudioID);
            return View(film);
        }

        // GET: Films/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film = await _context.Film.FindAsync(id);
            if (film == null)
            {
                return NotFound();
            }
            ViewData["ActorID"] = new SelectList(_context.Actor, "ActorID", "FirstName", film.ActorID);
            ViewData["CountryID"] = new SelectList(_context.Country, "CountryID", "Name", film.CountryID);
            ViewData["GenreID"] = new SelectList(_context.Set<Genre>(), "GenreID", "Name", film.GenreID);
            ViewData["StudioID"] = new SelectList(_context.Set<ProductionStudio>(), "StudioID", "Name", film.StudioID);
            return View(film);
        }

        // POST: Films/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FilmID,Title,Description,ReleaseYear,Duration,Rating,PosterURL,GenreID,CountryID,ActorID,StudioID")] Film film)
        {
            if (id != film.FilmID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(film);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmExists(film.FilmID))
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
            ViewData["ActorID"] = new SelectList(_context.Actor, "ActorID", "FirstName", film.ActorID);
            ViewData["CountryID"] = new SelectList(_context.Country, "CountryID", "Name", film.CountryID);
            ViewData["GenreID"] = new SelectList(_context.Set<Genre>(), "GenreID", "Name", film.GenreID);
            ViewData["StudioID"] = new SelectList(_context.Set<ProductionStudio>(), "StudioID", "Name", film.StudioID);
            return View(film);
        }

        // GET: Films/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film = await _context.Film
                .Include(f => f.Actor)
                .Include(f => f.Country)
                .Include(f => f.Genre)
                .Include(f => f.Studio)
                .FirstOrDefaultAsync(m => m.FilmID == id);
            if (film == null)
            {
                return NotFound();
            }

            return View(film);
        }

        // POST: Films/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var film = await _context.Film.FindAsync(id);
            if (film != null)
            {
                _context.Film.Remove(film);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilmExists(int id)
        {
            return _context.Film.Any(e => e.FilmID == id);
        }
    }
}
