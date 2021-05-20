using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using OnlineGameStore.Models;

namespace OnlineGameStore.Controllers
{
    public class ProfileController : Controller
    {
        private readonly GameStoreContext _context;

        public ProfileController(GameStoreContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> FindFriends()
        {
            //find who is being following
            ViewData["Title"] = "Find Friends";
            var account = _context.Account.FirstOrDefault(a => a.AspuserId == User.Identity.Name);
            var friends = _context.FriendList.Where(p => p.AccountId == account.AccountId);
            List<int> friendIds = new List<int>();
            foreach (var friend in friends)
            {
                friendIds.Add(friend.FriendId);
            }

            var followeesV = _context.Profile.Where(p => p.AccountId != account.AccountId);
            List<Profile> followees = new List<Profile>();
            foreach (Profile profile in followeesV)
            {
                followees.Add(profile);
            }
            foreach (int id in friendIds)
            {
                if (_context.Profile.FirstOrDefault(p => p.AccountId == id) != null)
                    followees.Remove(_context.Profile.Include(a => a.Account).FirstOrDefault(p => p.AccountId == id));
            }

            IEnumerable<Profile> followEnum = followees;
            return View(followEnum.ToList());

            //show people who arnt following
            
            //var gameStoreContext = (account != null) ? _context.Profile.Include(p => p.Account).Where(p => p.AccountId != account.AccountId) :
            //    _context.Profile.Include(p => p.Account);
            //return View(await gameStoreContext.ToListAsync());
        }

        public async Task<IActionResult> MyFriends()
        {
            ViewData["Title"] = "Gamers I follow";
            
            // Get the current user account
            var curUser = _context.Account.FirstOrDefault(a => a.AspuserId == User.Identity.Name);
            
            // Check if the user exists/is logged in
            if(curUser != null)
            {
                // Get a list of all friends linked to the current user's accountId
                var friends = _context.FriendList.Where(p => p.AccountId == curUser.AccountId);

                // Add the friendIds to a list
                List<int> friendIds = new List<int>();
                foreach (var friend in friends)
                {
                    friendIds.Add(friend.FriendId);
                }

                // Add each profile from friendIds to a list called followees
                List<Profile> followees = new List<Profile>();
                foreach (int id in friendIds)
                {
                    if(_context.Profile.FirstOrDefault(p => p.AccountId == id) != null) 
                        followees.Add(_context.Profile.Include(a=>a.Account).FirstOrDefault(p => p.AccountId == id));
                }

                // Create an return and enuberable list of followees
                IEnumerable<Profile> followEnum = followees;
                return View(followEnum.ToList());
            }

            // If user is not currently logged in, display the home page
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> AddFriend(int receiverId)
        {
            // Get the sender and receiver's accountIds to create a friendlist connection
            int senderId = _context.Account.FirstOrDefault(a => a.AspuserId == User.Identity.Name).AccountId;
            // Check if a connection has already been created
            bool friendExists = _context.FriendList.FirstOrDefault(a => a.AccountId == senderId && a.FriendId == receiverId) != null;
            
            if(!friendExists)
            {
                // Create the connection and add it to the database
                FriendList friendList = new FriendList { AccountId = senderId, FriendId = receiverId };
                _context.Add(friendList);
                await _context.SaveChangesAsync();
            }

            // View the reciever's profile page
            var profile = _context.Profile.Include(a => a.Account).FirstOrDefault(p => p.AccountId == receiverId);
            return RedirectToAction("Details", new { id = profile.ProfileId });
        }
        
        public async Task<IActionResult> RemoveFriend(int receiverId)
        {
            // Get the sender and receiver's accountIds to create friendlist connection
            int senderId = _context.Account.FirstOrDefault(a => a.AspuserId == User.Identity.Name).AccountId;
            var friendList = _context.FriendList.FirstOrDefault(a => a.AccountId == senderId && a.FriendId == receiverId);
            var profile = _context.Profile.Include(a => a.Account).FirstOrDefault(p => p.AccountId == receiverId);
             _context.Remove(friendList);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", new { id = profile.ProfileId });
        }

        // GET: Profile/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profile = await _context.Profile
                .Include(p => p.Account)
                .FirstOrDefaultAsync(m => m.ProfileId == id);
            if (profile == null)
            {
                return NotFound();
            }
            var visitor = _context.Account.FirstOrDefault(a => a.AspuserId == User.Identity.Name);
            var owner = _context.Account.FirstOrDefault(a => a.AccountId == profile.AccountId);
            ViewData["Title"] = profile.ProfileName + "'s Profile";
            ViewData["OwnerId"] = owner.AspuserId;
            ViewData["FriendId"] = (_context.FriendList.FirstOrDefault(f => f.AccountId == visitor.AccountId && f.FriendId == owner.AccountId) != null) ?
                _context.FriendList.FirstOrDefault(f => f.AccountId == visitor.AccountId && f.FriendId == owner.AccountId).FriendId.ToString():
                "";
            return View(profile);
        }

        // GET: Profile/Create
        public IActionResult Create()
        {
            string error = "false";
            if (User.Identity.Name != null)
            {
                var account = _context.Account.FirstOrDefault(z => z.AspuserId == User.Identity.Name);
                if (account != null)
                {
                    var profile = _context.Profile.FirstOrDefault(z => z.AccountId == account.AccountId);
                    if(profile != null) 
                        return RedirectToAction("Details", new { id = profile.ProfileId});
                }
                ViewData["ErrorMessage"] = error;
                return View();
            }
            else
            {
                error = "true";
            }

            ViewData["ErrorMessage"] = error;
            return View();
        }

        // POST: Profile/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProfileId,AccountId,ProfileName,ProfileDescription,Gender,FavouriteGameCategory,FavouritePlatform,PaidOrFree,Country,Birthdate,ParentalCode,PhoneNumber")] Profile profile)
        {
            if (ModelState.IsValid && User.Identity.Name != null)
            {
                Account account = new Account
                {
                    AspuserId = User.Identity.Name
                };

                _context.Account.Add(account);
                await _context.SaveChangesAsync();

                profile.AccountId = account.AccountId;
                _context.Add(profile);

                await _context.SaveChangesAsync();
                return RedirectToAction("Details", new { id = profile.ProfileId });
            }
            return View(profile);
        }

        // GET: Profile/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profile = await _context.Profile.FindAsync(id);
            if (profile == null)
            {
                return NotFound();
            }
            ViewData["AccountId"] = new SelectList(_context.Account, "AccountId", "AspuserId", profile.AccountId);
            return View(profile);
        }

        // POST: Profile/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProfileId,AccountId,ProfileName,ProfileDescription,Gender,FavouriteGameCategory,FavouritePlatform,PaidOrFree,Country,Birthdate,ParentalCode,PhoneNumber")] Profile profile)
        {
            if (id != profile.ProfileId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfileExists(profile.ProfileId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", new { id = profile.ProfileId });
            }
            ViewData["AccountId"] = new SelectList(_context.Account, "AccountId", "AspuserId", profile.AccountId);
            return View(profile);
        }

        // GET: Profile/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profile = await _context.Profile
                .Include(p => p.Account)
                .FirstOrDefaultAsync(m => m.ProfileId == id);
            if (profile == null)
            {
                return NotFound();
            }

            return View(profile);
        }

        // POST: Profile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var profile = await _context.Profile.FindAsync(id);
            _context.Profile.Remove(profile);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfileExists(int id)
        {
            return _context.Profile.Any(e => e.ProfileId == id);
        }
    }
}
