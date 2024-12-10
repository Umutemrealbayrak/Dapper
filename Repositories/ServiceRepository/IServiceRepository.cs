using RealEstateDapper.Dtos.ServiceDtos;

namespace RealEstateDapper.Repositories.ServiceRepository
{
    public interface IServiceRepository
    {
        Task<List<ResultServiceDto>> GetAllService();
        Task CreateService(CreateServiceDto createServiceDto);
        Task DeleteService(int id);
        Task UpdateService(UpdateServiceDto updateServiceDto);
        Task<GetByIDServiceDto> GetService(int id);
    }
}
