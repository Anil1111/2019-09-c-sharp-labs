﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;

namespace ConsoleApp1
{
    class Program
    {
        static List<Product> products;
        static List<Category> categories;

        static void Main(string[] args)
        {
            /*
            using (var db = new NorthwindEntities())
            {
                products = db.Products.ToList();
                categories = db.Categories.ToList();
            }

            Console.WriteLine("" + 
                $"{"Product ID", -12}{"Product Name",-40}{"Category Name",-20}{"Units in Stock",-12}");

            products.ForEach(p => { Console.WriteLine("" + 
                $"{p.ProductID,-12}{p.ProductName,-40}{p.Category.CategoryName,-20}{p.UnitsInStock,-12}"); });
                */

            string queryString = "";
            string connectionString = "Server=(localdb)\\MSSQLLocalDB";

            if (File.Exists("instnwnd.sql"))
            {
                queryString = File.ReadAllText("instnwnd.sql");
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                //command.Parameters.AddWithValue("@tPatSName", "Your-Parm-Value");
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(String.Format("{0}, {1}",
                        reader["tPatCulIntPatIDPk"], reader["tPatSFirstname"]));// etc
                    }
                }
                finally
                {
                    // Always call Close when done reading.
                    reader.Close();
                }
            }

            
        }


    }
}
