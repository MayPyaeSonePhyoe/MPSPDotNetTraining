using System;
using System.Linq;

class Program
{
    static void Main()
    {
        using AppDbContext db = new AppDbContext();

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
                    AddProduct(db);
                    break;

                case 2:
                    ViewProducts(db);
                    break;

                case 3:
                    UpdateProduct(db);
                    break;

                case 4:
                    DeleteProduct(db);
                    break;

                case 5:
                    return;

                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }
    }

    static void AddProduct(AppDbContext db)
    {
        Product p = new Product();

        Console.Write("Product Name: ");
        p.Name = Console.ReadLine();

        Console.Write("Price: ");
        p.Price = Convert.ToDecimal(Console.ReadLine());

        Console.Write("Qty: ");
        p.Qty = Convert.ToInt32(Console.ReadLine());

        db.Products.Add(p);
        db.SaveChanges();

        Console.WriteLine("Product Added!");
    }

    static void ViewProducts(AppDbContext db)
    {
        var products = db.Products.ToList();

        foreach (var p in products)
        {
            Console.WriteLine($"{p.Id} - {p.Name} - {p.Price} - {p.Qty}");
        }
    }

    static void UpdateProduct(AppDbContext db)
    {
        Console.Write("Enter Product Id: ");
        int id = Convert.ToInt32(Console.ReadLine());

        var product = db.Products.Find(id);

        if (product != null)
        {
            Console.Write("New Name: ");
            product.Name = Console.ReadLine();

            Console.Write("New Price: ");
            product.Price = Convert.ToDecimal(Console.ReadLine());

            Console.Write("New Qty: ");
            product.Qty = Convert.ToInt32(Console.ReadLine());

            db.SaveChanges();

            Console.WriteLine("Product Updated!");
        }
        else
        {
            Console.WriteLine("Product Not Found!");
        }
    }

    static void DeleteProduct(AppDbContext db)
    {
        Console.Write("Enter Product Id: ");
        int id = Convert.ToInt32(Console.ReadLine());

        var product = db.Products.Find(id);

        if (product != null)
        {
            db.Products.Remove(product);
            db.SaveChanges();

            Console.WriteLine("Product Deleted!");
        }
        else
        {
            Console.WriteLine("Product Not Found!");
        }
    }
}