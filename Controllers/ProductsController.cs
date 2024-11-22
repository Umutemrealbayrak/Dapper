using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateDapper.Repositories.CategoryRepository;
using RealEstateDapper.Repositories.ProductRepository;

namespace RealEstateDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        // ICategoryRepository bağımlılığı doğru şekilde enjekte ediliyor
        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpGet("productlist")]
        public async Task<IActionResult> ProductList()
        {
            var products = await _productRepository.GetAllProductAsync();

            // Verilerin null olup olmadığını kontrol edin
            if (products == null)
            {
                return NotFound("No categories found.");
            }

            return Ok(products);
        }
        [HttpGet("ProductListWithCategory")]
        public async Task<IActionResult> ProductListWithCategory()
        {
            var products = await _productRepository.GetAllProductWithCategoryAsync();

            // Verilerin null olup olmadığını kontrol edin
            if (products == null)
            {
                return NotFound("No categories found.");
            }

            return Ok(products);
        }
    }
}
