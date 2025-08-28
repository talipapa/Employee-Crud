using EmployeeProject.Validation;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace EmployeeProject.DTO.Employee
{
    public class PartialUpdateEmployeeDto
    {
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? Suffix { get; set; }
        public string? Position { get; set; }
        [Range(10000, int.MaxValue, ErrorMessage = "A value must be above 10000")]
        public decimal? MonthlyRate { get; set; }
        //[OnboardingDate(ErrorMessage = "The employee's start date must be today or a past date.")]
        public DateTime? OnBoardDate { get; set; } = DateTime.UtcNow;


    }
}
