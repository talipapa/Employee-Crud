using EmployeeProject.Validation;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace EmployeeProject.DTO.Employee
{
    public class UpdateEmployeeDto
    {
        [Required]
        public required string FirstName { get; set; }
        
        [Required]
        public string? MiddleName { get; set; }
        
        [Required]
        public required string LastName { get; set; }
        public string? Suffix { get; set; }
        
        [Required]
        public required string Position { get; set; }

        [Required]
        [Range(10000, int.MaxValue, ErrorMessage = "A value must be above 10000")]
        public decimal MonthlyRate { get; set; }

        [Required]
        //[OnboardingDate(ErrorMessage = "The employee's start date must be today or a past date.")]
        public DateTime OnBoardDate { get; set; } = DateTime.UtcNow;


    }
}
