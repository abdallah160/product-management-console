using ProductManagementApp.Models;
using ProductManagementApp.Readers.Interfaces;

namespace ProductManagementApp.Readers;

public class ConsoleProductReader : IProductReader
{
    public IEnumerable<Product> Read()
    {
        Console.WriteLine("\nPlease enter the product code:");
        string productCode = Console.ReadLine() ?? string.Empty;

        Console.WriteLine("Please enter the product name:");
        string name = Console.ReadLine() ?? string.Empty;

        Console.WriteLine("Please enter the product description:");
        string description = Console.ReadLine() ?? string.Empty;

        Console.WriteLine("Please enter the product price:");
        string? priceInput = Console.ReadLine();
        if (!decimal.TryParse(priceInput, out decimal price))
            throw new FormatException("Price must be a numeric/decimal value.");

        Console.WriteLine("Please enter the product quantity:");
        string? quantityInput = Console.ReadLine();
        if (!int.TryParse(quantityInput, out int quantity))
            throw new FormatException("Quantity must be a numeric value.");

        return
        [
            new Product
            {
                ProductCode = productCode,
                Name = name,
                Description = description,
                Price = price,
                Quantity = quantity
            }
        ];
    }
}
