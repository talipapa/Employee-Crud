using System.ComponentModel.DataAnnotations;

namespace EmployeeProject.Validation
{
    public class OnboardingDateAttribute : ValidationAttribute
    {
        public OnboardingDateAttribute()
        {
            ErrorMessage = "The employee's start date must be today or a past date.";
        }

        public override bool IsValid(object? value)
        {
            if (value is DateTime dateValue)
            {
                return dateValue <= DateTime.Today;
            }
            return false;
        }
    }
}
