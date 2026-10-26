using WebApplication.Domain.Entities;

namespace WebApplication.Domain.Repositories.Abstract
{
    public interface IDistrictRepository
    {
        Task<IEnumerable<District>> GetDistrictsAsync();
        Task<District?> GetDistrictByIdAsync(int id);
        Task SaveDistrictAsync(District entity);
        Task DeleteDistrictAsync(int id);
    }
}