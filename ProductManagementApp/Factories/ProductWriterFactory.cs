using ProductManagementApp.Writers;
using ProductManagementApp.Writers.Interfaces;

namespace ProductManagementApp.Factories;

public enum WriterType { Console, Json }

public class ProductWriterFactory
{
    public static IProductWriter Create(WriterType type, string? outputPath = null) => type switch
    {
        WriterType.Console => new ConsoleProductWriter(),
        WriterType.Json    => new JsonProductWriter(outputPath ?? "products.json"),
        _ => throw new ArgumentOutOfRangeException(nameof(type), $"Unknown writer type: {type}")
    };
}
