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
                var customer = (CustomerFormViewModel)validationContext.ObjectInstance;

                return (customer.MembershipTypeId == MembershipType.Prompt)
                    ? new ValidationResult("Select a Membership")
                    : ValidationResult.Success;
            }
            catch (Exception exception)
            {
                Debug.Assert(false, "MembershipTypeValidation use is relegated to CustomerFormViewModel");
                Debug.Assert(false, exception.Message);
            }

            return new ValidationResult("Attribute usage applies only to type CustomerFormViewModel");
        }
    }
}
