using ProductManagementApp.Models;
using ProductManagementApp.Readers.Interfaces;

namespace ProductManagementApp.Readers;

public class CsvProductReader : IProductReader
{
    private readonly string _csvPath;

    public CsvProductReader(string csvPath = "products_no_id.csv")
    {
        _csvPath = csvPath;
    }

    public IEnumerable<Product> Read()
    {
        List<Product> products = [];
        using StreamReader reader = new(_csvPath);
        reader.ReadLine(); // skip header

        while (!reader.EndOfStream)
        {
            string? line = reader.ReadLine();
            if (string.IsNullOrWhiteSpace(line))
                continue;

            string[] values = line.Split(',');

            if (values.Length < 5)
                continue;

            if (!decimal.TryParse(values[3], out decimal price))
                continue;

            if (!int.TryParse(values[4], out int quantity))
                continue;

            products.Add(new Product
            {
                ProductCode = values[0],
                Name = values[1],
                Description = values[2],
                Price = price,
                Quantity = quantity
            });
        }

        return products;
    }
}
