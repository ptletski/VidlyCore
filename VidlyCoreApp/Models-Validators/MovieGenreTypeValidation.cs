using System;
using System.Diagnostics;
using System.ComponentModel.DataAnnotations;
using VidlyCoreApp.Models;

namespace VidlyCoreApp.ViewModels
{
    public class MovieGenreTypeValidation : ValidationAttribute
    {
        public MovieGenreTypeValidation()
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                MovieFormViewModel movie = (MovieFormViewModel)validationContext.ObjectInstance;

                return (movie.MovieGenreId == MovieGenre.Prompt)
                    ? new ValidationResult("Select a Genre")
                    : ValidationResult.Success;
            }
            catch (InvalidCastException exception)
            {
                string message = "MovieGenreTypeValidation use is relegated to MovieFormViewModel.";

                Debug.Assert(false, message);
                Debug.Assert(false, exception.Message);

                throw new ValidationException(message);
            }
            catch (Exception exception)
            {
                Debug.Assert(false, "MovieGenreTypeValidation unknown exception.");
                Debug.Assert(false, exception.Message);

                throw;
            }
        }
    }
}
