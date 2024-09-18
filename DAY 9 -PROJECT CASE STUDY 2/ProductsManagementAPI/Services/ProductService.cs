public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public IEnumerable<Product> GetAllProducts()
    {
        return _productRepository.GetAllProducts();
    }

    public Product GetProductById(int productId)
    {
        return _productRepository.GetProductById(productId);
    }

    public void AddProduct(Product product)
    {
        _productRepository.AddProduct(product);
    }

    public void UpdateProduct(Product product)
    {
        _productRepository.UpdateProduct(product);
    }

    public void DeleteProduct(int productId)
    {
        _productRepository.DeleteProduct(productId);
    }

    public IEnumerable<Product> GetProductsByCategory(string category)
    {
        return _productRepository.GetProductsByCategory(category);
    }

    public IEnumerable<Product> GetOutOfStockProducts()
    {
        return _productRepository.GetOutOfStockProducts();
    }

    public IEnumerable<Product> GetProductsInRange(int minPrice, int maxPrice)
    {
        return _productRepository.GetProductsInRange(minPrice, maxPrice);
    }

    public IEnumerable<string> GetAllCategories()
    {
        return _productRepository.GetAllCategories();
    }
}
