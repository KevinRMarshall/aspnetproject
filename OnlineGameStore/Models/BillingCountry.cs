using System;
using System.Collections.Generic;

namespace OnlineGameStore.Models
{
    public partial class BillingCountry
    {
        public BillingCountry()
        {
            BillingProvinceState = new HashSet<BillingProvinceState>();
            CreditCard = new HashSet<CreditCard>();
        }

        public int CountryId { get; set; }
        public string Name { get; set; }
        public decimal TaxModifier { get; set; }

        public virtual ICollection<BillingProvinceState> BillingProvinceState { get; set; }
        public virtual ICollection<CreditCard> CreditCard { get; set; }
    }
}
