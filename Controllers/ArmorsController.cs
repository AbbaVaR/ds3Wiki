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
    public class ArmorsController : Controller
    {
        private readonly MainContext _context;

        public ArmorsController(MainContext context)
        {
            _context = context;
        }

        // GET: Armors
        public async Task<IActionResult> Index()
        {
            var mainContext = _context.Armors.Include(a => a.Character).Include(a => a.Location);
            return View(await mainContext.ToListAsync());
        }

        // GET: Armors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var armor = await _context.Armors
                .Include(a => a.Character)
                .Include(a => a.Location)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (armor == null)
            {
                return NotFound();
            }

            return View(armor);
        }

        // GET: Armors/Create
        [Authorize(Roles = "admin , moderator")]
        public IActionResult Create()
        {
            ViewData["CharacterId"] = new SelectList(_context.Characters, "Id", "Id");
            ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Id");
            return View();
        }

        // POST: Armors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin , moderator")]
        public async Task<IActionResult> Create([Bind("Id,Title,Physical_protection,Fire_protection,Lightning_protection,Magic_protection,LocationId,CharacterId")] Armor armor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(armor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CharacterId"] = new SelectList(_context.Characters, "Id", "Id", armor.CharacterId);
            ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Id", armor.LocationId);
            return View(armor);
        }

        // GET: Armors/Edit/5
        [Authorize(Roles = "admin , moderator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var armor = await _context.Armors.FindAsync(id);
            if (armor == null)
            {
                return NotFound();
            }
            ViewData["CharacterId"] = new SelectList(_context.Characters, "Id", "Id", armor.CharacterId);
            ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Id", armor.LocationId);
            return View(armor);
        }

        // POST: Armors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin , moderator")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Physical_protection,Fire_protection,Lightning_protection,Magic_protection,LocationId,CharacterId")] Armor armor)
        {
            if (id != armor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(armor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArmorExists(armor.Id))
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
            ViewData["CharacterId"] = new SelectList(_context.Characters, "Id", "Id", armor.CharacterId);
            ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Id", armor.LocationId);
            return View(armor);
        }

        // GET: Armors/Delete/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var armor = await _context.Armors
                .Include(a => a.Character)
                .Include(a => a.Location)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (armor == null)
            {
                return NotFound();
            }

            return View(armor);
        }

        // POST: Armors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var armor = await _context.Armors.FindAsync(id);
            _context.Armors.Remove(armor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArmorExists(int id)
        {
            return _context.Armors.Any(e => e.Id == id);
        }
    }
}
