using System;
using System.Collections.Generic;
using System.Data;
using Dapper;

namespace BestBuyBestPractices
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
            return _connection.Query<Product>("SELECT * FROM Departments;");
        }

        public void CreateProduct(string name, double price, int categoryID)
        {
            _connection.Execute("INSERT INTO PRODUCTS (Name, price, categoryID) VALUES (@productName, @productPrice, @productCategoryID);",
            new { productName = name, productPrice = price, productCategoryID = categoryID });
        }

        public void UpdateProduct(string newName, double newPrice, int newCategoryID)
        {
            _connection.Execute("UPDATE PRODUCTS SET name = @newName2, price = newPrice2, categoryID = newCategoryID2 WHERE categoryID =  1 ORDER BY CaetegoryID DESC",
            new { newName2 = newName, newPrice2 = newPrice, newCategoryID2 = newCategoryID });
        }

    }
}
