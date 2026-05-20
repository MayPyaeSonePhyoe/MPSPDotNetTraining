using System.Collections.Generic;
using Microsoft.Data.SqlClient;

public class ProductRepository
{
    private readonly string _connectionString;

    public ProductRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    
    public void AddProduct(Product p)
    {
        using SqlConnection conn =
            new SqlConnection(_connectionString);

        string query =
            "INSERT INTO Products (Name, Price, Qty) VALUES (@Name, @Price, @Qty)";

        SqlCommand cmd = new SqlCommand(query, conn);

        cmd.Parameters.AddWithValue("@Name", p.Name);
        cmd.Parameters.AddWithValue("@Price", p.Price);
        cmd.Parameters.AddWithValue("@Qty", p.Qty);

        conn.Open();

        cmd.ExecuteNonQuery();
    }

    
    public List<Product> GetAllProducts()
    {
        List<Product> products = new List<Product>();

        using SqlConnection conn =
            new SqlConnection(_connectionString);

        string query = "SELECT * FROM Products";

        SqlCommand cmd = new SqlCommand(query, conn);

        conn.Open();

        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Product p = new Product();

            p.Id = (int)reader["Id"];
            p.Name = reader["Name"].ToString();
            p.Price = (decimal)reader["Price"];
            p.Qty = (int)reader["Qty"];

            products.Add(p);
        }

        reader.Close();

        return products;
    }

    
    public void UpdateProduct(Product p)
    {
        using SqlConnection conn =
            new SqlConnection(_connectionString);

        string query =
            @"UPDATE Products
              SET Name=@Name,
                  Price=@Price,
                  Qty=@Qty
              WHERE Id=@Id";

        SqlCommand cmd = new SqlCommand(query, conn);

        cmd.Parameters.AddWithValue("@Id", p.Id);
        cmd.Parameters.AddWithValue("@Name", p.Name);
        cmd.Parameters.AddWithValue("@Price", p.Price);
        cmd.Parameters.AddWithValue("@Qty", p.Qty);

        conn.Open();

        cmd.ExecuteNonQuery();
    }

    
    public void DeleteProduct(int id)
    {
        using SqlConnection conn =
            new SqlConnection(_connectionString);

        string query =
            "DELETE FROM Products WHERE Id=@Id";

        SqlCommand cmd = new SqlCommand(query, conn);

        cmd.Parameters.AddWithValue("@Id", id);

        conn.Open();

        cmd.ExecuteNonQuery();
    }
}