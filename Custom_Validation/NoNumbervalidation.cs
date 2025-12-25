using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace WebAPI_ModelBinding_Validation.Attributes
{
    public class ValidNameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // Check if name is null or empty
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                return new ValidationResult("Name is required.");
            }

            string name = value.ToString();

            // Check if name contains any digits
            if (name.Any(c => char.IsDigit(c)))
            {
                return new ValidationResult("Name should not contain numbers.");
            }
            //foreach (char ch in name)
            //{
            //    if (char.IsDigit(ch))
            //    {
            //        return new ValidationResult("Name should not contain numbers.");
            //    }
            //}

            // Check if name contains any special characters
            if (!name.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
            {
                return new ValidationResult("Name should contain only letters and spaces.");
            }

            // Passed all validations
            return ValidationResult.Success;
        }
    }
}
