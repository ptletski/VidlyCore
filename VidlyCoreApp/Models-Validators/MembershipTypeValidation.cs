using System;
using System.Diagnostics;
using System.ComponentModel.DataAnnotations;
using VidlyCoreApp.Models;

namespace VidlyCoreApp.ViewModels
{
    public class MembershipTypeValidation : ValidationAttribute
    {
        public MembershipTypeValidation()
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                CustomerFormViewModel customer = (CustomerFormViewModel)validationContext.ObjectInstance;

                return (customer.MembershipTypeId == MembershipType.Prompt)
                    ? new ValidationResult("Select a Membership")
                    : ValidationResult.Success;
            }
            catch (InvalidCastException exception)
            {
                string message = "MembershipTypeValidation use is relegated to CustomerFormViewModel.";

                Debug.Assert(false, message);
                Debug.Assert(false, exception.Message);

                throw new ValidationException(message);
            }
            catch (Exception exception)
            {
                Debug.Assert(false, "MembershipTypeValidation unknown exception.");
                Debug.Assert(false, exception.Message);

                throw;
            }
        }
    }
}
