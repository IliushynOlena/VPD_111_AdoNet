using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_LinqToSql
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            ShopClassesDataContext context = new ShopClassesDataContext();
            //CRUD - create update delete read
            //var products = context.Products;
            //foreach (var p in products)
            //{
            //    Console.WriteLine($"Product : {p.Id}  {p.Name}  {p.Price}");
            //}

            //var products = context.Products
            //    .Where(p => p.Price > 300)
            //    .OrderByDescending(p=>p.Price)
            //    .Take(5);

            //var products = (from p in context.Products
            //               where p.Price > 300
            //               orderby p.Price descending                         
            //               select p).Take(5);



            //foreach (var p in products)
            //{
            //    Console.WriteLine($"Product : {p.Id,-10}{p.Name,-25}{p.Price,-20}");
            //}

            var product = new Product()
            {
                Name = "Tenis ball",
                Price = 30,
                Producer = "China",
                CostPrice = 5,
                Quantity = 10,
                TypeProduct = "Sport Equipment"
            };

            //context.Products.InsertOnSubmit(product);
            //context.Products.InsertOnSubmit(new Product() { });

            //context.SubmitChanges();

            //var productToEdit = context.Products.Where(p => p.Id == 4).FirstOrDefault();
            //var productToEdit = context.Products.FirstOrDefault(p => p.Id == 4);
            //productToEdit.Price += 500;

            //context.SubmitChanges();

            var productToDelete = context.Products.FirstOrDefault(p => p.Id == 23);

            if (productToDelete != null)
                context.Products.DeleteOnSubmit(productToDelete);

            context.SubmitChanges();
            var products = context.Products;
            foreach (var p in products)
            {
                Console.WriteLine($"Product : {p.Id}  {p.Name}  {p.Price}");
            }



        }
    }
}
