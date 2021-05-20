using System;
using System.Collections.Generic;

namespace OnlineGameStore.Models
{
    public partial class Profile
    {
        public int ProfileId { get; set; }
        public int AccountId { get; set; }
        public string ProfileName { get; set; }
        public string ProfileDescription { get; set; }
        public string Gender { get; set; }
        public string FavouriteGameCategory { get; set; }
        public string FavouritePlatform { get; set; }
        public bool? PaidOrFree { get; set; }
        public string Country { get; set; }
        public DateTime Birthdate { get; set; }
        public string ParentalCode { get; set; }
        public string PhoneNumber { get; set; }

        public virtual Account Account { get; set; }
    }
}
