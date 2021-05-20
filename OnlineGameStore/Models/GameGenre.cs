using System;
using System.Collections.Generic;

namespace OnlineGameStore.Models
{
    public partial class GameGenre
    {
        public GameGenre()
        {
            Game = new HashSet<Game>();
        }

        public int GameGenreId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Game> Game { get; set; }
    }
}
