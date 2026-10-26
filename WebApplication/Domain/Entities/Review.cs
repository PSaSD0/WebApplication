using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace WebApplication.Domain.Entities
{
    public class Review
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Напишите текст отзыва")]
        [Display(Name = "Ваш отзыв")]
        [MaxLength(2000)]
        public string? Text { get; set; }

        [Required(ErrorMessage = "Поставьте оценку")]
        [Range(1, 5, ErrorMessage = "Оценка должна быть от 1 до 5")]
        [Display(Name = "Оценка (1-5)")]
        public int Rating { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        // Связь с пользователем
        public string? UserId { get; set; }
        public IdentityUser? User { get; set; }

        // Связь с шаурмечной
        public int ShawarmaPlaceId { get; set; }
        public ShawarmaPlace? ShawarmaPlace { get; set; }
    }
}