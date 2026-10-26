using WebApplication.Domain.Entities;

namespace WebApplication.Domain.Entities
{
    public class District : EntityBase
    {
        public ICollection<ShawarmaPlace> ShawarmaPlaces { get; set; } = new List<ShawarmaPlace>();
    }
}