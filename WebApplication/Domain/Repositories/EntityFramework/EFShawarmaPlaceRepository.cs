using Microsoft.EntityFrameworkCore;
using WebApplication.Domain;
using WebApplication.Domain.Entities;
using WebApplication.Domain.Repositories.Abstract;

namespace WebApplication.Domain.Repositories.EntityFramework
{
    public class EFShawarmaPlaceRepository : IShawarmaPlaceRepository
    {
        private readonly AppDbContext _context;
        public EFShawarmaPlaceRepository(AppDbContext context) { _context = context; }

        public async Task<IEnumerable<ShawarmaPlace>> GetShawarmaPlacesAsync()
            => await _context.ShawarmaPlaces.Include(x => x.District).ToListAsync();

        public async Task<ShawarmaPlace?> GetShawarmaPlaceByIdAsync(int id)
            => await _context.ShawarmaPlaces.Include(x => x.District).FirstOrDefaultAsync(x => x.Id == id);

        public async Task SaveShawarmaPlaceAsync(ShawarmaPlace entity)
        {
            _context.Entry(entity).State = entity.Id == default ? EntityState.Added : EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteShawarmaPlaceAsync(int id)
        {
            _context.Entry(new ShawarmaPlace { Id = id }).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}