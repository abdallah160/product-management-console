using ProductManagementApp.Models;
using ProductManagementApp.Validation.Interfaces;

namespace ProductManagementApp.Validation;

public class ProductValidator : IProductValidator
{
    public ValidationResult Validate(Product product)
    {
        ValidationResult result = new();

        if (string.IsNullOrWhiteSpace(product.ProductCode))
            result.AddError("Product code must be entered.");

        if (string.IsNullOrWhiteSpace(product.Name))
            result.AddError("Name must be entered.");

        if (!string.IsNullOrEmpty(product.Description) && product.Description.Length > 500)
            result.AddError("Description must be 500 characters at most.");

        if (product.Price <= 0)
            result.AddError("Price must be more than 0.");

        if (product.Quantity < 0)
            result.AddError("Quantity must be 0 or more.");

        return result;
    }
}