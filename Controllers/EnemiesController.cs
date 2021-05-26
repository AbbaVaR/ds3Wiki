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
    public class EnemiesController : Controller
    {
        private readonly MainContext _context;

        public EnemiesController(MainContext context)
        {
            _context = context;
        }

        // GET: Enemies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Enemies.ToListAsync());
        }

        // GET: Enemies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enemy = await _context.Enemies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enemy == null)
            {
                return NotFound();
            }

            return View(enemy);
        }

        // GET: Enemies/Create
        [Authorize(Roles = "admin , moderator")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Enemies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin , moderator")]
        public async Task<IActionResult> Create([Bind("Id,Name,Types,HP,Received_money")] Enemy enemy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enemy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(enemy);
        }

        // GET: Enemies/Edit/5
        [Authorize(Roles = "admin , moderator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enemy = await _context.Enemies.FindAsync(id);
            if (enemy == null)
            {
                return NotFound();
            }
            return View(enemy);
        }

        // POST: Enemies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin , moderator")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Types,HP,Received_money")] Enemy enemy)
        {
            if (id != enemy.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enemy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnemyExists(enemy.Id))
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
            return View(enemy);
        }

        // GET: Enemies/Delete/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enemy = await _context.Enemies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enemy == null)
            {
                return NotFound();
            }

            return View(enemy);
        }

        // POST: Enemies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enemy = await _context.Enemies.FindAsync(id);
            _context.Enemies.Remove(enemy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnemyExists(int id)
        {
            return _context.Enemies.Any(e => e.Id == id);
        }
    }
}
