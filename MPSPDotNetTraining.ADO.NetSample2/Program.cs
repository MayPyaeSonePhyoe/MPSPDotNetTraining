// See https://aka.ms/new-console-template for more information
using Microsoft.Data.SqlClient;
using System.ComponentModel;

Console.WriteLine("Hello, World!");

SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder()
{
    DataSource = ".",
    InitialCatalog = "MPSPDotNetInternshipTraining",
    UserID = "sa",
    Password = "sasa@123",
    TrustServerCertificate = true
};

Console.Write("This is connection String: ");
Console.WriteLine(builder.ConnectionString);

SqlConnection connection = new SqlConnection(builder.ConnectionString);
Console.WriteLine("Connection opening....");
connection.Open();
Console.WriteLine("Connection opened.");

Console.WriteLine("Connection closing...");
connection.Close();
Console.WriteLine("Connection closed.");

Console.ReadLine();


