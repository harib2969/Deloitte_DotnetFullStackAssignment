using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public IActionResult GetAllProducts()
    {
        var products = _productService.GetAllProducts();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public IActionResult GetProductById(int id)
    {
        var product = _productService.GetProductById(id);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }

    [HttpPost]
    public IActionResult AddProduct(Product product)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        _productService.AddProduct(product);
        return CreatedAtAction(nameof(GetProductById), new { id = product.ProductId }, product);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateProduct(int id, Product product)
    {
        if (id != product.ProductId)
        {
            return BadRequest();
        }
        _productService.UpdateProduct(product);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteProduct(int id)
    {
        _productService.DeleteProduct(id);
        return NoContent();
    }

    [HttpGet("category/{category}")]
    public IActionResult GetProductsByCategory(string category)
    {
        var products = _productService.GetProductsByCategory(category);
        return Ok(products);
    }

    [HttpGet("outofstock")]
    public IActionResult GetOutOfStockProducts()
    {
        var products = _productService.GetOutOfStockProducts();
        return Ok(products);
    }

    [HttpGet("price")]
    public IActionResult GetProductsInRange([FromQuery] int minPrice, [FromQuery] int maxPrice)
    {
        var products = _productService.GetProductsInRange(minPrice, maxPrice);
        return Ok(products);
    }

    [HttpGet("categories")]
    public IActionResult GetAllCategories()
    {
        var categories = _productService.GetAllCategories();
        return Ok(categories);
    }
}
