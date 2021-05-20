using System;
using System.Collections.Generic;

namespace OnlineGameStore.Models
{
    public partial class AccountGame
    {
        public int AccountGameId { get; set; }
        public int AccountId { get; set; }
        public int GameId { get; set; }

        public virtual Account Account { get; set; }
        public virtual Game Game { get; set; }
    }
}
