using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Text;

namespace BestBuyCRUDBestPracticeConsoleAPP
{
    public class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection;

        public DapperProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }


        public IEnumerable<Product> GetAllProducts()
        {
            var depos = _connection.Query<Product>("SELECT * FROM products");

            return depos;
        }

        public void CreateProduct(string name, int price, int categoryId, int onSale, string stockLevel)
        {
            throw new NotImplementedException();
        }

        
    }
}
