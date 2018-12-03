using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VidlyCoreApp.Models
{
    public class RentalTransaction
    {
        //       private List<Movie> _movieList = null;
        //       _movieList = new List<Movie>();

        public RentalTransaction()
        {

        }

        [Key]
        public int RentalTransactionId { get; set; }

        public int CustomerId { get; set; }

        public int RentedMoviesId { get; set; }

        /*
                public Customer Customer;
                public IEnumerable<Movie> MoviesRented { get => _movieList; }

                public void Add(Movie movie)
                {
                    _movieList.Add(movie);
                }
        */
    }
}
