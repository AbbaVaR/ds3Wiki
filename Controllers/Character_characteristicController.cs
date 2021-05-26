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
    public class Character_characteristicController : Controller
    {
        private readonly MainContext _context;

        public Character_characteristicController(MainContext context)
        {
            _context = context;
        }

        // GET: Character_characteristic
        public async Task<IActionResult> Index()
        {
            return View(await _context.Character_Characteristics.ToListAsync());
        }

        // GET: Character_characteristic/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var character_characteristic = await _context.Character_Characteristics
                .FirstOrDefaultAsync(m => m.Id == id);
            if (character_characteristic == null)
            {
                return NotFound();
            }

            return View(character_characteristic);
        }

        // GET: Character_characteristic/Create
        [Authorize(Roles = "admin , moderator")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Character_characteristic/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin , moderator")]
        public async Task<IActionResult> Create([Bind("Id,Title,Influence")] Character_characteristic character_characteristic)
        {
            if (ModelState.IsValid)
            {
                _context.Add(character_characteristic);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(character_characteristic);
        }

        // GET: Character_characteristic/Edit/5
        [Authorize(Roles = "admin , moderator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var character_characteristic = await _context.Character_Characteristics.FindAsync(id);
            if (character_characteristic == null)
            {
                return NotFound();
            }
            return View(character_characteristic);
        }

        // POST: Character_characteristic/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin , moderator")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Influence")] Character_characteristic character_characteristic)
        {
            if (id != character_characteristic.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(character_characteristic);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Character_characteristicExists(character_characteristic.Id))
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
            return View(character_characteristic);
        }

        // GET: Character_characteristic/Delete/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var character_characteristic = await _context.Character_Characteristics
                .FirstOrDefaultAsync(m => m.Id == id);
            if (character_characteristic == null)
            {
                return NotFound();
            }

            return View(character_characteristic);
        }

        // POST: Character_characteristic/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var character_characteristic = await _context.Character_Characteristics.FindAsync(id);
            _context.Character_Characteristics.Remove(character_characteristic);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Character_characteristicExists(int id)
        {
            return _context.Character_Characteristics.Any(e => e.Id == id);
        }
    }
}
