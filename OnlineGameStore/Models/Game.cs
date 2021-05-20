using System;
using System.Collections.Generic;

namespace OnlineGameStore.Models
{
    public partial class Game
    {
        public Game()
        {
            AccountGame = new HashSet<AccountGame>();
            CartGame = new HashSet<CartGame>();
            Event = new HashSet<Event>();
            OrderItem = new HashSet<OrderItem>();
            Review = new HashSet<Review>();
            WishListItem = new HashSet<WishListItem>();
        }

        public int GameId { get; set; }
        public string GameName { get; set; }
        public string GameDescription { get; set; }
        public string GameDownloadLink { get; set; }
        public decimal GamePrice { get; set; }
        public string GameDiscount { get; set; }
        public int GameGenreId { get; set; }

        public virtual GameGenre GameGenre { get; set; }
        public virtual ICollection<AccountGame> AccountGame { get; set; }
        public virtual ICollection<CartGame> CartGame { get; set; }
        public virtual ICollection<Event> Event { get; set; }
        public virtual ICollection<OrderItem> OrderItem { get; set; }
        public virtual ICollection<Review> Review { get; set; }
        public virtual ICollection<WishListItem> WishListItem { get; set; }
    }
}
