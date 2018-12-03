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
                var movie = (MovieFormViewModel)validationContext.ObjectInstance;

                return (movie.MovieGenreId == MovieGenre.Prompt)
                    ? new ValidationResult("Select a Genre")
                    : ValidationResult.Success;
            }
            catch (Exception exception)
            {
                Debug.Assert(false, "MovieGenreTypeValidation use is relegated to MovieFormViewModel");
                Debug.Assert(false, exception.Message);
            }

            return new ValidationResult("Attribute usage applies only to type MovieFormViewModel");
        }
    }
}
