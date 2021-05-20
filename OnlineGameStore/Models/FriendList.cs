using System;
using System.Collections.Generic;

namespace OnlineGameStore.Models
{
    public partial class FriendList
    {
        public int FriendListId { get; set; }
        public int AccountId { get; set; }
        public int FriendId { get; set; }

        public virtual Account Account { get; set; }
        public virtual Account Friend { get; set; }
    }
}
