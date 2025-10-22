using Microsoft.Data.SqlClient;

namespace SQLIntegration
{
    public class Department
    {
        public int DepartmentID { get; set; }
        public required string DepartmentName { get; set; }
    }

    public class DepartmentSQLHelper
    {
        private readonly string _connectionString = "server=localhost;database=Kata9DB;user=sa;password=DevPassword1;trustServerCertificate=true;";

        public IEnumerable<Department> GetAllDepartments()
        {
            List<Department> departments = new List<Department>();
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            string query = "SELECT * FROM Departments";
            using SqlCommand command = new SqlCommand(query, connection);
            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                departments.Add(MapToDepartment(reader));
            }

            connection.Close();
            return departments;
        }

        public static Department MapToDepartment(SqlDataReader reader)
        {
            return new Department
            {
                DepartmentID = Convert.ToInt32(reader["DepartmentID"]),
                DepartmentName = reader["DepartmentName"].ToString()
            };
        }

        internal void InsertDepartment(Department department)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            string query = "INSERT INTO Departments (DepartmentName) VALUES (@DepartmentName)";
            using SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DepartmentName", department.DepartmentName);
            command.ExecuteNonQuery();

            connection.Close();
        }
    }
}