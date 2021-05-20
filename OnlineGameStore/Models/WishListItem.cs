using System;
using System.Collections.Generic;

namespace OnlineGameStore.Models
{
    public partial class WishListItem
    {
        public int WishListItemId { get; set; }
        public int WishListId { get; set; }
        public int GameId { get; set; }

        public virtual Game Game { get; set; }
        public virtual WishList WishList { get; set; }
    }
}
