using System;
using System.Collections.Generic;

namespace OnlineGameStore.Models
{
    public partial class WishList
    {
        public WishList()
        {
            WishListItem = new HashSet<WishListItem>();
        }

        public int WishListId { get; set; }
        public bool IsPublic { get; set; }
        public int AccountId { get; set; }

        public virtual Account Account { get; set; }
        public virtual ICollection<WishListItem> WishListItem { get; set; }
    }
}
