using WebApplication.Domain.Entities;

namespace WebApplication.Domain.Repositories.Abstract
{
    public interface IReviewRepository
    {
        Task<IEnumerable<Review>> GetReviewsByShawarmaIdAsync(int shawarmaId);
        Task<IEnumerable<Review>> GetReviewsByUserIdAsync(string userId);
        Task SaveReviewAsync(Review entity);
        Task DeleteReviewAsync(int id);
    }
}