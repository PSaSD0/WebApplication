using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class AddReviewViewModel
    {
        public int ShawarmaPlaceId { get; set; }

        [Required(ErrorMessage = "Поставьте оценку")]
        [Range(1, 5, ErrorMessage = "Оценка должна быть от 1 до 5")]
        public int Rating { get; set; }

        [Required(ErrorMessage = "Напишите текст отзыва")]
        public string? Text { get; set; }
    }
}