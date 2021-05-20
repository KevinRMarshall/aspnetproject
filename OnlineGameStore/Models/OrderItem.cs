using System;
using System.Collections.Generic;

namespace OnlineGameStore.Models
{
    public partial class OrderItem
    {
        public int OrderItemId { get; set; }
        public int GameId { get; set; }
        public int OrderId { get; set; }

        public virtual Game Game { get; set; }
        public virtual Order Order { get; set; }
    }
}
