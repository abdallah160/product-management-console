using ProductManagementApp.Models;
using ProductManagementApp.Writers.Interfaces;

namespace ProductManagementApp.Writers;

public class ConsoleProductWriter : IProductWriter
{
    public void Write(IReadOnlyList<Product> products)
    {
        if (products.Count == 0)
        {
            Console.WriteLine("\nThere are no products yet.\n");
            return;
        }

        const string format = "{0,-5} | {1,-12} | {2,-30} | {3,-120} | {4,10} | {5,8}";
        Console.WriteLine("\n--- Available Products ---");
        Console.WriteLine(string.Format(format, "ID", "Code", "Name", "Description", "Price", "Qty"));
        Console.WriteLine(new string('-', 195));

        foreach (Product p in products)
            Console.WriteLine(format, p.ProductID, p.ProductCode, p.Name, p.Description, p.Price, p.Quantity);

        Console.WriteLine(new string('-', 195));
        Console.WriteLine($"Total products: {products.Count}\n");
    }
}
