using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp1
{
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

                    string cmdText = "SELECT * FROM PRODUCT";

                    SqlDataAdapter adapter = new SqlDataAdapter(cmdText, connStr);
                    DataSet ds = new DataSet();

                    adapter.Fill(ds);
                    Console.WriteLine("Product details:");
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString());
                    }

            };
            Console.ReadLine();

        }
    }

}
