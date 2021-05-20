using System;
using System.Collections.Generic;

namespace OnlineGameStore.Models
{
    public partial class Review
    {
        public int ReviewId { get; set; }
        public int GameId { get; set; }
        public int ProfileId { get; set; }
        public string ReviewTitle { get; set; }
        public string ReviewText { get; set; }
        public bool IsRecommended { get; set; }

        public virtual Game Game { get; set; }
    }
}
