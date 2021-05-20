using System;
using System.Collections.Generic;

namespace OnlineGameStore.Models
{
    public partial class CreditCard
    {
        public int CreditId { get; set; }
        public int AccountId { get; set; }
        public int CardTypeId { get; set; }
        public decimal CardNumber { get; set; }
        public decimal CardCode { get; set; }
        public DateTime ExpireDate { get; set; }
        public string CardHolder { get; set; }
        public string BillingAddress { get; set; }
        public string BillingPhone { get; set; }
        public int CountryId { get; set; }
        public int ProvinceStateId { get; set; }

        public virtual Account Account { get; set; }
        public virtual CardType CardType { get; set; }
        public virtual BillingCountry Country { get; set; }
        public virtual BillingProvinceState ProvinceState { get; set; }
    }
}
