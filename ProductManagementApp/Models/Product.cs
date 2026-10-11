namespace ProductManagementApp.Models;

public class Product
{
    public int ProductID { get; set; }
    public string ProductCode { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public Product(string productCode, string name, string description, decimal price, int quantity)
    {
        ProductCode = productCode;
        Name = name;
        Description = description;
        Price = price;
        Quantity = quantity;
    }
}
