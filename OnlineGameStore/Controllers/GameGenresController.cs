using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineGameStore.Models;

namespace OnlineGameStore.Controllers
{
    public class GameGenresController : Controller
    {
        private readonly GameStoreContext _context;

        public GameGenresController(GameStoreContext context)
        {
            _context = context;
        }

        // GET: GameGenres
        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Game Genres";
            return View(await _context.GameGenre.ToListAsync());
        }

        public async Task<IActionResult> ViewGames(int id)
        {
            return RedirectToAction("Index", "Game", new {gameGenreId = id });
        }

        // GET: GameGenres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameGenre = await _context.GameGenre
                .FirstOrDefaultAsync(m => m.GameGenreId == id);
            if (gameGenre == null)
            {
                return NotFound();
            }

            return View(gameGenre);
        }

        // GET: GameGenres/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GameGenres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GameGenreId,Name")] GameGenre gameGenre)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gameGenre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gameGenre);
        }

        // GET: GameGenres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameGenre = await _context.GameGenre.FindAsync(id);
            if (gameGenre == null)
            {
                return NotFound();
            }
            return View(gameGenre);
        }

        // POST: GameGenres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GameGenreId,Name")] GameGenre gameGenre)
        {
            if (id != gameGenre.GameGenreId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gameGenre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameGenreExists(gameGenre.GameGenreId))
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
            return View(gameGenre);
        }

        // GET: GameGenres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameGenre = await _context.GameGenre
                .FirstOrDefaultAsync(m => m.GameGenreId == id);
            if (gameGenre == null)
            {
                return NotFound();
            }

            return View(gameGenre);
        }

        // POST: GameGenres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gameGenre = await _context.GameGenre.FindAsync(id);
            _context.GameGenre.Remove(gameGenre);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GameGenreExists(int id)
        {
            return _context.GameGenre.Any(e => e.GameGenreId == id);
        }
    }
}
