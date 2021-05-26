using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ds3Wiki.Models;
using Microsoft.AspNetCore.Authorization;

namespace ds3Wiki.Controllers
{
    [Authorize]
    public class Gem_LocationController : Controller
    {
        private readonly MainContext _context;

        public Gem_LocationController(MainContext context)
        {
            _context = context;
        }

        // GET: Gem_Location
        public async Task<IActionResult> Index()
        {
            var mainContext = _context.Gem_Locations.Include(g => g.Improvement_path).Include(g => g.Location);
            return View(await mainContext.ToListAsync());
        }

        // GET: Gem_Location/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gem_Location = await _context.Gem_Locations
                .Include(g => g.Improvement_path)
                .Include(g => g.Location)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gem_Location == null)
            {
                return NotFound();
            }

            return View(gem_Location);
        }

        // GET: Gem_Location/Create
        [Authorize(Roles = "admin , moderator")]
        public IActionResult Create()
        {
            ViewData["Improvement_pathId"] = new SelectList(_context.Improvement_Paths, "Id", "Id");
            ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Id");
            return View();
        }

        // POST: Gem_Location/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin , moderator")]
        public async Task<IActionResult> Create([Bind("Id,Improvement_pathId,LocationId")] Gem_Location gem_Location)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gem_Location);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Improvement_pathId"] = new SelectList(_context.Improvement_Paths, "Id", "Id", gem_Location.Improvement_pathId);
            ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Id", gem_Location.LocationId);
            return View(gem_Location);
        }

        // GET: Gem_Location/Edit/5
        [Authorize(Roles = "admin , moderator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gem_Location = await _context.Gem_Locations.FindAsync(id);
            if (gem_Location == null)
            {
                return NotFound();
            }
            ViewData["Improvement_pathId"] = new SelectList(_context.Improvement_Paths, "Id", "Id", gem_Location.Improvement_pathId);
            ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Id", gem_Location.LocationId);
            return View(gem_Location);
        }

        // POST: Gem_Location/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin , moderator")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Improvement_pathId,LocationId")] Gem_Location gem_Location)
        {
            if (id != gem_Location.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gem_Location);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Gem_LocationExists(gem_Location.Id))
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
            ViewData["Improvement_pathId"] = new SelectList(_context.Improvement_Paths, "Id", "Id", gem_Location.Improvement_pathId);
            ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Id", gem_Location.LocationId);
            return View(gem_Location);
        }

        // GET: Gem_Location/Delete/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gem_Location = await _context.Gem_Locations
                .Include(g => g.Improvement_path)
                .Include(g => g.Location)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gem_Location == null)
            {
                return NotFound();
            }

            return View(gem_Location);
        }

        // POST: Gem_Location/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gem_Location = await _context.Gem_Locations.FindAsync(id);
            _context.Gem_Locations.Remove(gem_Location);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Gem_LocationExists(int id)
        {
            return _context.Gem_Locations.Any(e => e.Id == id);
        }
    }
}
