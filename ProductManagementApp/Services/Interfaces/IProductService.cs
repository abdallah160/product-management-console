using ProductManagementApp.Readers.Interfaces;
using ProductManagementApp.Validation;
using ProductManagementApp.Writers.Interfaces;

namespace ProductManagementApp.Services.Interfaces;

public interface IProductService
{
    ValidationResult AddProductFromReader(IProductReader reader);
    IReadOnlyList<string> AddProductsFromReader(IProductReader reader);
    void DisplayProducts(IProductWriter writer);
}
