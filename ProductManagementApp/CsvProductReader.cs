using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementApp
{
    internal class CsvProductReader
    {
        public static void ReadFromCsv(string csvPath, ProductRepository productRepository)
        {
            using (StreamReader reader = new StreamReader(csvPath))
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
                        productRepository.Add(product);

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
    }
}
