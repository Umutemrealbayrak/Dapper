using Microsoft.AspNetCore.Mvc;
using RealEstateDapper.Repositories.CategoryRepository;
using RealEstateDapper.Dtos.CategoryDtos;

namespace RealEstateDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        // ICategoryRepository baðýmlýlýðý doðru þekilde enjekte ediliyor
        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet("categorylist")]
        public async Task<IActionResult> CategoryList()
        {
            var categories = await _categoryRepository.GetAllCategoryAsync();

            // Verilerin null olup olmadýðýný kontrol edin
            if (categories == null)
            {
                return NotFound("No categories found.");
            }

            return Ok(categories);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            _categoryRepository.CreateCategory(createCategoryDto);
            return Ok("baþarýlý");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            _categoryRepository.DeleteCategory(id);
            return Ok("baþarýlý");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            _categoryRepository.UpdateCategory(updateCategoryDto);
            return Ok("Baþarýlý");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id) { 
            var value=await _categoryRepository.GetCategory(id);
            return Ok(value);
        }
    }
    
}
