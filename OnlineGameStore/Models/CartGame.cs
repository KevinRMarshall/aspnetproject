using System;
using System.Collections.Generic;

namespace OnlineGameStore.Models
{
    public partial class CartGame
    {
        public int CartGameId { get; set; }
        public int CartId { get; set; }
        public int GameId { get; set; }

        public virtual Cart Cart { get; set; }
        public virtual Game Game { get; set; }
    }
}
