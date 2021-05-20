using System;
using System.Collections.Generic;

namespace OnlineGameStore.Models
{
    public partial class BillingProvinceState
    {
        public BillingProvinceState()
        {
            CreditCard = new HashSet<CreditCard>();
        }

        public int ProvinceStateId { get; set; }
        public string Name { get; set; }
        public decimal TaxModifier { get; set; }
        public int CountryId { get; set; }

        public virtual BillingCountry Country { get; set; }
        public virtual ICollection<CreditCard> CreditCard { get; set; }
    }
}
