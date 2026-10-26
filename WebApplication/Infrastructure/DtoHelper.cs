using WebApplication.Domain.Entities;
using WebApplication.Models;

namespace WebApplication.Infrastructure
{
    public static class DtoHelper
    {
        public static ShawarmaDto ShawarmaToDto(ShawarmaPlace entity)
        {
            return new ShawarmaDto
            {
                Id = entity.Id,
                Title = entity.Title,
                ShortDescription = entity.ShortDescription,
                Description = entity.Description,
                Photo = entity.Photo,
                DistrictName = entity.District?.Title,
                Rating = entity.Rating.ToString()
            };
        }

        public static IEnumerable<ShawarmaDto> ShawarmasToDto(IEnumerable<ShawarmaPlace> entities)
        {
            var list = new List<ShawarmaDto>();
            foreach (var entity in entities)
                list.Add(ShawarmaToDto(entity));
            return list;
        }
    }
}