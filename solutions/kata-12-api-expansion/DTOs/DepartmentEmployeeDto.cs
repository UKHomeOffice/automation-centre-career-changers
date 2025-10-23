namespace Kata12BasicAPI.DTOs;

public class DepartmentEmployeeDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public IEnumerable<EmployeeDto> Employees { get; set; } = [];
}