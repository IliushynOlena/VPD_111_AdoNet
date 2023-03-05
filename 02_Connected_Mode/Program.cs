using _04_data_access;
using _04_data_access.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace _02_Connected_Mode
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=DESKTOP-3HG9UVT\SQLEXPRESS;Initial Catalog=SportShop;
                                    Integrated Security=True;Connect Timeout=2;";
            SportShopDb db = new SportShopDb(connectionString);
            Console.OutputEncoding = Encoding.UTF8;

            Product product = new Product()
            {
                Name = "Boll",
                Type = "Spport equipment",
                Quantity = 3,
                CostPrice = 1500,
                Producer = "China",
                Price = 1200
            };

            Console.WriteLine("Enter namr of product : ");
            string name = Console.ReadLine();
            List<Product> products =  db.GetByName(name);
            foreach (var item in products)
            {
                Console.WriteLine(item.Id + " " + item.Name + " " +
                    item.Producer + " " + item.Price);
            }
            //db.Create(product);
            //var prod = db.GetAll();
            //foreach (var item in prod)
            //{
            //    Console.WriteLine(item.Id + " " + item.Name);
            //}

            //Product p = db.GetOneById(1);
            //p.Price += 500;
            //p.CostPrice += 400;
            //db.Update(p);
            // db.Delete(19);


        }
    }
}
