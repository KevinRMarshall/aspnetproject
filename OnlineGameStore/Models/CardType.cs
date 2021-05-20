using System;
using System.Collections.Generic;

namespace OnlineGameStore.Models
{
    public partial class CardType
    {
        public CardType()
        {
            CreditCard = new HashSet<CreditCard>();
        }

        public int CardTypeId { get; set; }
        public string CardType1 { get; set; }

        public virtual ICollection<CreditCard> CreditCard { get; set; }
    }
}
