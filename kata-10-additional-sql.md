# Kata 10 - Additional SQL

## Objective

Expand your SQL knowledge by exploring advanced concepts such as inserting, updating records, along with joining and grouping data within the application.

Although in modern applications there is a far larger chance of using an ORM like Entity Framework, understanding raw SQL operations is crucial for performance tuning and complex queries.

## Prerequisites

This will build from Kata 9 and continue to use the SQL Server instance and database you created there, and build from the existing console application.

## Steps

### 1. Update Your Application

Update your Program.cs file to the following code which will give you the basics for an interactive console application:

```csharp
class Program
{

    static void Main(string[] args)
    {
        while (true)
        {


            var itemType = GetItemType();
            var operationType = GetOperationType();
            Console.Clear();

            Console.WriteLine($"You selected Item Type: {itemType}, Operation Type: {operationType}");

        }
    }

    private static string? GetItemType()
    {
        Console.WriteLine("Selected between the following options:");
        Console.WriteLine("E - Employees");
        Console.WriteLine("D - Departments");
        Console.WriteLine("P - Projects");
        Console.Write(": ");
        return Console.ReadLine();
    }

    private static string? GetOperationType()
    {
        Console.WriteLine("Select operation type:");
        Console.WriteLine("1 - View All");
        Console.WriteLine("2 - Insert New");
        Console.Write(": ");
        return Console.ReadLine();
    }
}
```

### 2. Implement View / Insert Departments

Create a new class file named `Department.cs` and implement the following code to handle viewing and inserting departments:

```csharp
public class Department
{
    public int DepartmentID { get; set; }
    public required string DepartmentName { get; set; }
}

public class DepartmentSQLHelper{
    private readonly string _connectionString = "server=localhost;database=Kata9DB;user=sa;password=DevPassword1;trustServerCertificate=true;";

    public IEnumerable<Department> GetAllDepartments()
    {
        var departments = new List<Department>();

        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            var command = new SqlCommand("SELECT DepartmentID, DepartmentName FROM Departments", connection);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    departments.Add(new Department
                    {
                        DepartmentID = reader.GetInt32(0),
                        DepartmentName = reader.GetString(1)
                    });
                }
            }
        }

        return departments;
    }

    public void InsertDepartment(string departmentName)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            var command = new SqlCommand("INSERT INTO Departments (DepartmentName) VALUES (@DepartmentName)", connection);
            command.Parameters.AddWithValue("@DepartmentName", departmentName);
            command.ExecuteNonQuery();
        }
    }

}
```

#### Important - SQL Injection Prevention

Always make sure to use parameterized queries (as shown above) to prevent SQL injection attacks. Under no circumstances should you concatenate user input directly into SQL statements, for example:

```csharp
// THIS IS DANGEROUS AND VULNERABLE TO SQL INJECTION

var command = new SqlCommand("INSERT INTO Departments (DepartmentName) VALUES ('" + departmentName + "')", connection);
```

### 3. Integrate Department Operations into Main Program

In your `Program.cs`, integrate the department operations based on user input:

Create a new function for Department Operations

```csharp
 private static void HandleDepartmentOperations(string operationType)
    {
        switch (operationType)
        {
            case "v":
                DepartmentSQLHelper departmentHelper = new DepartmentSQLHelper();
                var departments = departmentHelper.GetAllDepartments();
                foreach (var dept in departments)
                {
                    Console.WriteLine($"ID: {dept.DepartmentID}, Name: {dept.DepartmentName}");
                }
                break;
            case "i":
                Console.Write("Enter Department Name: ");
                string deptName = Console.ReadLine() ?? string.Empty;
                Department newDept = new Department { DepartmentName = deptName };
                DepartmentSQLHelper insertHelper = new DepartmentSQLHelper();
                insertHelper.InsertDepartment(newDept);
                Console.WriteLine("Department inserted successfully.");
                break;
            default:
                Console.WriteLine("Invalid operation type selected.");
                break;
        }
    }
```

Call this in the previous switch statement in Main:

```csharp
switch (itemType?.ToLower())
    {
        case "e":
            // NOT IMPLEMENTED YET
            break;
        case "d":
            HandleDepartmentOperations(operationType);
            break;
        case "p":
            // NOT IMPLEMENTED YET
            break;
        default:
            Console.WriteLine("Invalid item type selected.");
            continue;
    }
```
