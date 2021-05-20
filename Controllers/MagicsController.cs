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
    public class MagicsController : Controller
    {
        private readonly MainContext _context;

        public MagicsController(MainContext context)
        {
            _context = context;
        }

        // GET: Magics
        public async Task<IActionResult> Index()
        {
            return View(await _context.Magics.ToListAsync());
        }

        // GET: Magics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var magic = await _context.Magics
                .FirstOrDefaultAsync(m => m.Id == id);
            if (magic == null)
            {
                return NotFound();
            }

            return View(magic);
        }

        // GET: Magics/Create
        [Authorize(Roles = "admin, moderator")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Magics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin, moderator")]
        public async Task<IActionResult> Create([Bind("Id,Title,Concentration_costs,Occupied_cells")] Magic magic)
        {
            if (ModelState.IsValid)
            {
                _context.Add(magic);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(magic);
        }

        // GET: Magics/Edit/5
        [Authorize(Roles = "admin, moderator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var magic = await _context.Magics.FindAsync(id);
            if (magic == null)
            {
                return NotFound();
            }
            return View(magic);
        }

        // POST: Magics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin, moderator")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Concentration_costs,Occupied_cells")] Magic magic)
        {
            if (id != magic.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(magic);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MagicExists(magic.Id))
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
            return View(magic);
        }

        // GET: Magics/Delete/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var magic = await _context.Magics
                .FirstOrDefaultAsync(m => m.Id == id);
            if (magic == null)
            {
                return NotFound();
            }

            return View(magic);
        }

        // POST: Magics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var magic = await _context.Magics.FindAsync(id);
            _context.Magics.Remove(magic);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MagicExists(int id)
        {
            return _context.Magics.Any(e => e.Id == id);
        }
    }
}
