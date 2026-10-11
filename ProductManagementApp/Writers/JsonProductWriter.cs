using System.Text.Json;
using ProductManagementApp.Models;
using ProductManagementApp.Writers.Interfaces;

namespace ProductManagementApp.Writers;

public class JsonProductWriter : IProductWriter
{
    private readonly string _outputPath;

    public JsonProductWriter(string outputPath)
    {
        _outputPath = outputPath;
    }

    public void Write(IReadOnlyList<Product> products)
    {
        string json = JsonSerializer.Serialize(products, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_outputPath, json);
        Console.WriteLine($"Products exported to {_outputPath}\n");
    }
}
