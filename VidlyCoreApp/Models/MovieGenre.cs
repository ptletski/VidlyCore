using System;
using System.ComponentModel.DataAnnotations;

namespace VidlyCoreApp.Models
{
    public class MovieGenre
    {
        public static readonly byte Prompt = 0;
        public static readonly byte Comedy = 1;
        public static readonly byte Action = 2;
        public static readonly byte Family = 3;
        public static readonly byte Romance = 4;
        public static readonly byte Suspense = 5;
        public static readonly byte Documentary = 6;
        public static readonly byte Drama = 7;

        public MovieGenre()
        {
        }

        public string MovieGenreName { get; set; }

        [Key]
        public byte MovieGenreId { get; set; }
    }
}
