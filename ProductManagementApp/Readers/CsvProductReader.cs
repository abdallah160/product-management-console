using ProductManagementApp.Models;
using ProductManagementApp.Readers.Interfaces;

namespace ProductManagementApp.Readers;

public class CsvProductReader : IProductReader
{
    public Product ReadProduct()
    {
        throw new NotSupportedException("CsvProductReader does not support reading a single product interactively.");
    }

    public IEnumerable<Product> ReadProducts(string csvPath)
    {
        using StreamReader reader = new(csvPath);
        reader.ReadLine(); // skip header

        int lineNumber = 1;
        while (!reader.EndOfStream)
        {
            lineNumber++;
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

            yield return new Product(values[0], values[1], values[2], price, quantity);
        }
    }
}
