using ProductManagementApp.Models;

namespace ProductManagementApp.Repositories.Interfaces;

public interface IProductRepository
{
    void Add(Product product);
    IReadOnlyList<Product> GetAll();
}
