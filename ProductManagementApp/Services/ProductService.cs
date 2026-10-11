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

    public IReadOnlyList<string> AddProductsFromReader(IProductReader reader, string source)
    {
        var messages = new List<string>();

        foreach (Product product in reader.ReadProducts(source))
        {
            try
            {
                ValidationResult result = _validator.Validate(product);
                if (!result.IsValid)
                {
                    messages.Add($"Skipping '{product.Name}': {string.Join(", ", result.Errors)}");
                    continue;
                }

                _repository.Add(product);
                messages.Add($"Added '{product.Name}' (ID: {product.ProductID})");
            }
            catch (Exception ex)
            {
                messages.Add($"Error: {ex.Message}");
            }
        }

        return messages;
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
