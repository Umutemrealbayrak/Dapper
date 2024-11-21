using RealEstateDapper.Dtos.CategoryDtos;
using RealEstateDapper.Models.DapperContext;
using Dapper;

namespace RealEstateDapper.Repositories.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Context _context;
        public CategoryRepository(Context context)
        {
            _context = context;
        }
        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            string query = "SELECT * FROM Category";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCategoryDto>(query);

                // Eğer values null dönerse, burada loglama yapabiliriz
                if (values == null)
                {
                    Console.WriteLine("No categories found.");
                }

                return values.ToList();
            }
        }

        async void ICategoryRepository.CreateCategory(CreateCategoryDto categoryDto)
        {
            string query = "insert into Category (CategoryName,CategoryStatus)values(@CategoryName,@CategoryStatus)";
            var parameters = new DynamicParameters();
            parameters.Add("@CategoryName",categoryDto.CategoryName);
            parameters.Add("@CategoryStatus", true);
            using (var connection = _context.CreateConnection()) { 
               await connection.ExecuteAsync(query, parameters);
            }
        }

        async void ICategoryRepository.DeleteCategory(int id)
        {
            string query = "Delete From Category where CategoryId=@CategoryId";
            var parameters= new DynamicParameters();
            parameters.Add("@CategoryId",id);
            using (var connection = _context.CreateConnection()) { 
                await connection.ExecuteAsync(query, parameters);
            }
        }

        async Task<GetByIDCategoryDto> ICategoryRepository.GetCategory(int id)
        {
            string query = "select * from Category Where CategoryId=@CategoryId";
            var parameters = new DynamicParameters();
            parameters.Add("@CategoryId", id);
            using(var connection = _context.CreateConnection())
            {
                var values=await connection.QueryFirstOrDefaultAsync<GetByIDCategoryDto>(query,parameters);
                return values;

            }

        }

        async void ICategoryRepository.UpdateCategory(UpdateCategoryDto categoryDto)
        {
            string query = "UPDATE Category SET CategoryName = @CategoryName, CategoryStatus = @CategoryStatus WHERE CategoryID = @CategoryId";
            var parameters = new DynamicParameters();

            // Parametrelerin doğru şekilde eklenmesi
            parameters.Add("@CategoryName", categoryDto.CategoryName);
            parameters.Add("@CategoryStatus", categoryDto.CategoryStatus);
            parameters.Add("@CategoryId", categoryDto.CategoryID); // Eksik olan parametreyi ekledik

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

    }
}
