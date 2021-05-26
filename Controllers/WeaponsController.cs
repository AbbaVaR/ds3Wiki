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
    public class WeaponsController : Controller
    {
        private readonly MainContext _context;

        public WeaponsController(MainContext context)
        {
            _context = context;
        }

        // GET: Weapons
        public async Task<IActionResult> Index()
        {
            var mainContext = _context.Weapons.Include(w => w.Character).Include(w => w.Character_characteristic).Include(w => w.Location);
            return View(await mainContext.ToListAsync());
        }

        // GET: Weapons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weapon = await _context.Weapons
                .Include(w => w.Character)
                .Include(w => w.Character_characteristic)
                .Include(w => w.Location)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (weapon == null)
            {
                return NotFound();
            }

            return View(weapon);
        }

        // GET: Weapons/Create
        [Authorize(Roles = "admin , moderator")]
        public IActionResult Create()
        {
            ViewData["CharacterId"] = new SelectList(_context.Characters, "Id", "Id");
            ViewData["Character_characteristicId"] = new SelectList(_context.Character_Characteristics, "Id", "Id");
            ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Id");
            return View();
        }

        // POST: Weapons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin , moderator")]
        public async Task<IActionResult> Create([Bind("Id,Title,Types,Damage,Distance,Support_for_improvement,LocationId,CharacterId,Character_characteristicId")] Weapon weapon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(weapon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CharacterId"] = new SelectList(_context.Characters, "Id", "Id", weapon.CharacterId);
            ViewData["Character_characteristicId"] = new SelectList(_context.Character_Characteristics, "Id", "Id", weapon.Character_characteristicId);
            ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Id", weapon.LocationId);
            return View(weapon);
        }

        // GET: Weapons/Edit/5
        [Authorize(Roles = "admin , moderator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weapon = await _context.Weapons.FindAsync(id);
            if (weapon == null)
            {
                return NotFound();
            }
            ViewData["CharacterId"] = new SelectList(_context.Characters, "Id", "Id", weapon.CharacterId);
            ViewData["Character_characteristicId"] = new SelectList(_context.Character_Characteristics, "Id", "Id", weapon.Character_characteristicId);
            ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Id", weapon.LocationId);
            return View(weapon);
        }

        // POST: Weapons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin , moderator")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Types,Damage,Distance,Support_for_improvement,LocationId,CharacterId,Character_characteristicId")] Weapon weapon)
        {
            if (id != weapon.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(weapon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WeaponExists(weapon.Id))
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
            ViewData["CharacterId"] = new SelectList(_context.Characters, "Id", "Id", weapon.CharacterId);
            ViewData["Character_characteristicId"] = new SelectList(_context.Character_Characteristics, "Id", "Id", weapon.Character_characteristicId);
            ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Id", weapon.LocationId);
            return View(weapon);
        }

        // GET: Weapons/Delete/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weapon = await _context.Weapons
                .Include(w => w.Character)
                .Include(w => w.Character_characteristic)
                .Include(w => w.Location)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (weapon == null)
            {
                return NotFound();
            }

            return View(weapon);
        }

        // POST: Weapons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var weapon = await _context.Weapons.FindAsync(id);
            _context.Weapons.Remove(weapon);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WeaponExists(int id)
        {
            return _context.Weapons.Any(e => e.Id == id);
        }
    }
}
