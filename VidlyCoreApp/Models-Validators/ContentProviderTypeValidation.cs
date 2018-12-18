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
                MovieFormViewModel movie = (MovieFormViewModel)validationContext.ObjectInstance;

                return (movie.ContentProviderId == ContentProvider.Prompt)
                    ? new ValidationResult("Select Content Provider")
                    : ValidationResult.Success;
            }
            catch(InvalidCastException exception)
            {
                string message = "ContentProviderTypeValidation use is relegated to MovieFormViewModel.";

                Debug.Assert(false, message);
                Debug.Assert(false, exception.Message);

                throw new ValidationException(message);
            }
            catch (Exception exception)
            {
                Debug.Assert(false, "ContentProviderTypeValidation unknown exception.");
                Debug.Assert(false, exception.Message);

                throw;
            }
        }
    }
}
