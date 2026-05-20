using System;

class Program
{
    static void Main()
    {
        string connectionString =
        "Data Source=.;Initial Catalog=MyShop;User ID=sa;Password=sasa@123;TrustServerCertificate=True;";

    ProductRepository repo = new ProductRepository(connectionString);

        while (true)
        {
            Console.WriteLine("\n=== MY SHOP SYSTEM ===");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. View Products");
            Console.WriteLine("3. Update Product");
            Console.WriteLine("4. Delete Product");
            Console.WriteLine("5. Exit");

            Console.Write("Choose: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddProduct(repo);
                    break;

                case 2:
                    ViewProducts(repo);
                    break;

                case 3:
                    UpdateProduct(repo);
                    break;

                case 4:
                    DeleteProduct(repo);
                    break;

                case 5:
                    Console.WriteLine("Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }
    }

    
    static void AddProduct(ProductRepository repo)
    {
        Product p = new Product();

        Console.Write("Enter Name: ");
        p.Name = Console.ReadLine();

        Console.Write("Enter Price: ");
        p.Price = Convert.ToDecimal(Console.ReadLine());

        Console.Write("Enter Qty: ");
        p.Qty = Convert.ToInt32(Console.ReadLine());

        repo.AddProduct(p);

        Console.WriteLine("Product Added Successfully!");
    }

    
    static void ViewProducts(ProductRepository repo)
    {
        var products = repo.GetAllProducts();

        Console.WriteLine("\n=== PRODUCT LIST ===");

        foreach (var p in products)
        {
            Console.WriteLine($"ID: {p.Id}");
            Console.WriteLine($"Name: {p.Name}");
            Console.WriteLine($"Price: {p.Price}");
            Console.WriteLine($"Qty: {p.Qty}");
            Console.WriteLine("----------------------");
        }
    }

    
    static void UpdateProduct(ProductRepository repo)
    {
        Product p = new Product();

        Console.Write("Enter Product ID: ");
        p.Id = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter New Name: ");
        p.Name = Console.ReadLine();

        Console.Write("Enter New Price: ");
        p.Price = Convert.ToDecimal(Console.ReadLine());

        Console.Write("Enter New Qty: ");
        p.Qty = Convert.ToInt32(Console.ReadLine());

        repo.UpdateProduct(p);

        Console.WriteLine("Product Updated Successfully!");
    }

    
    static void DeleteProduct(ProductRepository repo)
    {
        Console.Write("Enter Product ID to Delete: ");

        int id = Convert.ToInt32(Console.ReadLine());

        repo.DeleteProduct(id);

        Console.WriteLine("Product Deleted Successfully!");
    }


}
