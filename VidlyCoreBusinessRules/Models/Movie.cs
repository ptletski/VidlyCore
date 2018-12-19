using System;
using System.ComponentModel.DataAnnotations;

namespace VidlyCoreApp.Models
{
    public class Movie
    {
        public Movie()
        {
        }

        public string Title { get; set; }
        public int Year { get; set; }
        public byte MpaRatingId { get; set; }
        public byte MovieGenreId { get; set; }
        public DateTime DateAdded { get; set; }
        public int ActiveUseCount { get; set;  }
        public int InventoryControlId { get; set; }

        [Key]
        public int MovieId { get; set; }
    }
}
