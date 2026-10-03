using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class ProductRepository
    {
        private readonly List<Product> _products = new List<Product>();
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
}
