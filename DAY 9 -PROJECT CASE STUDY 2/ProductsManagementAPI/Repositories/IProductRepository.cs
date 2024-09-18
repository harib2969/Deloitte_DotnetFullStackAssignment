public interface IProductRepository
{
    IEnumerable<Product> GetAllProducts();
    Product GetProductById(int productId);
    void AddProduct(Product product);
    void UpdateProduct(Product product);
    void DeleteProduct(int productId);
    IEnumerable<Product> GetProductsByCategory(string category);
    IEnumerable<Product> GetOutOfStockProducts();
    IEnumerable<Product> GetProductsInRange(int minPrice, int maxPrice);
    IEnumerable<string> GetAllCategories();
}
