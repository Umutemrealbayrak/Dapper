using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstateDapper.Dtos.ProductDtos;

namespace RealEstateDapper.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync();
    }
}
