using ProductManagementApp.Readers;
using ProductManagementApp.Readers.Interfaces;

namespace ProductManagementApp.Factories;

public enum ReaderType { Console, Csv }

public class ProductReaderFactory
{
    public static IProductReader Create(ReaderType type) => type switch
    {
        ReaderType.Console => new ConsoleProductReader(),
        ReaderType.Csv    => new CsvProductReader(),
        _ => throw new ArgumentOutOfRangeException(nameof(type), $"Unknown reader type: {type}")
    };
}
