using System.ComponentModel.DataAnnotations;
using WebApplication.Domain.Entities;
using WebApplication.Domain.Enums;

namespace WebApplication.Domain.Entities
{
    public class ShawarmaPlace : EntityBase
    {
        [Display(Name = "Район города")]
        public int? DistrictId { get; set; }
        public District? District { get; set; }

        [Display(Name = "Краткое описание")]
        [MaxLength(3000)]
        public string? ShortDescription { get; set; }

        [Display(Name = "Адрес")]
        [MaxLength(200)]
        public string? Address { get; set; }

        [Display(Name = "Фото шаурмы")]
        public string? Photo { get; set; }

        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}