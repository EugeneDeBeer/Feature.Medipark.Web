using System;
using System.ComponentModel.DataAnnotations;

namespace Feature.OHS.Web.Helper
{
    public class IdNumberAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var id = value.ToString();
            if (id.Length == 11 && int.TryParse(id, out int n))

                return ValidationResult.Success;
            else
                return new ValidationResult("Id Number suppose to be 11 digits");
        }

    }
}