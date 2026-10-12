using ProductManagementApp.Models;

namespace ProductManagementApp.Readers.Interfaces;

public interface IProductReader
{
    IEnumerable<Product> Read();
}
