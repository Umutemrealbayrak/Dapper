using Dapper;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstateDapper.Dtos.CategoryDtos;
using RealEstateDapper.Dtos.ProductDtos;
using RealEstateDapper.Models.DapperContext;

namespace RealEstateDapper.Repositories.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        
            private readonly Context _context;
            public ProductRepository(Context context)
            {
                _context = context;
            }

        async Task<List<ResultProductDto>> IProductRepository.GetAllProductAsync()
        {
            string query = "SELECT * FROM Product";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductDto>(query);

                // Eğer values null dönerse, burada loglama yapabiliriz
                if (values == null)
                {
                    Console.WriteLine("No categories found.");
                }

                return values.ToList();
            }
        }

        async Task<List<ResultProductWithCategoryDto>> IProductRepository.GetAllProductWithCategoryAsync()
        {
            string query = "SELECT ProductID,Title,Price,City,District,CategoryName FROM Product inner join Category on Product.ProductCategory=Category.CategoryId";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query);

                // Eğer values null dönerse, burada loglama yapabiliriz
                if (values == null)
                {
                    Console.WriteLine("No categories found.");
                }

                return values.ToList();
            }
        }
    }
}
