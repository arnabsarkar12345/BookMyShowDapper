using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookMyShowAPIDapper.Models
{
    public class Show
    {
        [Key]
        public int ShowId { get; set; }
        [Required]
        public string StartTime { get; set; }
        [Required]
        public string EndTime { get; set; }
        [Required]
        public string Date { get; set; }
        [ForeignKeyAttribute("Movie")]
        public int HallId { get; set; }
        [ForeignKeyAttribute("Movie")]
        public int MovieId { get; set; }
    }
}
