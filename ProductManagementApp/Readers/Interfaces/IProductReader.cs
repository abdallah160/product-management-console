using ProductManagementApp.Models;

namespace ProductManagementApp.Readers.Interfaces;

public interface IProductReader
{
    Product ReadProduct();
    IEnumerable<Product> ReadProducts(string source);
}
