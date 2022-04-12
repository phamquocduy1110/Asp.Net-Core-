using System;
using System.ComponentModel.DataAnnotations;

namespace NhatNgheDay01Demo.Models
{
    internal class CheckBirthdateAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            try
            {
                var myBirthdate = (DateTime)value!;
                if (DateTime.Now.Year - myBirthdate.Year < 10)
                {
                    return new ValidationResult("Không đủ tuổi làm việc");
                }
                return ValidationResult.Success;
            }
            catch
            {
                return new ValidationResult("Invalid datetime");
            }
        }
    }
}