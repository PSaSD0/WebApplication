using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class AddReviewViewModel
    {
        public int ShawarmaPlaceId { get; set; }

        [Required(ErrorMessage = "Напишите текст отзыва")]
        [Display(Name = "Текст отзыва")]
        public string? Text { get; set; }
    }
}