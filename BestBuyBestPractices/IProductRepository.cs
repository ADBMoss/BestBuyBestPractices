using System;
using System.Collections.Generic;

namespace BestBuyBestPractices
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAllProducts();
        public void CreateProduct(string name, decimal price, int categoryID);
    }
}
