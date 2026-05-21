
using System;
using System.Data;
using Microsoft.Data.SqlClient;
using MPSPDotNetTraining.AdoDotNetSample;

namespace MPSPDotNetTraining.AdoDotNetSample.ConsoleApp
{
    public class AdoDotNetService
    {
        private readonly SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "MPSPDotNetTraining",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true
        };

        // Read
        public void Read()
        {
            using SqlConnection connection = new SqlConnection(builder.ConnectionString);

            connection.Open();

            string query = @"SELECT *
                             FROM Tbl_Employee
                             WHERE IsDelete = 0";

            using SqlCommand cmd = new SqlCommand(query, connection);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            adapter.Fill(dt);

            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine("--------------------------------");
                Console.WriteLine($"ID : {row["EmployeeId"]}");
                Console.WriteLine($"No : {row["EmployeeNo"]}");
                Console.WriteLine($"Name : {row["EmployeeName"]}");
                Console.WriteLine($"Father : {row["FatherName"]}");
                Console.WriteLine($"Address : {row["Address"]}");
                Console.WriteLine($"DOB : {Convert.ToDateTime(row["DateOfBirth"]):dd MMM yyyy}");
            }
        }

        // Edit
        public Employee Edit(int id)
        {
            using SqlConnection connection = new SqlConnection(builder.ConnectionString);

            connection.Open();

            string query = @"SELECT *
                             FROM Tbl_Employee
                             WHERE EmployeeId = @EmployeeId
                             AND IsDelete = 0";

            using SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@EmployeeId", id);

            using SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new Employee()
                {
                    EmployeeId = Convert.ToInt32(reader["EmployeeId"]),
                    EmployeeNo = reader["EmployeeNo"].ToString(),
                    EmployeeName = reader["EmployeeName"].ToString(),
                    FatherName = reader["FatherName"].ToString(),
                    Address = reader["Address"].ToString(),
                    DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"])
                };
            }

            Console.WriteLine("Employee not found.");

            return null;
        }

        // Create
        public void Create(Employee employee)
        {
            using SqlConnection connection = new SqlConnection(builder.ConnectionString);

            connection.Open();

            string query = @"INSERT INTO Tbl_Employee
                            (
                                EmployeeNo,
                                EmployeeName,
                                FatherName,
                                Address,
                                DateOfBirth,
                                IsDelete,
                                CreatedDateTime,
                                CreatedBy
                            )
                            VALUES
                            (
                                @EmployeeNo,
                                @EmployeeName,
                                @FatherName,
                                @Address,
                                @DateOfBirth,
                                0,
                                @CreatedDateTime,
                                @CreatedBy
                            )";

            using SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@EmployeeNo", employee.EmployeeNo);
            cmd.Parameters.AddWithValue("@EmployeeName", employee.EmployeeName);
            cmd.Parameters.AddWithValue("@FatherName", employee.FatherName);
            cmd.Parameters.AddWithValue("@Address", employee.Address);
            cmd.Parameters.AddWithValue("@DateOfBirth", employee.DateOfBirth);
            cmd.Parameters.AddWithValue("@CreatedDateTime", DateTime.Now);
            cmd.Parameters.AddWithValue("@CreatedBy", "admin");

            int result = cmd.ExecuteNonQuery();

            Console.WriteLine(result > 0
                ? "Create successful."
                : "Create failed.");
        }

        // Update
        public void Update(Employee employee)
        {
            using SqlConnection connection = new SqlConnection(builder.ConnectionString);

            connection.Open();

            string query = @"UPDATE Tbl_Employee
                             SET EmployeeNo = @EmployeeNo,
                                 EmployeeName = @EmployeeName,
                                 FatherName = @FatherName,
                                 Address = @Address,
                                 DateOfBirth = @DateOfBirth
                             WHERE EmployeeId = @EmployeeId";

            using SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@EmployeeId", employee.EmployeeId);
            cmd.Parameters.AddWithValue("@EmployeeNo", employee.EmployeeNo);
            cmd.Parameters.AddWithValue("@EmployeeName", employee.EmployeeName);
            cmd.Parameters.AddWithValue("@FatherName", employee.FatherName);
            cmd.Parameters.AddWithValue("@Address", employee.Address);
            cmd.Parameters.AddWithValue("@DateOfBirth", employee.DateOfBirth);

            int result = cmd.ExecuteNonQuery();

            Console.WriteLine(result > 0
                ? "Update successful."
                : "Update failed.");
        }

        // Delete
        public void Delete(int id)
        {
            using SqlConnection connection = new SqlConnection(builder.ConnectionString);

            connection.Open();

            string query = @"UPDATE Tbl_Employee
                             SET IsDelete = 1
                             WHERE EmployeeId = @EmployeeId";

            using SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@EmployeeId", id);

            int result = cmd.ExecuteNonQuery();

            Console.WriteLine(result > 0
                ? "Delete successful."
                : "Delete failed.");
        }
    }
}