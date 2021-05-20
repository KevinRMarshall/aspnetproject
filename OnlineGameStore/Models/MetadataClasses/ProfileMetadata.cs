using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGameStore.Models
{
    [ModelMetadataType(typeof(ProfileMetadata))]
    public partial class Profile {}
    public class ProfileMetadata : IValidatableObject
    {
        public int ProfileId { get; set; }
        public int AccountId { get; set; }
        [Display(Name ="Display Name")]
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Display Name should be between 3-50 characters.")]
        public string ProfileName { get; set; }
        [Display(Name ="Brief Description")]
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Brief Description should be between 3-50 characters.")]
        public string ProfileDescription { get; set; }
        public bool? Gender { get; set; }
        [Display(Name = "Favourite Game Genre")]
        public string FavouriteGameCategory { get; set; }
        [Display(Name = "Favourite Platform")]
        public string FavouritePlatform { get; set; }
        [Display(Name = "Do you prefer paid games?")]
        public bool PaidOrFree { get; set; }
        [Display(Name = "Country Code")]
        [Required]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "Country Code should be between 2 to 10 characters.")]
        public string Country { get; set; }
        [DataType(DataType.Date)]
        [Required]
        [Display(Name = "Birth date")]
        public DateTime Birthdate { get; set; }
        [Display(Name = "Parental Code")]
        public string ParentalCode { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }


        //Verify that birthdate is not in the future
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.Birthdate > DateTime.Now)
            {
                yield return new ValidationResult("Birthday must not be in the future.", new[] { "Birthdate" });
            }
        }
    }

    
}
