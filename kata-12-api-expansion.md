# Kata 12 – API Expansion

## Objective

Expand upon the basic REST API created in Kata 11 by adding additional endpoints and functionality. This kata will guide you through implementing more complex CRUD operations, including filtering and sorting.

## Prerequisites

Completion of Kata 11, with a basic REST API set up using ASP.NET Core and Entity Framework Core. We will continue to build upon this existing project.

## Steps

### Step 1: Get Employees within a Department

1. Create a new file for DepartmentController.cs in the Controllers folder.
2. Implement a GET endpoint to get a department by its ID.

```csharp
using BasicApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kata12BasicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DepartmentController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartments()
        {
            var departments = await _context.Departments.ToListAsync();
            return Ok(departments);
        }
    }
}
```

3. Implement a GET endpoint to get an individual department by ID:

You can see that there is a parameter added to both the function and the route attribute which expects an ID to be passed in the URL. This will be used to look up the department in the database. If the department is found, it is returned with a 200 OK status; if not, a 404 Not Found status is returned.

```csharp
[HttpGet("{id}")]
public async Task<ActionResult<Department>> GetDepartment(int id)
{
    var department = await _context.Departments.FindAsync(id);
    if (department == null)
    {
        return NotFound();
    }
    return Ok(department);
}
```

4. Implement a GET endpoint to get all employees within a specific department:

```csharp
[HttpGet("{id}/employees")]
public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeesByDepartment(int id)
{
    var department = await _context.Departments
        .Include(d => d.Employees)
        .FirstOrDefaultAsync(d => d.Id == id);
    if (department == null)
    {
        return NotFound();
    }
    return Ok(department.Employees);
}
```

You will see that there is an error for `Employees` as it does not exist on the Department model yet. We will fix this in the next step.

5. Update the Department model to include a collection of Employees:

```csharp
using System.Collections.Generic;
namespace BasicApi.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Employee> Employees { get; set; } = []; // Add this line
    }
}
```

As there is both a reference to `Department` in the Employee model and a reference to `Employee` in the Department model, this creates a bidirectional relationship between the two entities. Which will cause an error when we try to run the application due to circular references during JSON serialization.

To fix this, we can create Data Transfer Objects (DTOs) for both Employee and Department to control what data is sent in the API responses, this will also assist in limiting the information returned from the SQL Database by introducing a WHERE clause, necessary for performance when dealing with large datasets.

6. Create DTOs for Employee and Department:

Create a new folder for DTOs and add the following classes:

```csharp
public class EmployeeDto
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
}

public class DepartmentEmployeeDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public IEnumerable<EmployeeDto> Employees { get; set; } = [];
}
```

7. Update the DepartmentController to use the DTOs:

```csharp
[HttpGet("{id}/employees")]
public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeesByDepartment(int id)
{
    var department = await _context.Departments
        .Include(d => d.Employees)
        .Select(d => new DepartmentEmployeeDto
        {
            Id = d.Id,
            Name = d.Name,
            Employees = d.Employees!.Select(e => new EmployeeDto
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName
            }).ToList()
        })
        .FirstOrDefaultAsync(d => d.Id == id);
    if (department == null)
    {
        return NotFound();
    }
    return Ok(department);
}
```

You will have now build up a query that would return a department along with its employees, but only the selected fields defined in the DTOs, avoiding circular reference issues and improving performance by limiting the data retrieved from the database.

You can view the query that this will execute in your terminal (or debug output in Visual Studio Code). It will look similar to the below. Entity Framework has created a SQL query that joins the Departments and Employees tables, filtering by the department ID provided.

```sql

SELECT [d0].[DepartmentId], [d0].[DepartmentName], [e].[EmployeeId], [e].[FirstName], [e].[LastName]
      FROM (
          SELECT TOP(1) [d].[DepartmentId], [d].[DepartmentName]
          FROM [Departments] AS [d]
          WHERE [d].[DepartmentId] = @__id_0
      ) AS [d0]
      LEFT JOIN [Employees] AS [e] ON [d0].[DepartmentId] = [e].[DepartmentId]
      ORDER BY [d0].[DepartmentId]
```

### Step 2: Sorting Departments By Project Count

Add a new parameter to the GET /api/departments endpoint to allow sorting by the number of projects associated with each department. Add this to the method, but not the route to allow optional sorting.

```csharp

[HttpGet]
public async Task<ActionResult<IEnumerable<Department>>> GetDepartments(string? sortBy = null)
{
    IQueryable<Department> departments = _context.Departments.Include(d => d.Projects);

    if (sortBy == "projectCount")
    {
        departments = departments.OrderByDescending(d => d.Projects.Count);
    }

    return Ok(await departments.Select(d => new DepartmentDto
    {
        Id = d.Id,
        Name = d.Name,
        ProjectCount = d.Projects.Count
    }).ToListAsync());
```

You will see that there is an error for `Projects` as it does not exist on the Department model yet. You should now implement this based on how you added Employees & Departments in Step 1.

_Hint: A Department can have many Projects, so you will need to create a Project model and set up the relationship in both the Department and Project models._

_Hint: Don't forget to update your AppDbContext to include a DbSet for Projects._

_Hint: You will also need to update the GetDepartments endpoint to use a DTO to avoid circular reference issues, similar to what was done in Step 1._

## Further Learning

- Explore adding pagination to the GET endpoints to handle large datasets.
- Implement filtering options for employees, such as filtering by last name or department.
- Add insert, update, and delete endpoints for Departments and Projects. (Learn HTTP Verbs: POST, PUT, DELETE)

## Useful Links

- [ASP.NET Core Documentation](https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-9.0)
- [Entity Framework Core Documentation](https://docs.microsoft.com/en-us/ef/core/)
- [Working with Related Data in EF Core](https://docs.microsoft.com/en-us/ef/core/querying/related-data/)
- [Data Transfer Objects (DTOs) in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/web-api/?view=aspnetcore-9.0#use-dtos-to-protect-your-entities)
- [Sorting and Filtering in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/sort-filter-page?view=aspnetcore-9.0)
- [LINQ Documentation](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/)
- [Understanding JSON Serialization in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/web-api/advanced/formatting?view=aspnetcore-9.0#json-serialization)
