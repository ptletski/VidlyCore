using System;
using System.ComponentModel.DataAnnotations;

namespace VidlyCoreApp.Models
{
    public class ContentProvider
    {   // Only used in data-seeding. See Migrations.
        public static readonly byte Prompt = 0;
        public static readonly byte SonyMotionPictures = 1;
        public static readonly byte UnitedArtists = 2;
        public static readonly byte TwentiethCenturyFox = 3;
        public static readonly byte ColumbiaPictures = 4;
        public static readonly byte DisneyMotionPictures = 5;
        public static readonly byte MetroGoldwinMayer = 6;

        public ContentProvider()
        {
        }

        public string ContentProviderName { get; set; }
        public string ContractReference { get; set; }

        [Key]
        public int ContentProviderId { get; set; }
    }
}
