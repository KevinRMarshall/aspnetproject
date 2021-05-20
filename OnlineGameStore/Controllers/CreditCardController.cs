using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OnlineGameStore.Models;

namespace OnlineGameStore.Controllers
{
    public class CreditCardController : Controller
    {
        private readonly GameStoreContext _context;

        public CreditCardController(GameStoreContext context)
        {
            _context = context;
        }

        // GET: CreditCard
        public async Task<IActionResult> Index()
        {
            var account = _context.Account.FirstOrDefault(z => z.AspuserId == User.Identity.Name);
            var gameStoreContext = _context.CreditCard.Include(c => c.Account).Include(c => c.CardType).Include(c => c.Country).Include(c => c.ProvinceState).Where(z => z.AccountId == account.AccountId);
            return View(await gameStoreContext.ToListAsync());
        }

        // GET: CreditCard/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var creditCard = await _context.CreditCard
                .Include(c => c.Account)
                .Include(c => c.CardType)
                .Include(c => c.Country)
                .Include(c => c.ProvinceState)
                .FirstOrDefaultAsync(m => m.CreditId == id);
            if (creditCard == null)
            {
                return NotFound();
            }

            return View(creditCard);
        }

        // GET: CreditCard/Create
        public IActionResult Create()
        {

            var account = _context.Account.FirstOrDefault(z => z.AspuserId == User.Identity.Name);
            var billingProvince = _context.BillingProvinceState.FirstOrDefault(z => z.CountryId == 3);
            var billingProvince2 = _context.BillingProvinceState.FirstOrDefault(z => z.CountryId == 2);

            ViewData["AccountId"] = new SelectList(_context.Account.Where(z => z.AccountId == account.AccountId), "AccountId", "AspuserId");
            ViewData["CardTypeId"] = new SelectList(_context.CardType, "CardTypeId", "CardType1");
            ViewData["CountryId"] = new SelectList(_context.BillingCountry, "CountryId", "Name");
            ViewData["ProvinceStateId"] = new SelectList(_context.BillingProvinceState.Where(z => z.CountryId == billingProvince2.CountryId), "ProvinceStateId", "Name");
            ViewData["ProvinceStateId2"] = new SelectList(_context.BillingProvinceState.Where(z => z.CountryId == billingProvince.CountryId), "ProvinceStateId", "Name");
            return View();
        }

        // POST: CreditCard/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CreditId,AccountId,CardTypeId,CardNumber,CardCode,ExpireDate,CardHolder,BillingAddress,BillingPhone,CountryId,ProvinceStateId")] CreditCard creditCard)
        {
            if (ModelState.IsValid)
            {
                _context.Add(creditCard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccountId"] = new SelectList(_context.Account, "AccountId", "AspuserId", creditCard.AccountId);
            ViewData["CardTypeId"] = new SelectList(_context.CardType, "CardTypeId", "CardType1", creditCard.CardTypeId);
            ViewData["CountryId"] = new SelectList(_context.BillingCountry, "CountryId", "Name", creditCard.CountryId);
            ViewData["ProvinceStateId"] = new SelectList(_context.BillingProvinceState, "ProvinceStateId", "Name", creditCard.ProvinceStateId);
            return View(creditCard);
        }

        // GET: CreditCard/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var creditCard = await _context.CreditCard.FindAsync(id);
            if (creditCard == null)
            {
                return NotFound();
            }
            ViewData["AccountId"] = new SelectList(_context.Account, "AccountId", "AspuserId", creditCard.AccountId);
            ViewData["CardTypeId"] = new SelectList(_context.CardType, "CardTypeId", "CardType1", creditCard.CardTypeId);
            ViewData["CountryId"] = new SelectList(_context.BillingCountry, "CountryId", "Name", creditCard.CountryId);
            ViewData["ProvinceStateId"] = new SelectList(_context.BillingProvinceState, "ProvinceStateId", "Name", creditCard.ProvinceStateId);
            return View(creditCard);
        }

        // POST: CreditCard/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CreditId,AccountId,CardTypeId,CardNumber,CardCode,ExpireDate,CardHolder,BillingAddress,BillingPhone,CountryId,ProvinceStateId")] CreditCard creditCard)
        {
            if (id != creditCard.CreditId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(creditCard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CreditCardExists(creditCard.CreditId))
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
            ViewData["AccountId"] = new SelectList(_context.Account, "AccountId", "AspuserId", creditCard.AccountId);
            ViewData["CardTypeId"] = new SelectList(_context.CardType, "CardTypeId", "CardType1", creditCard.CardTypeId);
            ViewData["CountryId"] = new SelectList(_context.BillingCountry, "CountryId", "Name",creditCard.CountryId);
            ViewData["ProvinceStateId"] = new SelectList(_context.BillingProvinceState, "ProvinceStateId", "Name",creditCard.ProvinceStateId);
            return View(creditCard);
        }

        // GET: CreditCard/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var creditCard = await _context.CreditCard
                .Include(c => c.Account)
                .Include(c => c.CardType)
                .Include(c => c.Country)
                .Include(c => c.ProvinceState)
                .FirstOrDefaultAsync(m => m.CreditId == id);
            if (creditCard == null)
            {
                return NotFound();
            }

            return View(creditCard);
        }

        // POST: CreditCard/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var creditCard = await _context.CreditCard.FindAsync(id);
            _context.CreditCard.Remove(creditCard);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CreditCardExists(int id)
        {
            return _context.CreditCard.Any(e => e.CreditId == id);
        }

        [HttpGet]
        public JsonResult getCities(int id)
        {
        
        var proviences = new SelectList(_context.BillingProvinceState.Where(c => c.CountryId == id), "ProvinceStateId", "Name"); //call repository
            return Json(proviences); 
        }



    }
}
