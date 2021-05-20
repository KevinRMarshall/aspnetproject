using System;
using System.Collections.Generic;

namespace OnlineGameStore.Models
{
    public partial class Account
    {
        public Account()
        {
            AccountGame = new HashSet<AccountGame>();
            Cart = new HashSet<Cart>();
            CreditCard = new HashSet<CreditCard>();
            EventAttendee = new HashSet<EventAttendee>();
            FriendListAccount = new HashSet<FriendList>();
            FriendListFriend = new HashSet<FriendList>();
            Order = new HashSet<Order>();
            Profile = new HashSet<Profile>();
            WishList = new HashSet<WishList>();
        }

        public int AccountId { get; set; }
        public string AspuserId { get; set; }
        public string IsAdmin { get; set; }

        public virtual ICollection<AccountGame> AccountGame { get; set; }
        public virtual ICollection<Cart> Cart { get; set; }
        public virtual ICollection<CreditCard> CreditCard { get; set; }
        public virtual ICollection<EventAttendee> EventAttendee { get; set; }
        public virtual ICollection<FriendList> FriendListAccount { get; set; }
        public virtual ICollection<FriendList> FriendListFriend { get; set; }
        public virtual ICollection<Order> Order { get; set; }
        public virtual ICollection<Profile> Profile { get; set; }
        public virtual ICollection<WishList> WishList { get; set; }
    }
}
