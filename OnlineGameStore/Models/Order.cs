using System;
using System.Collections.Generic;

namespace OnlineGameStore.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderItem = new HashSet<OrderItem>();
        }

        public int OrderId { get; set; }
        public int AccountId { get; set; }
        public decimal SubTotal { get; set; }
        public DateTime Date { get; set; }
        public decimal Discount { get; set; }
        public bool IsProcessed { get; set; }

        public virtual Account Account { get; set; }
        public virtual ICollection<OrderItem> OrderItem { get; set; }
    }
}
