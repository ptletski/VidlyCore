using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.Extensions.Logging;
using VidlyCoreApp.Models;

namespace VidlyCoreApp.ViewModels
{
    public class MoviesViewModel : CommonViewModel
    {
        public MoviesViewModel(ILogger logger) : base(logger)
        {
        }

        public IEnumerable<Movie> Movies
        {
            get
            {
                try
                {
                    return _dbContext.Movies;
                }
                catch (Exception exception)
                {
                    string message = "Failure listing Customers.";

                    Debug.Assert(false, message);
                    Debug.Assert(false, exception.Message);

                    Logger.LogError(exception, message, null);

                    throw;
                }
            }
        }

        public bool IsAny
        {
            get
            {
                bool isAny = false;

                try
                {
                    isAny = Movies.ToList().Any();
                }
                catch (Exception exception)
                {
                    string message = "Could Not Perform IsAny Check on Movies";
                    Debug.Assert(false, message);
                    Debug.Assert(false, exception.Message);

                    Logger.LogError(exception, message, null);
                }

                return isAny;
            }
        }

        public Movie Find(int id)
        {
            Movie movie = null;

            try
            {
                movie = _dbContext.Movies.Find(id);
            }
            catch (Exception exception)
            {
                string message = "Failure Finding Movie by Id";

                Debug.Assert(false, message);
                Debug.Assert(false, exception.Message);

                Logger.LogError(exception, message, null);
            }

            return movie;
        }

        public string GetGenreName(Movie movie)
        {
            string name = "";

            try
            {
                byte genreId = movie.MovieGenreId;
                name = _dbContext.MovieGenres.Find(genreId).MovieGenreName;
            }
            catch (Exception exception)
            {
                string message = "Failure Finding MovieGenres";

                Debug.Assert(false, message);
                Debug.Assert(false, exception.Message);

                Logger.LogError(exception, message, null);
            }

            return name;
        }
    }
}
