using System.ComponentModel.DataAnnotations;
using WebAPI_ModelBinding_Validation;
using WebAPI_ModelBinding_Validation.Attributes;

namespace WebAPI_ModelBinding_Validation.Models
{
    public class Employee
    {
        [Required]
        public int Id { get; set; }

        [ValidName]
        [StringLength(40,MinimumLength =3,ErrorMessage ="Name should be in between 3 and 40 characters")]
        public string Name { get; set; }
        [AgeValidation]
        public int Age {  get; set; }
        [EmailAddress(ErrorMessage ="Email address should be in correct format")]
        public string EmailAddress { get; set; }
        
        public decimal Salary {  get; set; }
    }
}
