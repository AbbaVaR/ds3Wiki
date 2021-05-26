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
    public class Game_infoController : Controller
    {
        private readonly MainContext _context;

        public Game_infoController(MainContext context)
        {
            _context = context;
        }

        // GET: Game_info
        public async Task<IActionResult> Index()
        {
            return View(await _context.Games_Info.ToListAsync());
        }

        // GET: Game_info/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game_info = await _context.Games_Info
                .FirstOrDefaultAsync(m => m.Id == id);
            if (game_info == null)
            {
                return NotFound();
            }

            return View(game_info);
        }

        // GET: Game_info/Create
        [Authorize(Roles = "admin , moderator")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Game_info/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin , moderator")]
        public async Task<IActionResult> Create([Bind("Id,Name_of_game,Developer,Genre")] Game_info game_info)
        {
            if (ModelState.IsValid)
            {
                _context.Add(game_info);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(game_info);
        }

        // GET: Game_info/Edit/5
        [Authorize(Roles = "admin , moderator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game_info = await _context.Games_Info.FindAsync(id);
            if (game_info == null)
            {
                return NotFound();
            }
            return View(game_info);
        }

        // POST: Game_info/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin , moderator")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name_of_game,Developer,Genre")] Game_info game_info)
        {
            if (id != game_info.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(game_info);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Game_infoExists(game_info.Id))
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
            return View(game_info);
        }

        // GET: Game_info/Delete/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game_info = await _context.Games_Info
                .FirstOrDefaultAsync(m => m.Id == id);
            if (game_info == null)
            {
                return NotFound();
            }

            return View(game_info);
        }

        // POST: Game_info/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var game_info = await _context.Games_Info.FindAsync(id);
            _context.Games_Info.Remove(game_info);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Game_infoExists(int id)
        {
            return _context.Games_Info.Any(e => e.Id == id);
        }
    }
}
