using System.ComponentModel.DataAnnotations;

namespace BookMyShowAPIDapper.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int Duration { get; set; }
        [Required]
        public string Language { get; set; }
        [Required]
        public string Dimension { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public int Price { get; set; }
    }
}
