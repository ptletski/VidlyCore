using System;
using System.Diagnostics;
using System.ComponentModel.DataAnnotations;
using VidlyCoreApp.Models;

namespace VidlyCoreApp.ViewModels
{
    public class ContentProviderTypeValidation : ValidationAttribute
    {
        public ContentProviderTypeValidation()
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                var movie = (MovieFormViewModel)validationContext.ObjectInstance;

                return (movie.MovieGenreId == ContentProvider.Prompt)
                    ? new ValidationResult("Select Content Provider")
                    : ValidationResult.Success;
            }
            catch (Exception exception)
            {
                Debug.Assert(false, "ContentProviderTypeValidation use is relegated to MovieFormViewModel");
                Debug.Assert(false, exception.Message);
            }

            return new ValidationResult("Attribute usage applies only to type MovieFormViewModel");
        }
    }
}
