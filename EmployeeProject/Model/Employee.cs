using EmployeeProject.Implements;

namespace EmployeeProject.Model
{
    public class Employee : IFullName
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public  string? MiddleName { get; set; }
        public required string LastName { get; set; }
        public string? Suffix { get; set; }
        public required string Position { get; set; }
        public decimal MonthlyRate { get; set; }
        public DateTime OnBoardDate { get; set; } = DateTime.UtcNow;
        public string GetFullName(bool initialMiddle)
        {
            List<string> nameParts = new List<string>();
            nameParts.Add(FirstName);
            if (!string.IsNullOrWhiteSpace(MiddleName))
            {
                if (initialMiddle)
                {
                    nameParts.Add(MiddleName![0] + ".");
                }
                else
                {
                    nameParts.Add(MiddleName);
                }
            }
            nameParts.Add(LastName);
            if (!string.IsNullOrWhiteSpace(Suffix))
            {
                nameParts.Add(Suffix);
            }
            return string.Join(" ", nameParts);
        }

    }
}
