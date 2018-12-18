using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using VidlyCoreApp.Models;

namespace VidlyCoreApp.ViewModels
{
    public class MpaRatingTypeValidation : ValidationAttribute
    {
        public MpaRatingTypeValidation() : base()
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                var movie = (MovieFormViewModel)validationContext.ObjectInstance;

                return (movie.MpaRatingId == MpaRating.Prompt)
                    ? new ValidationResult("Select MPA Rating")
                    : ValidationResult.Success;
            }
            catch (InvalidCastException exception)
            {
                string message = "MpaRatingTypeValidation use is relegated to MovieFormViewModel.";

                Debug.Assert(false, message);
                Debug.Assert(false, exception.Message);

                throw new ValidationException(message);
            }
            catch (Exception exception)
            {
                Debug.Assert(false, "MpaRatingTypeValidation uknown exception.");
                Debug.Assert(false, exception.Message);

                throw;
            }
        }
    }
}
