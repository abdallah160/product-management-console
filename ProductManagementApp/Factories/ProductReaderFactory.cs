using ProductManagementApp.Readers;
using ProductManagementApp.Readers.Interfaces;

namespace ProductManagementApp.Factories;

public enum ReaderType { Console, Csv }

public class ProductReaderFactory
{
    public static IProductReader Create(ReaderType type, string? source = null) => type switch
    {
        ReaderType.Console => new ConsoleProductReader(),
        ReaderType.Csv => new CsvProductReader(source ?? "products_no_id.csv"),
        _ => throw new ArgumentOutOfRangeException(nameof(type), $"Unknown reader type: {type}")
    };
}
