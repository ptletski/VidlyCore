using System;
using System.ComponentModel.DataAnnotations;

namespace VidlyCoreApp.Models
{
    public class MpaRating
    {
        public static readonly byte Prompt = 0;
        public static readonly byte G = 1;
        public static readonly byte PG = 2;
        public static readonly byte PG13 = 3;
        public static readonly byte R = 4;
        public static readonly byte X = 5;
        public static readonly byte NR = 6;

        public MpaRating()
        {
        }

        public string MpaRatingName { get; set; }

        [Key]
        public byte MpaRatingId { get; set; }
    }
}
