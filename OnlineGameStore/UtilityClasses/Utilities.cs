using OnlineGameStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGameStore.UtilityClasses
{
    public class Utilities
    {
        private readonly GameStoreContext _context;

        public Utilities(GameStoreContext context)
        {
            _context = context;
        }

        public int GetAccountId(string userName)
        {
            return _context.Account.FirstOrDefault(a => a.AspuserId == userName).AccountId;
        }
    }
}
