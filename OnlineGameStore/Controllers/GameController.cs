using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineGameStore.Models;

namespace OnlineGameStore.Controllers
{
    public class GameController : Controller
    {
        private readonly GameStoreContext _context;
        UtilityClasses.Utilities util;
        public GameController(GameStoreContext context)
        {
            _context = context;
            util = new UtilityClasses.Utilities(context);
        }

        // GET: Game
        public async Task<IActionResult> Index(int? gameGenreId)
        {
            //if no genre specified show all games
            if(gameGenreId == null)
            {
                ViewData["Title"] = "All Games";
                var gameStoreContext = _context.Game.Include(g => g.GameGenre);
                return View(await gameStoreContext.ToListAsync());
            }
            else // else show only the specified genre games
            {
                var gameGenre = _context.GameGenre.FirstOrDefault(gg => gg.GameGenreId == gameGenreId);
                ViewData["Title"] = $"{gameGenre.Name} Games";
                var gameStoreContext = _context.Game.Include(g => g.GameGenre).Where(gg=>gg.GameGenreId == gameGenreId);
                return View(await gameStoreContext.ToListAsync());
            }
            
        }

        public async Task<IActionResult> WishListIndex(int userId = -1)
        {
            //get games on wishList
            //if user id is -1 person is viewing their own wishlist
            int accountId = 0;
            if(userId == -1)
            {
                ViewData["Title"] = "My Wishlist";
                if (User.Identity.Name != null)
                {
                    accountId = util.GetAccountId(User.Identity.Name);
                }
            }
            else
            {
                var user = _context.Profile.FirstOrDefault(p => p.AccountId == userId); 
                if(user != null)
                {
                    ViewData["Title"] = $"{user.ProfileName}'s Wishlist";
                }
                else
                {
                    ViewData["Title"] = "Someone's Wishlist";
                }
                accountId = userId;
            }
            List<Game> games = new List<Game>();
            var wl = _context.WishList.FirstOrDefault(a => a.AccountId == accountId);
            if(wl != null)
            {
                if (_context.WishListItem.Any(a => a.WishListId == wl.WishListId))
                {
                    var wlGames = _context.WishListItem.Where(a => a.WishListId == wl.WishListId);

                    if (wlGames != null)
                    {
                        foreach (var game in wlGames)
                        {
                            games.Add(_context.Game.FirstOrDefault(w => w.GameId == game.GameId));
                        }
                    }

                }
            }
            IEnumerable<Game> gameEnum = games;
            return View(gameEnum.ToList());
        }


        // GET: Game/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Game
                .Include(g => g.GameGenre)
                .FirstOrDefaultAsync(m => m.GameId == id);
            if (game == null)
            {
                return NotFound();
            }

            ViewData["IsWishlisted"] = "false";
            //check wishlist status, send to view data
            if (User.Identity.Name != null)
            {
                //get a user
                var user = _context.Account.FirstOrDefault(a => a.AspuserId == User.Identity.Name);
                //if user has profile run this
                if(user != null)
                {
                    ViewData["IsLoggedIn"] = "true";
                    if (user == null)
                    {
                        ViewData["IsLoggedIn"] = "false";
                    }
                    //get their wishlist
                    var wishList = _context.WishList.Include(w => w.WishListItem).FirstOrDefault(m => m.AccountId == user.AccountId);
                    if (wishList != null)
                    {
                        var isOnWishList = _context.WishListItem.Where(w => w.WishListId == wishList.WishListId).FirstOrDefault(w => w.GameId == game.GameId);
                        //check if the game is on their wishlist
                        if (isOnWishList != null)
                        {
                            ViewData["IsWishlisted"] = "true";
                        }
                    }
                }
            }

