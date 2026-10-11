using ProductManagementApp.Models;

namespace ProductManagementApp.Writers.Interfaces;

public interface IProductWriter
{
    void Write(IReadOnlyList<Product> products);
}
