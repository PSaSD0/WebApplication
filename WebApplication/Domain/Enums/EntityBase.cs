using System.ComponentModel.DataAnnotations;

namespace WebApplication.Domain.Entities
{
    public abstract class EntityBase
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Заполните название")]
        [Display(Name = "Название")]
        public string? Title { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    }
}