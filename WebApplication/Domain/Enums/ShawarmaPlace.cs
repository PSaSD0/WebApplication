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

        [Display(Name = "Полный текст отзыва")]
        [MaxLength(100000)]
        public string? Description { get; set; }

        [Display(Name = "Фото шаурмы")]
        public string? Photo { get; set; }

        [Display(Name = "Оценка")]
        public RatingEnum Rating { get; set; }
    }
}