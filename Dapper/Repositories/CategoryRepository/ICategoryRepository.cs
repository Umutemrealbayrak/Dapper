using RealEstateDapper.Dtos.CategoryDtos;

namespace RealEstateDapper.Repositories.CategoryRepository
{
    public interface ICategoryRepository
    {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();        
    }
}
