using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SourceControlFinalAssignment.CustomValidations
{
    public class CountryAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid
    (object value, ValidationContext validationContext)
        {
            string country = value.ToString();

            if (country != "USA" && country != "UK" && country != "India")
            {
                return new ValidationResult("Invalid country. Valid values are USA, UK, and India.");
            }
            return ValidationResult.Success;
        }
    }
}