            // Get the orderIds that are processed matching the current user accountId
            // Search through those orderIds to find the current gameId
            // If found then enable download button, else do not
            ViewData["IsPurchased"] = "false";
            if (User.Identity.Name != null)
            {
                // Get the current user
                var user = _context.Account.FirstOrDefault(u => u.AspuserId == User.Identity.Name);
                if (user != null)
                {
                    // Get orders attached to the current user that have been processed
                    var orders = _context.Order.Where(a => a.AccountId == user.AccountId).Where(b => b.IsProcessed == true);
                    // Search through each order to find the current gameId
                    foreach (var order in orders)
                    {
                        var thisGame = _context.OrderItem.Where(c => c.OrderId == order.OrderId).FirstOrDefault(d => d.GameId == id);
                        // If the game was found, isPurchased is true and break the loop, otherwise false and keep searching
                        if (thisGame != null)
                        {
                            ViewData["IsPurchased"] = "true";
                            break;
                        }
                    }
                }
            }
            
            ViewData["Title"] = $"{game.GameName}";
            return View(game);
        }

        public async Task<IActionResult> AddToWishList(int gameId)
        {
            //When user clicks add to wishlist,
            //check if the user has a wishlist if not create it
            //once wishlist is found or created, create wishlist item entry with gameid
            WishList wl;
            WishListItem wli;
            var userId = util.GetAccountId(User.Identity.Name);

            var wlRecord = _context.WishList.FirstOrDefault(a => a.AccountId == userId);
            if(wlRecord == null)
            {
                //create wishlist
                wl = new WishList();
                wl.AccountId = userId;
                wl.IsPublic = false;

                _context.WishList.Add(wl);
                await _context.SaveChangesAsync();
                wlRecord = _context.WishList.FirstOrDefault(a => a.AccountId == userId);
            }

            wli = new WishListItem();
            wli.WishListId = wlRecord.WishListId;
            wli.GameId = gameId;
            _context.WishListItem.Add(wli);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", new {id = gameId});
        }

        public async Task<IActionResult> RemoveFromWishList(int gameId)
        {
            //find wishlist item entry where game id and users wishlist id match
            //and remove it 
            var userId = util.GetAccountId(User.Identity.Name);
            var wishListId = _context.WishList.FirstOrDefault(w => w.AccountId == userId);
            var wli = _context.WishListItem.FirstOrDefault(w => w.WishListId == wishListId.WishListId && w.GameId == gameId);

            _context.WishListItem.Remove(wli);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", new { id = gameId });
        }

        // GET: Game/Create
        public IActionResult Create()
        {
            ViewData["GameGenreId"] = new SelectList(_context.GameGenre, "GameGenreId", "Name");
            return View();
        }

        // POST: Game/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GameId,GameName,GameDescription,GameDownloadLink,GamePrice,GameDiscount,GameGenreId")] Game game)
        {
            //deal with uploaded file
            string filePath = Path.GetFileNameWithoutExtension(game.GameDownloadLink);
            
            
            if (ModelState.IsValid)
            {
                _context.Add(game);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GameGenreId"] = new SelectList(_context.GameGenre, "GameGenreId", "Name", game.GameGenreId);
            return View(game);
        }

        // GET: Game/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Game.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            ViewData["GameGenreId"] = new SelectList(_context.GameGenre, "GameGenreId", "Name", game.GameGenreId);
            return View(game);
        }

        // POST: Game/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GameId,GameName,GameDescription,GameDownloadLink,GamePrice,GameDiscount,GameGenreId")] Game game)
        {
            if (id != game.GameId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(game);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameExists(game.GameId))
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
            ViewData["GameGenreId"] = new SelectList(_context.GameGenre, "GameGenreId", "Name", game.GameGenreId);
            return View(game);
        }

        // GET: Game/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Game
                .Include(g => g.GameGenre)
                .FirstOrDefaultAsync(m => m.GameId == id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        // POST: Game/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var game = await _context.Game.FindAsync(id);
            _context.Game.Remove(game);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GameExists(int id)
        {
            return _context.Game.Any(e => e.GameId == id);
        }
    }
}
