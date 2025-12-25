using System.ComponentModel.DataAnnotations;

public class AgeValidation : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if(value!=null && (int)value > 18)
        {
            return ValidationResult.Success;
        }
        else
        {
            return new ValidationResult("age should be greater than 18");
        }
    }
}