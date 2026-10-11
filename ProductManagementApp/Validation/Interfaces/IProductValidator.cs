using ProductManagementApp.Models;

namespace ProductManagementApp.Validation.Interfaces;

public interface IProductValidator
{
    ValidationResult Validate(Product product);
}
