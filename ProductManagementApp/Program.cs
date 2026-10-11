
using ProductManagementApp.Factories;
using ProductManagementApp.Repositories;
using ProductManagementApp.Services;
using ProductManagementApp.Services.Interfaces;
using ProductManagementApp.Validation;

// Composition root
IProductService productService = new ProductService(
    new ProductRepository(),
    new ProductValidator()
);

bool running = true;
while (running)
{
    Console.WriteLine("Choose from the menu:");
    Console.WriteLine("  1. Add a product manually");
    Console.WriteLine("  2. Add products from CSV file");
    Console.WriteLine("  3. Display all products (Console)");
    Console.WriteLine("  4. Export all products to JSON");
    Console.WriteLine("  5. Exit");

    string? userInput = Console.ReadLine();
    Console.WriteLine();

    if (userInput == "1")
    {
        try
        {
            var reader = ProductReaderFactory.Create(ReaderType.Console);
            var result = productService.AddProductFromReader(reader);

            if (result.IsValid)
            {
                Console.WriteLine("Product added successfully.\n");
            }
            else
            {
                Console.WriteLine("Product could not be added due to the following errors:");
                foreach (string error in result.Errors)
                    Console.WriteLine($"  - {error}");
                Console.WriteLine();
            }
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"Input error: {ex.Message}\n");
        }
    }
    else if (userInput == "2")
    {
        string csvPath = Path.Combine(AppContext.BaseDirectory, "products_no_id.csv");
        var reader = ProductReaderFactory.Create(ReaderType.Csv);
        var messages = productService.AddProductsFromReader(reader, csvPath);
        foreach (string message in messages)
            Console.WriteLine(message);
        Console.WriteLine();
    }
    else if (userInput == "3")
    {
        var writer = ProductWriterFactory.Create(WriterType.Console);
        productService.DisplayProducts(writer);
    }
    else if (userInput == "4")
    {
        string jsonPath = Path.Combine(AppContext.BaseDirectory, "products.json");
        var writer = ProductWriterFactory.Create(WriterType.Json, jsonPath);
        productService.DisplayProducts(writer);
    }
    else if (userInput == "5")
    {
        running = false;
    }
    else
    {
        Console.WriteLine("Please enter a valid option.\n");
    }
}

