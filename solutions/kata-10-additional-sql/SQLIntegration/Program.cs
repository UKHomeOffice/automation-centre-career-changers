using Microsoft.Data.SqlClient;

namespace SQLIntegration;

class Program
{

    static void Main(string[] args)
    {
        while (true)
        {
            var itemType = GetItemType();
            var operationType = GetOperationType();

            // Clear the console after selections to keep it clean
            Console.Clear();
            // Output what selections were
            Console.WriteLine($"You selected Item Type: {itemType}, Operation Type: {operationType}");

            if (string.IsNullOrEmpty(itemType) || string.IsNullOrEmpty(operationType))
            {
                Console.WriteLine("Invalid selection. Please try again.");
                continue;
            }

            switch (itemType?.ToLower())
            {
                case "e":
                    break;
                case "d":
                    HandleDepartmentOperations(operationType);
                    break;
                case "p":
                    break;
                default:
                    Console.WriteLine("Invalid item type selected.");
                    continue;
            }
        }
    }

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
        Console.WriteLine("V - View All");
        Console.WriteLine("I - Insert New");
        Console.Write(": ");
        return Console.ReadLine();
    }

}
