using ProductManagementApp.Models;
using ProductManagementApp.Readers.Interfaces;
using ProductManagementApp.Repositories.Interfaces;
using ProductManagementApp.Services.Interfaces;
using ProductManagementApp.Validation;
using ProductManagementApp.Validation.Interfaces;
using ProductManagementApp.Writers.Interfaces;

namespace ProductManagementApp.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;
    private readonly IProductValidator _validator;

    public ProductService(IProductRepository repository, IProductValidator validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public ValidationResult AddProduct(string productCode, string name, string description, decimal price, int quantity)
    {
        Product product = new(productCode, name, description, price, quantity);

        ValidationResult result = _validator.Validate(product);
        if (!result.IsValid)
            return result;

        _repository.Add(product);
        return result;
    }

    public ValidationResult AddProductFromReader(IProductReader reader)
    {
        Product product = reader.ReadProduct();

        ValidationResult result = _validator.Validate(product);
        if (!result.IsValid)
            return result;

        _repository.Add(product);
        return result;
    }

    public void AddProductsFromReader(IProductReader reader, string source)
    {
        foreach (Product product in reader.ReadProducts(source))
        {
            try
            {
                ValidationResult result = _validator.Validate(product);
                if (!result.IsValid)
                {
                    Console.WriteLine($"Skipping product '{product.Name}' due to validation errors:");
                    foreach (string error in result.Errors)
                        Console.WriteLine($"  - {error}");
                    continue;
                }

                _repository.Add(product);
                Console.WriteLine($"Product '{product.Name}' added successfully (ID: {product.ProductID})");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing entry: {ex.Message}");
            }
        }
        Console.WriteLine();
    }

    public void DisplayProducts(IProductWriter writer)
    {
        writer.Write(_repository.GetAll());
    }

    public IReadOnlyList<Product> GetAllProducts()
    {
        return _repository.GetAll();
    }
}
