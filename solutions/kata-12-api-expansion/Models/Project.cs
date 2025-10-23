using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BasicApi.Models;

namespace Kata12BasicAPI.Models;

public class Project
{
    [Key, Column("ProjectId")]
    public int Id { get; set; }
    [Column("ProjectName")]
    public string Name { get; set; } = string.Empty;
    public int DepartmentId { get; set; }
    [ForeignKey("DepartmentId")]
    public Department? Department { get; set; }
}
