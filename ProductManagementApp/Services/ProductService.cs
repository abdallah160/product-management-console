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

    public ValidationResult AddProductFromReader(IProductReader reader)
    {
        Product? product = reader.Read().FirstOrDefault();
        if (product is null)
            return new ValidationResult();

        return AddProduct(product);
    }

    public IReadOnlyList<string> AddProductsFromReader(IProductReader reader)
    {
        var messages = new List<string>();

        foreach (Product product in reader.Read())
        {
            try
            {
                ValidationResult result = AddProduct(product);
                if (!result.IsValid)
                {
                    messages.Add($"Skipping '{product.Name}': {string.Join(", ", result.Errors)}");
                    continue;
                }

                messages.Add($"Added '{product.Name}' (ID: {product.ProductId})");
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

    private ValidationResult AddProduct(Product product)
    {
        ValidationResult result = _validator.Validate(product);
        if (!result.IsValid)
            return result;

        _repository.Add(product);
        return result;
    }
}
