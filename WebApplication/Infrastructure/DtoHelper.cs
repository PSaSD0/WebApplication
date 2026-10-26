using WebApplication.Domain.Entities;
using WebApplication.Models;

namespace WebApplication.Infrastructure
{
    public static class DtoHelper
    {
        public static ShawarmaDto ShawarmaToDto(ShawarmaPlace entity)
        {
            double avgRating = entity.Reviews != null && entity.Reviews.Any()
                ? entity.Reviews.Average(r => r.Rating)
                : 0;

            return new ShawarmaDto
            {
                Id = entity.Id,
                Title = entity.Title,
                ShortDescription = entity.ShortDescription,
                Address = entity.Address,
                Photo = entity.Photo,
                DistrictName = entity.District?.Title,
                AverageRating = Math.Round(avgRating, 1)
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