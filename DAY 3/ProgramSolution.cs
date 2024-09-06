using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }

        public double UnitPrice { get; set; }

        public int Quantity{ get; set; }
        public string Category { get; set; }

        public override string ToString()
        {
            return string.Format("\n Product Id: {0} \n Product Name: {1} \n Unit Price: {2} \n Quantity: {3}, Category: {4} \n",ProductId,Name,UnitPrice,Quantity,Category);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {

            List<Product> products = new List<Product>();

            Console.WriteLine("Enter 5 Product Details\n");
            Product product;
            for (int i = 1; i < 6; i++)
            {
                Console.WriteLine($"Enter details of Product {i}");
                product= new Product();  
                Console.WriteLine("Enter Product ID:");
                product.ProductId = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter Product Name:");
                product.Name = Console.ReadLine();

                Console.WriteLine("Enter Unit Price:");
                product.UnitPrice = double.Parse(Console.ReadLine());

                Console.WriteLine("Enter Quantity:");
                product.Quantity= int.Parse(Console.ReadLine());

                Console.WriteLine("Enter Product Category:");
                product.Category = Console.ReadLine();

                products.Add(product);

            }

            Console.WriteLine("Details of 5 products:\n");
       
            foreach (Product p in products)
            {
                Console.WriteLine(p.ToString());
            }


            Console.ReadLine();
        }
    }

}
