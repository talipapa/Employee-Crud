namespace EmployeeProject.Implements
{
    public interface IFullName
    {
        string GetFullName(bool initialMiddle);
        string FirstName { get; set; }
        string? MiddleName { get; set; }
        string LastName { get; set; }
        string? Suffix { get; set; }
    }
}
