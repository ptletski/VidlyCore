using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using VidlyCoreApp.BusinessRules;

namespace VidlyCoreApp.ViewModels
{
    public class MembershipAgeValidation : ValidationAttribute
    {
        public MembershipAgeValidation()
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                CustomerFormViewModel customer = (CustomerFormViewModel)validationContext.ObjectInstance;
                MembershipAgeRequirements ageRequirements = new MembershipAgeRequirements();
                BusinessRulesResult rulesResult = ageRequirements.IsCustomerAgeAcceptable(customer.MembershipTypeId, customer.BirthDate);

                return (rulesResult.IsErrored == true) 
                    ? new ValidationResult(rulesResult.ErrorMessage)
                    : ValidationResult.Success;

            }
            catch (InvalidCastException exception)
            {
                string message = "MembershipAgeValidation use is relegated to CustomerFormViewModel.";

                Debug.Assert(false, message);
                Debug.Assert(false, exception.Message);

                throw new ValidationException(message);
            }
            catch (Exception exception)
            {
                Debug.Assert(false, "MembershipAgeValidation unknown exception.");
                Debug.Assert(false, exception.Message);

                throw;
            }
        }
    }
}
