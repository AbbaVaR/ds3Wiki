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
    public class Improvement_pathController : Controller
    {
        private readonly MainContext _context;

        public Improvement_pathController(MainContext context)
        {
            _context = context;
        }

        // GET: Improvement_path
        public async Task<IActionResult> Index()
        {
            return View(await _context.Improvement_Paths.ToListAsync());
        }

        // GET: Improvement_path/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var improvement_path = await _context.Improvement_Paths
                .FirstOrDefaultAsync(m => m.Id == id);
            if (improvement_path == null)
            {
                return NotFound();
            }

            return View(improvement_path);
        }

        // GET: Improvement_path/Create
        [Authorize(Roles = "admin , moderator")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Improvement_path/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin , moderator")]
        public async Task<IActionResult> Create([Bind("Id,Gem_name,Advantages,Disadvantage")] Improvement_path improvement_path)
        {
            if (ModelState.IsValid)
            {
                _context.Add(improvement_path);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(improvement_path);
        }

        // GET: Improvement_path/Edit/5
        [Authorize(Roles = "admin , moderator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var improvement_path = await _context.Improvement_Paths.FindAsync(id);
            if (improvement_path == null)
            {
                return NotFound();
            }
            return View(improvement_path);
        }

        // POST: Improvement_path/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin , moderator")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Gem_name,Advantages,Disadvantage")] Improvement_path improvement_path)
        {
            if (id != improvement_path.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(improvement_path);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Improvement_pathExists(improvement_path.Id))
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
            return View(improvement_path);
        }

        // GET: Improvement_path/Delete/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var improvement_path = await _context.Improvement_Paths
                .FirstOrDefaultAsync(m => m.Id == id);
            if (improvement_path == null)
            {
                return NotFound();
            }

            return View(improvement_path);
        }

        // POST: Improvement_path/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var improvement_path = await _context.Improvement_Paths.FindAsync(id);
            _context.Improvement_Paths.Remove(improvement_path);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Improvement_pathExists(int id)
        {
            return _context.Improvement_Paths.Any(e => e.Id == id);
        }
    }
}
