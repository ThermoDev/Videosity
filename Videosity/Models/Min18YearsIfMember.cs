using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace Videosity.Models {
    public class Min18YearsIfMember : ValidationAttribute {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
            var customer = (Customer) validationContext.ObjectInstance;

            // If the customer has PAYG
            if(customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PayAsYouGo) {
                // Returns a success using the static member variable.
                return ValidationResult.Success;
            }
            if(customer.BirthDate == null) {
                // Return an error with a ValidationResult message.
                return new ValidationResult("Birthdate is required.");
            }

            var age = DateTime.Today.Year - customer.BirthDate.Value.Year;

            return (age >= 18) ? ValidationResult.Success : new ValidationResult("Customer should be at least 18 years old to be on a membership.");
        }
    }
}