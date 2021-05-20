using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace OnlineGameStore.Models
{
    [ModelMetadataType(typeof(GameMetadata))]
    public partial class Game {}
    public class GameMetadata
    {
        public int GameId { get; set; }
        [Display(Name = "Game Name")]
        public string GameName { get; set; }
        [Display(Name = "Game Description")]
        public string GameDescription { get; set; }
        [Display(Name = "Upload Game")]
        public string GameDownloadLink { get; set; }
        [Display(Name = "Price")]
        public decimal GamePrice { get; set; }
        [Display(Name = "Discount")]
        public string GameDiscount { get; set; }
        [Display(Name = "Game Genre")]
        public int GameGenreId { get; set; }

    }
}
