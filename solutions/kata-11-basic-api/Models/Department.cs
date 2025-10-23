using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasicApi.Models;

public class Department
{
    [Key, Column("DepartmentId")]
    public int Id { get; set; }
    [Column("DepartmentName")]
    public required string Name { get; set; }
}
