using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Prodcut
    {
        public static int counter = 0;
        private int _productId;
        private string _productCode;
        private string _name;
        private string _description;
        private decimal _price;
        private int _quantity;
        public Prodcut(int productID, string productCode, string name, string description, decimal price, int quantity)
        {




        }

        public int ProductID { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
