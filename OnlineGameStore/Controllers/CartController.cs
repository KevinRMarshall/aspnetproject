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
    public class CartController : Controller
    {
        private readonly GameStoreContext _context;

        public CartController(GameStoreContext context)
        {
            _context = context;
        }

        // GET: Cart
        public async Task<IActionResult> Index()
        {
            var curUser = _context.Account.FirstOrDefault(a => a.AspuserId == User.Identity.Name);
            if (curUser == null)
            {
                return View("NotLoggedIn");
            }
            var gameStoreContext = _context.Cart.Include(c => c.CartGame);
            return View(await gameStoreContext.ToListAsync());
        }

        // POST: Cart/AddToCart/5
        public async Task<IActionResult> AddToCart(int gameId)
        {
            // Get the current user, checking that they are logged in
            var curUser = _context.Account.FirstOrDefault(a => a.AspuserId == User.Identity.Name);
            if (curUser == null)
            {
                // Display NotLoggedIn page
                return View("NotLoggedIn");
            }

            // Get the gameStoreContext
            var gameStoreContext = _context.Cart.Include(c => c.CartGame);
            // Get any carts matching the current user's accountId
            var userCart = gameStoreContext.Where(a => a.AccountId == curUser.AccountId);
            // Create a new Cart object
            Cart newCart = new Cart();

            // If there is no cart...
            if (userCart.Count() == 0)
            {
                // Create a new cart with current user's accountId
                newCart.AccountId = curUser.AccountId;
                _context.Cart.Add(newCart);
            }
            // If there is more than 1 cart for an account...
            else if (userCart.Count() > 1)
            {
                // Delete each cart
                foreach (var cart in userCart)
                {
                    await Delete(cart.CartId);
                }
                // Create a new cart with current user's accountId
                newCart.AccountId = curUser.AccountId;
                _context.Cart.Add(newCart);
            }
            else
            {
                // Create a new cart object using the found cart
                // (This is used for consistency with the other If options)
                newCart = userCart.FirstOrDefault();
            }

            await _context.SaveChangesAsync();
            // Create a CartGame object with the gameId and the newCart cartId
            CartGame newCartGame = new CartGame();
            newCartGame.CartId = newCart.CartId;
            newCartGame.GameId = gameId;

            // Add the cartGame object to the context
            _context.CartGame.Add(newCartGame);

            // Save changes and go to the view
            await _context.SaveChangesAsync();
            //return View(await gameStoreContext.ToListAsync());
            return RedirectToAction("Index");
        }

        // GET: Cart/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cart = await _context.Cart
                .Include(c => c.CartGame)
                .Include(c => c.Account)
                .FirstOrDefaultAsync(m => m.CartId == id);
            if (cart == null)
            {
                return NotFound();
            }

            return View(cart);
        }

        // GET: Cart/Create
        public IActionResult Create()
        {
            ViewData["AccountId"] = new SelectList(_context.Account, "AccountId", "AspuserId");
            return View();
        }

        // POST: Cart/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CartId,AccountId")] Cart cart)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cart);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccountId"] = new SelectList(_context.Account, "AccountId", "AspuserId", cart.AccountId);
            return View(cart);
        }

        // GET: Cart/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cart = await _context.Cart.FindAsync(id);
            if (cart == null)
            {
                return NotFound();
            }
            ViewData["AccountId"] = new SelectList(_context.Account, "AccountId", "AspuserId", cart.AccountId);
            return View(cart);
        }

        // POST: Cart/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CartId,AccountId")] Cart cart)
        {
            if (id != cart.CartId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartExists(cart.CartId))
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
            ViewData["AccountId"] = new SelectList(_context.Account, "AccountId", "AspuserId", cart.AccountId);
            return View(cart);
        }

        // GET: Cart/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cart = await _context.Cart
                .Include(c => c.Account)
                .FirstOrDefaultAsync(m => m.CartId == id);
            if (cart == null)
            {
                return NotFound();
            }

            return View(cart);
        }

        // POST: Cart/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cart = await _context.Cart.FindAsync(id);
            _context.Cart.Remove(cart);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CartExists(int id)
        {
            return _context.Cart.Any(e => e.CartId == id);
        }
    }
}
