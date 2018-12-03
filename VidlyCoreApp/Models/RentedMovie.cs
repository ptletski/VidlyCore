using System;
using System.ComponentModel.DataAnnotations;

namespace VidlyCoreApp.Models
{
    public class RentedMovie
    {
        public RentedMovie()
        {
        }

        [Key]
        public int RentalTransactionId { get; set; }
        public int MovieId { get; set; }
    }
}
