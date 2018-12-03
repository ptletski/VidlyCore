using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using VidlyCoreApp.Models;

namespace VidlyCoreApp.ViewModels
{
    public class MpaRatingTypeValidation : ValidationAttribute
    {
        public MpaRatingTypeValidation()
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                var movie = (MovieFormViewModel)validationContext.ObjectInstance;

                return (movie.MovieGenreId == MpaRating.Prompt)
                    ? new ValidationResult("Select MPA Rating")
                    : ValidationResult.Success;
            }
            catch (Exception exception)
            {
                Debug.Assert(false, "MpaRatingTypeValidation use is relegated to MovieFormViewModel");
                Debug.Assert(false, exception.Message);
            }

            return new ValidationResult("Attribute usage applies only to type MovieFormViewModel");
        }
    }
}
