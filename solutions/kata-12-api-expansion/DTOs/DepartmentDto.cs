using System;

namespace Kata12BasicAPI.DTOs;

public class DepartmentDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int ProjectCount { get; set; }
    public int EmployeeCount { get; set; }
}
