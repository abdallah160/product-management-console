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

        public int ProductID
        {
            get => _productId; set => _productId = value;
        }
        public string ProductCode
        {
            get => _productCode; set
            {
                if (value.Length == 0) throw new ArgumentException("product code must entered");
                _productCode = value;
            }
        }
        public string Name
        {
            get => _name; set
            {
                if (value.Length == 0) throw new ArgumentException("name must entered");
                _name = value;
            }
        }
        public string Description
        {
            get => _description; set
            {
                if (value.Length > 500) throw new ArgumentException("Description must be 500 characters at most");
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
            ProductID = counter;
            ProductCode = productCode;
            Name = name;
            Description = description;
            Price = price;
            Quantity = quantity;
            counter++;

        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();
            bool running = true;
            while (running)
            {
                Console.WriteLine("choose from the menu: \n1.Add a product \n2.Display all products \n3.Stop the application");
                string userInput = Console.ReadLine();
                if (userInput == "1")
                {
                    try
                    {
                        Console.WriteLine("\nPlease enter the product code:");
                        string productCode = Console.ReadLine();
                        Console.WriteLine("Please enter the product name:");
                        string name = Console.ReadLine();
                        Console.WriteLine("Please enter the product description:");
                        string description = Console.ReadLine();
                        Console.WriteLine("Please enter the product price:");
                        string price = Console.ReadLine();
                        if (!(decimal.TryParse(price, out decimal realPrice)))
                        {
                            throw new ArgumentException("price must be a numeric/decimal value");
                        }
                        Console.WriteLine("Please enter the product quantity:");
                        string quantity = Console.ReadLine();
                        if (!(int.TryParse(quantity, out int realQuantity)))
                        {
                            throw new ArgumentException("quantity must be a numeric value");
                        }


                        Product product = new Product(productCode, name, description, realPrice, realQuantity);
                        products.Add(product);

                        Console.WriteLine("Product #" + product.ProductID + " added successfully\n");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message + ", please try again\n");

                    }

                }
                else if (userInput == "2")
                {
                    if (products.Count > 0)
                    {
                        Console.WriteLine("Here are all the products available:");
                        Console.WriteLine("ProductID | ProductCode | Name | Description | Price | Quantity");
                        foreach (Product p in products)
                        {
                            Console.WriteLine(p.ProductID + "  | " + p.ProductCode + "  | " + p.Name + "  | " + p.Description + "  | " + p.Price + "  | " + p.Quantity);
                        }
                        Console.WriteLine("\n");

                    }
                    else Console.WriteLine("There are no products yet\n");
                }
                else if (userInput == "3")
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Please enter a valid option\n");
                }
            }
        }
    }
}