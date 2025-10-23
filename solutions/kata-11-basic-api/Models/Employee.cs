using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasicApi.Models;

public class Employee
{
    [Key, Column("EmployeeId")]
    public int Id { get; set; }
    [Column("FirstName")]
    public required string FirstName { get; set; }
    [Column("LastName")]
    public required string LastName { get; set; }

    public int DepartmentId { get; set; }
    [ForeignKey("DepartmentId")]
    public Department? Department { get; set; }
}