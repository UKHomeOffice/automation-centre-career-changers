using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Kata12BasicAPI.Models;

namespace BasicApi.Models;

public class Department
{
    [Key, Column("DepartmentId")]
    public int Id { get; set; }
    [Column("DepartmentName")]
    public required string Name { get; set; }
    public ICollection<Employee> Employees { get; set; } = [];
    public ICollection<Project> Projects { get; internal set; } = [];
}
