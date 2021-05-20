using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace OnlineGameStore.Models
{
    [ModelMetadataType(typeof(CreditCardMetadata))]
    public partial class CreditCard { }
    public class CreditCardMetadata : IValidatableObject
    {
        public int CreditId { get; set; }
        public int AccountId { get; set; }
        public int CardTypeId { get; set; }
        [Display(Name = "CardNumber")]
        [Required(ErrorMessage = "Required")]
        [Range(100000000000, 9999999999999999999, ErrorMessage = "must be between 12 and 19 digits")]
        public decimal CardNumber { get; set; }
        [Display(Name = "CardCode")]
        [Required(ErrorMessage = "Required")]
        [RegularExpression(@"^([0-9]{3,4})$", ErrorMessage = "Not a valid CVV Please Have 3-4 Numbers")]
        public decimal CardCode { get; set; }
        [DataType(DataType.DateTime), DisplayFormat(DataFormatString = "{0:MM/yy}", ApplyFormatInEditMode = true)]
        public DateTime ExpireDate { get; set; }
        [Display(Name = "CardHolder")]
        [Required(ErrorMessage = "Required")]
        public string CardHolder { get; set; }
        [Display(Name = "BillingAddress")]
        [Required(ErrorMessage = "Required")]
        public string BillingAddress { get; set; }
        [Display(Name = "BillingPhone")]
        [Required(ErrorMessage = "Required")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string BillingPhone { get; set; }
        public int CountryId { get; set; }
        public int ProvinceStateId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.ExpireDate.Month <= DateTime.Now.Month && this.ExpireDate.Year <= DateTime.Now.Year)
            {
                yield return new ValidationResult("Card is expired.", new[] { "ExpireDate" });
            }


        }

   
    }
}
