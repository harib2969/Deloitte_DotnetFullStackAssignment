using System.Collections.Generic;
using ProductApi.Models;

namespace ProductApi.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int id);
        Product AddProduct(Product product);
        Product UpdateProduct(Product product);
        void DeleteProduct(int id);
    }
}
