using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;

namespace BestBuyCRUDBestPracticeConsoleAPP
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Configuration
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");
            Console.WriteLine(connString);
            #endregion
            IDbConnection conn = new MySqlConnection(connString);
            DapperDepartmentRepository repo = new DapperDepartmentRepository(conn);
            DapperProductRepository prodrepo = new DapperProductRepository(conn);

            Console.WriteLine("Hello user, here are the current departments:");
            Console.WriteLine("Please press enter to continue. . .");
            Console.ReadLine();
            var depos = repo.GetAllDepartments();
            

         

            Console.WriteLine("Do you want to add a department?");
            string userResponse = Console.ReadLine();

            if(userResponse.ToLower() == "yes")
            {
                Console.WriteLine("What is the name of your new department?");
                userResponse = Console.ReadLine();
                repo.InsertDepartment(userResponse);
                PrintDepartment(repo.GetAllDepartments());
            }

            Console.WriteLine("Here is a list of the current products");
            PrintProduct(prodrepo.GetAllProducts());
            
            Console.WriteLine("Would you like to create a new product?");
            userResponse = Console.ReadLine();

            if (userResponse.ToLower() == "yes")
            {
                Console.WriteLine("What is the name of your product?");
                var productName = Console.ReadLine();

                Console.WriteLine("What is your product price?");
                var productPrice = decimal.Parse(Console.ReadLine());

                Console.WriteLine("What is your products stock level?");
                var productStock = Console.ReadLine();

                Console.WriteLine("Is your product on sale? (Enter 0 for yes 1 for no)");
                var productSale = int.Parse(Console.ReadLine());

                Console.WriteLine("What is your products category ID?");
                var productCatId = int.Parse(Console.ReadLine());

                prodrepo.CreateProduct(productName, productPrice, productCatId, productSale, productStock);
                PrintProduct(prodrepo.GetAllProducts());
            }

            Console.WriteLine("Have a great day!");
        }

        private static void PrintDepartment(IEnumerable<Department> depos )
        {
            foreach (var depo in depos)
            {
                Console.WriteLine($"Id: {depo.DepartmentId} Name: {depo.Name}");
            }
        }

        private static void PrintProduct(IEnumerable<Product> prods)
        {
            foreach (var prod in prods)
            {
                Console.WriteLine($" Id: {prod.productId}, Name: {prod.name}, Price: {prod.price}, CategoryId: {prod.categoryId}, OnSale: {prod.onSale}, StockLevel: {prod.stockLevel}");
            }
        }


    }
}
