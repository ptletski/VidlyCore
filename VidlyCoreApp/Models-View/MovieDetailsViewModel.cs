using System;
using System.Diagnostics;
using System.Linq;
using VidlyCoreApp.Models;

namespace VidlyCoreApp.ViewModels
{
    public class MovieDetailsViewModel : CommonViewModel
    {
        private Movie _movie;

        public MovieDetailsViewModel() : base()
        {
        }

        public bool Initialize(int movieId)
        {
            _movie = _dbContext.Movies.SingleOrDefault(m => m.MovieId == movieId);

            return (_movie == null) ? false : true;
        }

        public string GetTitle()
        {
            return _movie.Title;
        }

        public string GetGenreName()
        {
            string name = "";

            try
            {
                byte genreId = _movie.MovieGenreId;
                name = _dbContext.MovieGenres.Find(genreId).MovieGenreName;
            }
            catch (Exception e)
            {
                Debug.Assert(false, "MovieDetailsViewModel Failed in Finding GetGenreName");
                Debug.Assert(false, e.Message);
            }

            return name;
        }

        public string GetMpaRating()
        {
            string name = "";

            try
            {
                byte mpaRatingId = _movie.MpaRatingId;
                name = _dbContext.MpaRatings.Find(mpaRatingId).MpaRatingName;
            }
            catch (Exception e)
            {
                Debug.Assert(false, "MovieDetailsViewModel Failed In Finding GetMpaRating");
                Debug.Assert(false, e.Message);
            }

            return name;
        }

        public int GetYear()
        {
            return _movie.Year;
        }

        public string GetDateAdded()
        {
            DateTime dateTime = _movie.DateAdded;
            return dateTime.ToShortDateString();
        }

        public int GetLicenseCount()
        {
            int count = 0;

            try
            {
                int inventoryId = _movie.InventoryControlId;
                var inventory = _dbContext.InventoryControl.Find(inventoryId);
                count = inventory.PermittedUsageCount;
            }
            catch (Exception e)
            {
                Debug.Assert(false, "MovieDetailsViewModel Failed In Finding GetLicenseCount");
                Debug.Assert(false, e.Message);
            }

            return count;
        }

        public int GetMovieId()
        {
            return _movie.MovieId;
        }

        public int GetInventoryControlId()
        {
            return _movie.InventoryControlId;
        }
    }
}
