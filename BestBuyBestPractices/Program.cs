using System;
using System.Data;
using System.IO;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Linq;

namespace BestBuyBestPractices
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);


            //Department
            var repo = new DapperDepartmentRepository(conn);
            Console.WriteLine("Type a new Department Name");
            var newDepartment = Console.ReadLine();
            repo.InsertDepartment(newDepartment);
            var departments = repo.GetAllDepartments();
            foreach (var dept in departments)
            {
                Console.WriteLine(dept.Name);
            }


            //Product
            var repo2 = new DapperProductRepository(conn);
            Console.WriteLine("Add a new product name");
            var newProductName = Console.ReadLine();

            Console.WriteLine("Add a new product price");
            var newProductPrice = Console.ReadLine();
            double newProductPrice2 = double.Parse(newProductPrice); 

            Console.WriteLine("Add a new product categoryID");
            var newCategoryID = Console.ReadLine();
            int newCategoryID2 = int.Parse(newCategoryID);
            repo2.CreateProduct(newProductName, newProductPrice2, newCategoryID2);
            var products = repo2.GetAllProducts();
            foreach (var product in products)
            {
                Console.WriteLine($"{product.Name} {product.Price} {product.CategoryID}");
            }


        }
    }
}
