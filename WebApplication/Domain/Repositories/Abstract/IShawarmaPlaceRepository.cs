using WebApplication.Domain.Entities;

namespace WebApplication.Domain.Repositories.Abstract
{
    public interface IShawarmaPlaceRepository
    {
        Task<IEnumerable<ShawarmaPlace>> GetShawarmaPlacesAsync();
        Task<ShawarmaPlace?> GetShawarmaPlaceByIdAsync(int id);
        Task SaveShawarmaPlaceAsync(ShawarmaPlace entity);
        Task DeleteShawarmaPlaceAsync(int id);
    }
}