using System;

namespace ProductManagementApp
{
    public class Product
    {
        private int _productId;
        private string _productCode;
        private string _name;
        private string _description;
        private decimal _price;
        private int _quantity;

        public int ProductID
        {
            get => _productId; set => _productId = value;
        }
        public string ProductCode
        {
            get => _productCode; set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("product code must entered");
                _productCode = value;
            }
        }
        public string Name
        {
            get => _name; set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("name must entered");
                _name = value;
            }
        }
        public string Description
        {
            get => _description; set
            {
                if (!string.IsNullOrEmpty(value) && value.Length > 500) throw new ArgumentException("Description must be 500 characters at most");
                _description = value;

            }
        }
        public decimal Price
        {
            get => _price; set
            {
                if (value <= 0) throw new ArgumentException("price must be more than 0");
                _price = value;
            }
        }
        public int Quantity
        {
            get => _quantity; set
            {
                if (value < 0) throw new ArgumentException("quantity must equal 0 or more");
                _quantity = value;
            }
        }

        public Product(string productCode, string name, string description, decimal price, int quantity)
        {
            ProductCode = productCode;
            Name = name;
            Description = description;
            Price = price;
            Quantity = quantity;
        }
    }
}
