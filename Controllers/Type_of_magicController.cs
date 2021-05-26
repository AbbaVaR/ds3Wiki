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
    public class Type_of_magicController : Controller
    {
        private readonly MainContext _context;

        public Type_of_magicController(MainContext context)
        {
            _context = context;
        }

        // GET: Type_of_magic
        public async Task<IActionResult> Index()
        {
            var mainContext = _context.Type_Of_Magics.Include(t => t.Character_characteristic);
            return View(await mainContext.ToListAsync());
        }

        // GET: Type_of_magic/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var type_of_magic = await _context.Type_Of_Magics
                .Include(t => t.Character_characteristic)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (type_of_magic == null)
            {
                return NotFound();
            }

            return View(type_of_magic);
        }

        // GET: Type_of_magic/Create
        [Authorize(Roles = "admin , moderator")]
        public IActionResult Create()
        {
            ViewData["Character_characteristicId"] = new SelectList(_context.Character_Characteristics, "Id", "Id");
            return View();
        }

        // POST: Type_of_magic/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin , moderator")]
        public async Task<IActionResult> Create([Bind("Id,Title,Character_characteristicId")] Type_of_magic type_of_magic)
        {
            if (ModelState.IsValid)
            {
                _context.Add(type_of_magic);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Character_characteristicId"] = new SelectList(_context.Character_Characteristics, "Id", "Id", type_of_magic.Character_characteristicId);
            return View(type_of_magic);
        }

        // GET: Type_of_magic/Edit/5
        [Authorize(Roles = "admin , moderator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var type_of_magic = await _context.Type_Of_Magics.FindAsync(id);
            if (type_of_magic == null)
            {
                return NotFound();
            }
            ViewData["Character_characteristicId"] = new SelectList(_context.Character_Characteristics, "Id", "Id", type_of_magic.Character_characteristicId);
            return View(type_of_magic);
        }

        // POST: Type_of_magic/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin , moderator")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Character_characteristicId")] Type_of_magic type_of_magic)
        {
            if (id != type_of_magic.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(type_of_magic);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Type_of_magicExists(type_of_magic.Id))
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
            ViewData["Character_characteristicId"] = new SelectList(_context.Character_Characteristics, "Id", "Id", type_of_magic.Character_characteristicId);
            return View(type_of_magic);
        }

        // GET: Type_of_magic/Delete/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var type_of_magic = await _context.Type_Of_Magics
                .Include(t => t.Character_characteristic)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (type_of_magic == null)
            {
                return NotFound();
            }

            return View(type_of_magic);
        }

        // POST: Type_of_magic/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var type_of_magic = await _context.Type_Of_Magics.FindAsync(id);
            _context.Type_Of_Magics.Remove(type_of_magic);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Type_of_magicExists(int id)
        {
            return _context.Type_Of_Magics.Any(e => e.Id == id);
        }
    }
}
