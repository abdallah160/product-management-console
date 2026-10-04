using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductRepository productRepository = new ProductRepository();
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
                        productRepository.Add(product);
                        Console.WriteLine("Product #" + product.ProductID + " added successfully\n");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message + ", please try again\n");
                    }

                }
                else if (userInput == "2")
                {
                    CsvProductReader.ReadFromCsv("products_no_id.csv", productRepository);
                    
                }
                else if (userInput == "3")
                {
                    IReadOnlyList<Product> products = productRepository.GetAll();
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