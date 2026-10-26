namespace WebApplication.Models
{
    public class ShawarmaDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? ShortDescription { get; set; }
        public string? Address { get; set; }
        public string? Photo { get; set; }
        public string? DistrictName { get; set; }
        public double AverageRating { get; set; }
    }
}