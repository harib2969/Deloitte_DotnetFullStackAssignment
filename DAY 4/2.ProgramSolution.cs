using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

        public int Quantity { get; set; }
        public string Category { get; set; }

        public override string ToString()
        {
            return string.Format("\n Product Id: {0} \n Product Name: {1} \n Unit Price: {2} \n Quantity: {3}, Category: {4} \n", ProductId, Name, UnitPrice, Quantity, Category);
        }
    }
        internal class Program
    {
        static void Main(string[] args)
        {

            string connStr = "Server=USHYDCVENKATAK1\\SQLSERVER2022; Database=Sept2024Db; Integrated Security=true";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;

                    Console.WriteLine("Database connected Successfully");
                    Console.WriteLine("Enter Product Details\n");
                    Product product= new Product();
                    
                    Console.WriteLine("Enter Product ID:");
                    product.ProductId = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter Product Name:");
                    product.Name = Console.ReadLine();

                    Console.WriteLine("Enter Unit Price:");
                    product.UnitPrice = float.Parse(Console.ReadLine());

                    Console.WriteLine("Enter Quantity:");
                    product.Quantity = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter Product Category:");
                    product.Category = Console.ReadLine();

                    string cmdText = string.Format("INSERT INTO PRODUCT VALUES({0},'{1}',{2},{3},'{4}');",product.ProductId,product.Name,product.UnitPrice,product.Quantity,product.Category);
                    
                    cmd.CommandText = cmdText;

                    int n = cmd.ExecuteNonQuery();  // For DML:  Insert, update, delete

                    Console.WriteLine("Data Inserted Succesfully.\nNo. of rows affected :" + n);
                    conn.Close();

            };
            Console.ReadLine();

        }
    }

}
