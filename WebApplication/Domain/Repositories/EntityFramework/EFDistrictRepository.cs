using Microsoft.EntityFrameworkCore;
using WebApplication.Domain;
using WebApplication.Domain.Entities;
using WebApplication.Domain.Repositories.Abstract;

namespace WebApplication.Domain.Repositories.EntityFramework
{
    public class EFDistrictRepository : IDistrictRepository
    {
        private readonly AppDbContext _context;
        public EFDistrictRepository(AppDbContext context) { _context = context; }

        public async Task<IEnumerable<District>> GetDistrictsAsync()
            => await _context.Districts.Include(x => x.ShawarmaPlaces).ToListAsync();

        public async Task<District?> GetDistrictByIdAsync(int id)
            => await _context.Districts.Include(x => x.ShawarmaPlaces).FirstOrDefaultAsync(x => x.Id == id);

        public async Task SaveDistrictAsync(District entity)
        {
            _context.Entry(entity).State = entity.Id == default ? EntityState.Added : EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDistrictAsync(int id)
        {
            _context.Entry(new District { Id = id }).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<bool> HasShawarmaPlacesAsync(int districtId)
        {
            return await _context.ShawarmaPlaces.AnyAsync(x => x.DistrictId == districtId);
        }
    }
}