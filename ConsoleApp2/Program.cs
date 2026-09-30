using System;
using System.Collections.Generic;
using System.IO;
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

        public static void ValidateCode(string code)
        {
            if (string.IsNullOrWhiteSpace(code)) throw new ArgumentException("product code must entered");
        }
        
        public static void ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("name must entered");
        }

        public static void ValidateDescription(string description)
        {
            if (!string.IsNullOrEmpty(description) && description.Length > 500) throw new ArgumentException("Description must be 500 characters at most");

        }

        public static void ValidatePrice(decimal price)
        {
            if (price <= 0) throw new ArgumentException("price must be more than 0");

        }

        public static void ValidateQuantity(int quantity)
        {
            if (quantity < 0) throw new ArgumentException("quantity must equal 0 or more");
        }


        public int ProductID
        {
            get => _productId; private set => _productId = value;
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
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();
            bool running = true;
            while (running)
            {
                Console.WriteLine("choose from the menu: \n1.Add a product Manually \n2.Add products via CSV file \n3.Display all products \n4.Stop the application");
                string userInput = Console.ReadLine();
                if (userInput == "1")
                {
                    try
                    {
                        Console.WriteLine("\nPlease enter the product code:");
                        string productCode = Console.ReadLine();
                        Product.ValidateCode(productCode);

                        Console.WriteLine("Please enter the product name:");
                        string name = Console.ReadLine();
                        Product.ValidateName(name);

                        Console.WriteLine("Please enter the product description:");
                        string description = Console.ReadLine();
                        Product.ValidateDescription(description);

                        Console.WriteLine("Please enter the product price:");
                        string price = Console.ReadLine();
                        if (!(decimal.TryParse(price, out decimal realPrice)))
                        {
                            throw new ArgumentException("price must be a numeric/decimal value");
                        }
                        Product.ValidatePrice(realPrice);

                        Console.WriteLine("Please enter the product quantity:");
                        string quantity = Console.ReadLine();
                        if (!(int.TryParse(quantity, out int realQuantity)))
                        {
                            throw new ArgumentException("quantity must be a numeric value");
                        }
                        Product.ValidateQuantity(realQuantity);

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

                    using (StreamReader reader = new StreamReader("products_no_id.csv"))
                    {
                        string headerLine = reader.ReadLine();
                        while (!reader.EndOfStream)
                        {
                            try
                            {
                                string line = reader.ReadLine();
                                string[] values = line.Split(',');
                                string productCode = values[0];
                                string name = values[1];
                                string description = values[2];
                                string price = values[3];
                                if (!(decimal.TryParse(price, out decimal realPrice)))
                                {
                                    throw new ArgumentException("price must be a numeric/decimal value");
                                }
                                string quantity = values[4];
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
                                Console.WriteLine("This entry isn't valid because (" + e.Message + ")\n");
                                continue;
                            }

                        }
                    }

                }
                else if (userInput == "3")
                {
                    if (products.Count > 0)
                    {
                        Console.WriteLine("\n--- Available Products ---");

                        string format = "{0,-5} | {1,-12} | {2,-30} | {3,-120} | {4,10} | {5,8}";

                        Console.WriteLine(string.Format(format, "ID", "Code", "Name", "Description", "Price", "Qty"));
                        Console.WriteLine(new string('-', 195));

                        foreach (Product p in products)
                        {
                            Console.WriteLine(format, p.ProductID, p.ProductCode, p.Name, p.Description, p.Price, p.Quantity);
                        }

                        Console.WriteLine(new string('-', 195));
                        Console.WriteLine($"Total products: {products.Count}\n");
                    }
                    else
                    {
                        Console.WriteLine("\nThere are no products yet.\n");
                    }
                }
                else if (userInput == "4")
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