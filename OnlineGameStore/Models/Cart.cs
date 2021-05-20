using System;
using System.Collections.Generic;

namespace OnlineGameStore.Models
{
    public partial class Cart
    {
        public Cart()
        {
            CartGame = new HashSet<CartGame>();
        }

        public int CartId { get; set; }
        public int AccountId { get; set; }

        public virtual Account Account { get; set; }
        public virtual ICollection<CartGame> CartGame { get; set; }
    }
}
