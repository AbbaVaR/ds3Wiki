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
    public class NPC_locationController : Controller
    {
        private readonly MainContext _context;

        public NPC_locationController(MainContext context)
        {
            _context = context;
        }

        // GET: NPC_location
        public async Task<IActionResult> Index()
        {
            var mainContext = _context.NPC_Locations.Include(n => n.Character).Include(n => n.Enemy).Include(n => n.Location);
            return View(await mainContext.ToListAsync());
        }

        // GET: NPC_location/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nPC_location = await _context.NPC_Locations
                .Include(n => n.Character)
                .Include(n => n.Enemy)
                .Include(n => n.Location)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nPC_location == null)
            {
                return NotFound();
            }

            return View(nPC_location);
        }

        // GET: NPC_location/Create
        [Authorize(Roles = "admin , moderator")]
        public IActionResult Create()
        {
            ViewData["CharacterId"] = new SelectList(_context.Characters, "Id", "Id");
            ViewData["EnemyId"] = new SelectList(_context.Enemies, "Id", "Id");
            ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Id");
            return View();
        }

        // POST: NPC_location/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin , moderator")]
        public async Task<IActionResult> Create([Bind("Id,LocationId,EnemyId,CharacterId")] NPC_location nPC_location)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nPC_location);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CharacterId"] = new SelectList(_context.Characters, "Id", "Id", nPC_location.CharacterId);
            ViewData["EnemyId"] = new SelectList(_context.Enemies, "Id", "Id", nPC_location.EnemyId);
            ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Id", nPC_location.LocationId);
            return View(nPC_location);
        }

        // GET: NPC_location/Edit/5
        [Authorize(Roles = "admin , moderator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nPC_location = await _context.NPC_Locations.FindAsync(id);
            if (nPC_location == null)
            {
                return NotFound();
            }
            ViewData["CharacterId"] = new SelectList(_context.Characters, "Id", "Id", nPC_location.CharacterId);
            ViewData["EnemyId"] = new SelectList(_context.Enemies, "Id", "Id", nPC_location.EnemyId);
            ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Id", nPC_location.LocationId);
            return View(nPC_location);
        }

        // POST: NPC_location/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin , moderator")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LocationId,EnemyId,CharacterId")] NPC_location nPC_location)
        {
            if (id != nPC_location.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nPC_location);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NPC_locationExists(nPC_location.Id))
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
            ViewData["CharacterId"] = new SelectList(_context.Characters, "Id", "Id", nPC_location.CharacterId);
            ViewData["EnemyId"] = new SelectList(_context.Enemies, "Id", "Id", nPC_location.EnemyId);
            ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Id", nPC_location.LocationId);
            return View(nPC_location);
        }

        // GET: NPC_location/Delete/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nPC_location = await _context.NPC_Locations
                .Include(n => n.Character)
                .Include(n => n.Enemy)
                .Include(n => n.Location)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nPC_location == null)
            {
                return NotFound();
            }

            return View(nPC_location);
        }

        // POST: NPC_location/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nPC_location = await _context.NPC_Locations.FindAsync(id);
            _context.NPC_Locations.Remove(nPC_location);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NPC_locationExists(int id)
        {
            return _context.NPC_Locations.Any(e => e.Id == id);
        }
    }
}
