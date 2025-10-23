# Kata 11 - Basic API Integration

## Objective

Learn how to create a basic REST API using the database created in your previous SQL katas. This kata will guide you through setting up a simple API using ASP.NET Core and Entity Framework Core to perform CRUD operations on your SQL database.

This kata will also introduce you to Linq for querying data and handling HTTP requests and responses.

## Prerequisites

- Completion of Kata 9 and Kata 10, with a SQL Server instance and database set up.
- Installation of Bruno from Step 1

## Steps

### 1. Create a New ASP.NET Core Web API Project

Create a new folder for this kata and navigate into it:

1. Open a terminal and navigate to your working directory.

   ```bash
   mkdir -p _dev/kata-11-rest-api && cd _dev/kata-11-rest-api
   ```

2. Run the following command to create a new .NET console app:

   ```bash
   dotnet new webapi -n BasicApi
   ```

3. Navigate into the newly created project folder:

   ```bash
   cd BasicApi
   ```

4. Open the project in Visual Studio Code:

   ```bash
   code .
   ```

### 2. Set Up Entity Framework Core

1. Inside Visual Studio Code - Install the necessary NuGet packages for Entity Framework Core.

To increase speed over previous katas, we will use the terminal to install the packages into the project:

Ensure that you are in your project directory where the `.csproj` file is located.

```bash
cd ~/_dev/kata-11-rest-api/BasicApi
```

```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
```

2. Update the launchSettings.json to confiugure the application port. We have removed the http profile, and updated the url's to point to port 5000, and 5001 for simplicity.

```json
{
  "$schema": "https://json.schemastore.org/launchsettings.json",
  "profiles": {
    "https": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": false,
      "applicationUrl": "https://localhost:5000;http://localhost:5001",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    }
  }
}
```

3. Add your connection string to the `appsettings.json` file.

_Unlike previous katas, we will be keeping the connection string in the appsettings.json rather than referencing it directly within the code._

```json
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=Kata9DB;User Id=sa;Password=DevPassword1;TrustServerCertificate=True;"
}
```

### 3. Create the Data Models and DbContext

1. Create a new folder named `Models` in your project directory.
2. Inside the `Models` folder, create two new C# files: `Employee.cs` and `Department.cs`.

```csharp
// Employee.cs
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
```

```csharp
// Department.cs
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
```

You will notice that these classes are quite simple and only contain properties that map directly to the database columns. This is a common practice in Entity Framework Core, where you create plain C# classes (also known as POCOs - Plain Old CLR Objects) to represent your data models.

We are also using Data Annotations to specify primary keys,foreign keys amd column names, which helps Entity Framework Core understand the relationships between the tables.

### 4. Create the DbContext

1. In the `Models` folder, create a new C# file named `AppDbContext.cs`.

```csharp
using Microsoft.EntityFrameworkCore;

namespace BasicApi.Models;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Department> Departments { get; set; }
}

```

The `AppDbContext` class inherits from `DbContext`, which is the primary class responsible for interacting with the database using Entity Framework Core. It contains `DbSet` properties for each of the models we created earlier, allowing us to perform operations on the corresponding database tables.

### 5. Configure the DbContext in Program.cs

1. Open the `Program.cs` file and modify it to configure the `AppDbContext` with the connection string from `appsettings.json`.

This should be included before the `var app = builder.Build();` line, but after the `var builder = WebApplication.CreateBuilder(args);` line.

```csharp

using BasicApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.Run();

```

### 6. Create the API Controllers

1. Create a new folder named `Controllers` in your project directory.
2. Inside the `Controllers` folder, create two new C# files: `EmployeesController.cs` and `DepartmentsController.cs`.

```csharp
// EmployeesController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BasicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            var employees = await _context.Employees.Include(e => e.Department).ToListAsync();
            return Ok(employees);
        }
    }
}

```

This will give you a basic API endpoint that you can hit within Bruno to retrieve a list of employees along with their associated departments.

### 7. Test the API with Bruno

1. Run the application in terminal:
   `dotnet run`

2. Open Bruno and disable SSL/TLS verification (since we are using a self-signed certificate in development). Press `Cmd+,` to open settings, under General disable SSL/TLS Certificate Verification and click save.

3. Create a new collection in Bruno called "Basic API".

4. Inside the "Basic API" collection, create a new request for the GET endpoint: `https://localhost:5000/api/employee`

5. Send the request and you should see a list of employees along with their associated departments in the response.
