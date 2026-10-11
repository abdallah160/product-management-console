using ProductManagementApp.Models;
using ProductManagementApp.Readers.Interfaces;
using ProductManagementApp.Validation;
using ProductManagementApp.Writers.Interfaces;

namespace ProductManagementApp.Services.Interfaces;

public interface IProductService
{
    ValidationResult AddProduct(string productCode, string name, string description, decimal price, int quantity);
    ValidationResult AddProductFromReader(IProductReader reader);
    void AddProductsFromReader(IProductReader reader, string source);
    void DisplayProducts(IProductWriter writer);
    IReadOnlyList<Product> GetAllProducts();
}

