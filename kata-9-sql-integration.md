# Kata 9 - SQL Integration into Applications

## Objective

Integrate SQL database operations into a simple application. This kata will guide you through connecting to a SQL database, executing queries, and handling results within an application context.

## Steps

### Step 1: Set Up Your SQL Database

Inside the SQL Server instance you created in Kata 8, create a new database and a table to store data.

```sql

CREATE DATABASE Kata9DB;
GO

USE Kata9DB;

CREATE TABLE Departments (

    DepartmentID INT IDENTITY(1,1) PRIMARY KEY,
    DepartmentName NVARCHAR(50)
);

CREATE TABLE Employees (
    EmployeeID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    DepartmentId INT,
    FOREIGN KEY (DepartmentId) REFERENCES Departments(DepartmentID)
);

CREATE TABLE Projects (
    ProjectID INT IDENTITY(1,1) PRIMARY KEY,
    ProjectName NVARCHAR(100),
    DepartmentId INT,
    FOREIGN KEY (DepartmentId) REFERENCES Departments(DepartmentID)
);

INSERT INTO Departments (DepartmentID, DepartmentName) VALUES
('HR'),
('IT'),
('Finance');

INSERT INTO Employees (EmployeeID, FirstName, LastName, DepartmentId) VALUES
('Alice', 'Johnson', 2),
('Bob', 'Smith', 1),
('Charlie', 'Brown', 3);

INSERT INTO Projects (ProjectID, ProjectName, DepartmentId) VALUES
('Project Alpha', 2),
('Project Beta', 1),
('Project Gamma', 3),
('Project Delta', 2),
('Project Epsilon', 1),
('Project Zeta', 3),
('Project Eta', 2),
('Project Theta', 1),
('Project Iota', 3),
('Project Kappa', 2);
```

In the above example you can see each table has a primary key and the Employees and Projects tables have foreign keys referencing the Departments table. The primary keys are set to auto-increment using the IDENTITY property, so they can be omitted when inserting new records.

Foreign keys are used to maintain referential integrity between the tables, to ensure that relationships between records are valid.

### Step 2: Create a Simple Application

Create a .NET application in the usual way as per the previous katas and open your project in Visual Studio Code.

Ensure that you can see the Solution Explorer inside Visual Studio Code (if not, press CMD+SHIFT+P and type "Solution Explorer" and select the appropriate option). You should have a list of your project files visible.

Right-click on your project in the Solution Explorer and select "Add NuGet Package".

Search for Microsoft.Data.SqlClient and install it.

### Step 3: Connect to the Database and Execute Queries

1. Open the `Program.cs` file.
2. Replace the contents with code that connects to the SQL database, retrieves data from the `Departments` table, and displays it in the console.

```csharp
using Microsoft.Data.SqlClient;

namespace SQLIntegration;

class Program
{

    static void Main(string[] args)
    {
        string connectionString = "server=localhost;database=Kata9DB;user=sa;password=DevPassword1;trustServerCertificate=true;";
        using SqlConnection connection = new SqlConnection(connectionString);

        connection.Open();

        string getDepartmentsQuery = "SELECT * FROM Departments";
        using SqlCommand command = new SqlCommand(getDepartmentsQuery, connection);
        using SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine($"Department ID: {reader["DepartmentID"]}, Name: {reader["DepartmentName"]}");
        }

        connection.Close();

    }
}
```

3. Run the application to see the list of departments printed in the console.

## Next Steps

This kata will continue in the next few katas to expand on this application by adding more functionality. Such as inserting new records, updating existing ones, and deleting records. Along with more complex queries involving joins and grouping between the tables.
