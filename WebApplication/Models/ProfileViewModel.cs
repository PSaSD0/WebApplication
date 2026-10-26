namespace WebApplication.Models
{
    public class ProfileViewModel
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public IEnumerable<ReviewDto> Reviews { get; set; } = new List<ReviewDto>();
    }

    public class ReviewDto
    {
        public int Id { get; set; }
        public string? Text { get; set; }
        public DateTime DateCreated { get; set; }
        public string? ShawarmaPlaceTitle { get; set; }
        public int ShawarmaPlaceId { get; set; }
    }
}