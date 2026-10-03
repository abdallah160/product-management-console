using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Product
    {
        private static int counter = 1;
        private int _productId;
        private string _productCode;
        private string _name;
        private string _description;
        private decimal _price;
        private int _quantity;

        private static void ValidateCode(string code)
        {
            if (string.IsNullOrWhiteSpace(code)) throw new ArgumentException("product code must entered");
        }

        private static void ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("name must entered");
        }

        private static void ValidateDescription(string description)
        {
            if (!string.IsNullOrEmpty(description) && description.Length > 500) throw new ArgumentException("Description must be 500 characters at most");

        }

        private static void ValidatePrice(decimal price)
        {
            if (price <= 0) throw new ArgumentException("price must be more than 0");

        }

        private static void ValidateQuantity(int quantity)
        {
            if (quantity < 0) throw new ArgumentException("quantity must equal 0 or more");
        }


        public int ProductID
        {
            get => _productId; set => _productId = value;
        }
        public string ProductCode
        {
            get => _productCode; set
            {
                ValidateCode(value);
                _productCode = value;
            }
        }
        public string Name
        {
            get => _name; set
            {
                ValidateName(value);
                _name = value;
            }
        }
        public string Description
        {
            get => _description; set
            {
                ValidateDescription(value);
                _description = value;

            }
        }
        public decimal Price
        {
            get => _price; set
            {
                ValidatePrice(value);
                _price = value;
            }
        }
        public int Quantity
        {
            get => _quantity; set
            {
                ValidateQuantity(value);
                _quantity = value;
            }
        }

        public Product(string productCode, string name, string description, decimal price, int quantity)
        {
            ProductID = counter;
            ProductCode = productCode;
            Name = name;
            Description = description;
            Price = price;
            Quantity = quantity;
            counter++;

        }
    }
}
