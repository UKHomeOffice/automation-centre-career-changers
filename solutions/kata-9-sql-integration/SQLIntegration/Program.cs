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
