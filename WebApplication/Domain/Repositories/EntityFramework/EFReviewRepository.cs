using Microsoft.EntityFrameworkCore;
using WebApplication.Domain.Entities;
using WebApplication.Domain.Repositories.Abstract;

namespace WebApplication.Domain.Repositories.EntityFramework
{
    public class EFReviewRepository : IReviewRepository
    {
        private readonly AppDbContext _context;
        public EFReviewRepository(AppDbContext context) { _context = context; }

        public async Task<IEnumerable<Review>> GetReviewsByShawarmaIdAsync(int shawarmaId)
            => await _context.Reviews.Include(x => x.User).Where(x => x.ShawarmaPlaceId == shawarmaId).OrderByDescending(x => x.DateCreated).ToListAsync();

        public async Task<IEnumerable<Review>> GetReviewsByUserIdAsync(string userId)
            => await _context.Reviews.Include(x => x.ShawarmaPlace).Where(x => x.UserId == userId).OrderByDescending(x => x.DateCreated).ToListAsync();

        public async Task SaveReviewAsync(Review entity)
        {
            _context.Entry(entity).State = entity.Id == default ? EntityState.Added : EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}