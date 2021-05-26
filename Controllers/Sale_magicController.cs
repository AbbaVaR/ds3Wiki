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
    public class Sale_magicController : Controller
    {
        private readonly MainContext _context;

        public Sale_magicController(MainContext context)
        {
            _context = context;
        }

        // GET: Sale_magic
        public async Task<IActionResult> Index()
        {
            var mainContext = _context.Sale_Magics.Include(s => s.Character).Include(s => s.Magic);
            return View(await mainContext.ToListAsync());
        }

        // GET: Sale_magic/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sale_magic = await _context.Sale_Magics
                .Include(s => s.Character)
                .Include(s => s.Magic)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sale_magic == null)
            {
                return NotFound();
            }

            return View(sale_magic);
        }

        // GET: Sale_magic/Create
        [Authorize(Roles = "admin , moderator")]
        public IActionResult Create()
        {
            ViewData["CharacterId"] = new SelectList(_context.Characters, "Id", "Id");
            ViewData["MagicId"] = new SelectList(_context.Magics, "Id", "Id");
            return View();
        }

        // POST: Sale_magic/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin , moderator")]
        public async Task<IActionResult> Create([Bind("Id,CharacterId,MagicId")] Sale_magic sale_magic)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sale_magic);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CharacterId"] = new SelectList(_context.Characters, "Id", "Id", sale_magic.CharacterId);
            ViewData["MagicId"] = new SelectList(_context.Magics, "Id", "Id", sale_magic.MagicId);
            return View(sale_magic);
        }

        // GET: Sale_magic/Edit/5
        [Authorize(Roles = "admin , moderator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sale_magic = await _context.Sale_Magics.FindAsync(id);
            if (sale_magic == null)
            {
                return NotFound();
            }
            ViewData["CharacterId"] = new SelectList(_context.Characters, "Id", "Id", sale_magic.CharacterId);
            ViewData["MagicId"] = new SelectList(_context.Magics, "Id", "Id", sale_magic.MagicId);
            return View(sale_magic);
        }

        // POST: Sale_magic/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin , moderator")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CharacterId,MagicId")] Sale_magic sale_magic)
        {
            if (id != sale_magic.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sale_magic);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Sale_magicExists(sale_magic.Id))
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
            ViewData["CharacterId"] = new SelectList(_context.Characters, "Id", "Id", sale_magic.CharacterId);
            ViewData["MagicId"] = new SelectList(_context.Magics, "Id", "Id", sale_magic.MagicId);
            return View(sale_magic);
        }

        // GET: Sale_magic/Delete/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sale_magic = await _context.Sale_Magics
                .Include(s => s.Character)
                .Include(s => s.Magic)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sale_magic == null)
            {
                return NotFound();
            }

            return View(sale_magic);
        }

        // POST: Sale_magic/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sale_magic = await _context.Sale_Magics.FindAsync(id);
            _context.Sale_Magics.Remove(sale_magic);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Sale_magicExists(int id)
        {
            return _context.Sale_Magics.Any(e => e.Id == id);
        }
    }
}
