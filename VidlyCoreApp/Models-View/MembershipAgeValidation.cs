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
                var customer = (CustomerFormViewModel)validationContext.ObjectInstance;
                MembershipAgeRequirements ageRequirements = new MembershipAgeRequirements();
                BusinessRulesResult rulesResult = ageRequirements.IsCustomerAgeAcceptable(customer.MembershipTypeId, customer.BirthDate);

                return (rulesResult.IsErrored == true) 
                    ? new ValidationResult(rulesResult.ErrorMessage)
                    : ValidationResult.Success;

            }
            catch(Exception exception)
            {
                Debug.Assert(false, "MembershipAgeValidation use is relegated to CustomerFormViewModel");
                Debug.Assert(false, exception.Message);
            }

            return new ValidationResult("Attrbiute usage applies only to type CustomerFormViewModel");
        }
    }
}
