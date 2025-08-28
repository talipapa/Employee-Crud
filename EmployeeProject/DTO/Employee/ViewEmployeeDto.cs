using EmployeeProject.Implements;

namespace EmployeeProject.DTO.Employee
{
    public class ViewEmployeeDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public string? Suffix { get; set; }
        public string Position { get; set; }
        public decimal MonthlyRate { get; set; }
        public DateTime OnBoardDate { get; set; }

    }
}
