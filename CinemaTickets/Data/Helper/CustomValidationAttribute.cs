using System.ComponentModel.DataAnnotations;

namespace CinemaTickets.Data.Helper
{
    public class CustomValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            if(value != null)
            {
                string Name = value.ToString();
                if (Name.Contains(""))
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult("The Name dosn't contain desired value");


        }
    }
}
