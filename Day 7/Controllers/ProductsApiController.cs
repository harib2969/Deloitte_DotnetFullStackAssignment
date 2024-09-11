using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication7.Models;
namespace WebApplication7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsApiController : ControllerBase
    {
        SalesDbContext _context;
        public ProductsApiController(SalesDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult DisplayProducts()
        {
            List<Product> products = _context.Products.ToList();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public IActionResult getProductById(int id)
        {
            Product productObj = _context.Products.Find(id);
            if (productObj != null)
            {
                return Ok(productObj);
            }
            else
            { return NotFound(new {status="Product is not found!"}); }
        }

        [HttpPost]
        public IActionResult AddProduct(Product product) { 
            _context.Products.Add(product);
            _context.SaveChanges();
            return Ok(new {status="New product added to the database successfully..."});
        }

        [HttpPut]
        public IActionResult EditProduct(Product product) { 
            _context.Products.Update(product);
            _context.SaveChanges();
            return Ok(new { status = "Product details updated to the database successfully..." });

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id) {
            Product productObj = _context.Products.Find(id);
            if (productObj != null)
            {
                _context.Products.Remove(productObj);
                _context.SaveChanges();
                return Ok(new { status = "Product deleted from the database successfully..." });
            }
            else
            { return NotFound(new { status = "Product is not found!" }); }
            
        }
    }
}
