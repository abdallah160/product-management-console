namespace ProductManagementApp;

internal class ProductRepository
{
    private readonly List<Product> _products = [];
    private int _currentId = 1;

    public void Add(Product product)
    {
        product.ProductID = _currentId++;
        _products.Add(product);
    }

    public IReadOnlyList<Product> GetAll()
    {
        return _products.AsReadOnly();
    }
}
