public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Product> GetAllProducts()
    {
        return _context.Products.ToList();
    }

    public Product GetProductById(int productId)
    {
        return _context.Products.Find(productId);
    }

    public void AddProduct(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
    }

    public void UpdateProduct(Product product)
    {
        _context.Products.Update(product);
        _context.SaveChanges();
    }

    public void DeleteProduct(int productId)
    {
        var product = _context.Products.Find(productId);
        if (product != null)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }
    }

    public IEnumerable<Product> GetProductsByCategory(string category)
    {
        return _context.Products.Where(p => p.Category == category).ToList();
    }

    public IEnumerable<Product> GetOutOfStockProducts()
    {
        return _context.Products.Where(p => p.Quantity == 0).ToList();
    }

    public IEnumerable<Product> GetProductsInRange(int minPrice, int maxPrice)
    {
        return _context.Products.Where(p => p.UnitPrice >= minPrice && p.UnitPrice <= maxPrice).ToList();
    }

    public IEnumerable<string> GetAllCategories()
    {
        return _context.Products.Select(p => p.Category).Distinct().ToList();
    }
}
