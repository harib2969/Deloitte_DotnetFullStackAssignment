using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Product ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter Product name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Unit Price: ");
            int price = int.Parse(Console.ReadLine());

            Console.Write("Enter Quantity : ");
            int quantity = int.Parse(Console.ReadLine());


            int tamount = price * quantity;
            int damount;
            if (quantity > 50)
            {
                damount = (30 * tamount) / 100;
            }
            else if (quantity > 30)
            {
                damount = (20 * tamount) / 100;
            }
            else if (quantity > 10)
            {
                damount = (10 * tamount) / 100;
            }
            else
            {
                damount = 0;
            }
            int famount=tamount-damount;
            Console.WriteLine();
            Console.WriteLine("----BILL DETAILS----");
            Console.WriteLine("Total Amount : " + tamount);
            Console.WriteLine("Discount Amount : " + damount);
            Console.WriteLine("Final amount : " + famount);

            Console.ReadLine();
        }
    }
}
