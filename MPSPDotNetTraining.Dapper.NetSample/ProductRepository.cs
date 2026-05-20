using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Dapper;

public class ProductRepository
{
    private readonly string _connectionString;

    public ProductRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    
    public void AddProduct(Product product)
    {
        using var connection = new SqlConnection(_connectionString);

        string sql = @"INSERT INTO Products(Name, Price, Qty)
                       VALUES(@Name, @Price, @Qty)";

        connection.Execute(sql, product);
    }

    
    public List<Product> GetAllProducts()
    {
        using var connection = new SqlConnection(_connectionString);

        string sql = "SELECT * FROM Products";

        return connection.Query<Product>(sql).ToList();
    }

    
    public void UpdateProduct(Product product)
    {
        using var connection = new SqlConnection(_connectionString);

        string sql = @"UPDATE Products
                       SET Name = @Name,
                           Price = @Price,
                           Qty = @Qty
                       WHERE Id = @Id";

        connection.Execute(sql, product);
    }

    
    public void DeleteProduct(int id)
    {
        using var connection = new SqlConnection(_connectionString);

        string sql = "DELETE FROM Products WHERE Id = @Id";

        connection.Execute(sql, new { Id = id });
    }
}