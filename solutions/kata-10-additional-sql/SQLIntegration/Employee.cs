using System;
using Microsoft.Data.SqlClient;

namespace SQLIntegrationAdd;

public class Employee
{
    public int EmployeeID { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string DepartmentName { get; set; } = string.Empty;
}

public class EmployeeSQLHelper
{
    private readonly string _connectionString = "server=localhost;database=Kata9DB;user=sa;password=DevPassword1;trustServerCertificate=true;";

    public IEnumerable<Employee> GetAllEmployeesWithDepartments()
    {
        List<Employee> employees = new List<Employee>();
        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();

        string query = @"
            SELECT e.EmployeeID, e.FirstName, e.LastName, e.DepartmentID
            FROM Employees e
            INNER JOIN Departments d ON e.DepartmentID = d.DepartmentID";
        using SqlCommand command = new SqlCommand(query, connection);
        using SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            employees.Add(MapToEmployee(reader));
        }

        connection.Close();
        return employees;
    }

    public static Employee MapToEmployee(SqlDataReader reader)
    {
        return new Employee
        {
            EmployeeID = Convert.ToInt32(reader["EmployeeID"]),
            FirstName = reader["FirstName"].ToString() ?? string.Empty,
            LastName = reader["LastName"].ToString() ?? string.Empty,
            DepartmentName = reader["DepartmentName"].ToString() ?? string.Empty
        };
    }
}
