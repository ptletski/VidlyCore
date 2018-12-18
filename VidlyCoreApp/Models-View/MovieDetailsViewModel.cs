using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.Extensions.Logging;
using VidlyCoreApp.Models;

namespace VidlyCoreApp.ViewModels
{
    public class MovieDetailsViewModel : CommonViewModel
    {
        private Movie _movie;

        public MovieDetailsViewModel(ILogger logger) : base(logger)
        {
        }

        public bool Initialize(int movieId)
        {
            try
            {
                _movie = _dbContext.Movies.Find(movieId);

                return (_movie != null);
            }
            catch (Exception exception)
            {
                string message = $"Failure Finding Movie By Id={movieId}.";

                Debug.Assert(false, message);
                Debug.Assert(false, exception.Message);

                Logger.LogError(exception, message, null);

                throw;
            }
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
            catch (Exception exception)
            {
                string message = "MovieDetailsViewModel Failed in Finding GetGenreName";

                Debug.Assert(false, message);
                Debug.Assert(false, exception.Message);

                Logger.LogError(exception, message, null);
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
            catch (Exception exception)
            {
                string message = "MovieDetailsViewModel Failed In Finding GetMpaRating";

                Debug.Assert(false, message);
                Debug.Assert(false, exception.Message);

                Logger.LogError(exception, message, null);
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
            catch (Exception exception)
            {
                string message = "MovieDetailsViewModel Failed In Finding GetLicenseCount";

                Debug.Assert(false, message);
                Debug.Assert(false, exception.Message);

                Logger.LogError(exception, message, null);
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
