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
    public class Negative_effectController : Controller
    {
        private readonly MainContext _context;

        public Negative_effectController(MainContext context)
        {
            _context = context;
        }

        // GET: Negative_effect
        public async Task<IActionResult> Index()
        {
            return View(await _context.Negative_Effects.ToListAsync());
        }

        // GET: Negative_effect/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var negative_effect = await _context.Negative_Effects
                .FirstOrDefaultAsync(m => m.Id == id);
            if (negative_effect == null)
            {
                return NotFound();
            }

            return View(negative_effect);
        }

        // GET: Negative_effect/Create
        [Authorize(Roles = "admin, moderator")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Negative_effect/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin, moderator")]
        public async Task<IActionResult> Create([Bind("Id,Title,Effect")] Negative_effect negative_effect)
        {
            if (ModelState.IsValid)
            {
                _context.Add(negative_effect);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(negative_effect);
        }

        // GET: Negative_effect/Edit/5
        [Authorize(Roles = "admin, moderator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var negative_effect = await _context.Negative_Effects.FindAsync(id);
            if (negative_effect == null)
            {
                return NotFound();
            }
            return View(negative_effect);
        }

        // POST: Negative_effect/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin, moderator")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Effect")] Negative_effect negative_effect)
        {
            if (id != negative_effect.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(negative_effect);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Negative_effectExists(negative_effect.Id))
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
            return View(negative_effect);
        }

        // GET: Negative_effect/Delete/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var negative_effect = await _context.Negative_Effects
                .FirstOrDefaultAsync(m => m.Id == id);
            if (negative_effect == null)
            {
                return NotFound();
            }

            return View(negative_effect);
        }

        // POST: Negative_effect/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var negative_effect = await _context.Negative_Effects.FindAsync(id);
            _context.Negative_Effects.Remove(negative_effect);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Negative_effectExists(int id)
        {
            return _context.Negative_Effects.Any(e => e.Id == id);
        }
    }
}
