using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookMyShowAPIDapper.Models
{
    public class Hall
    {
        [Key]
        public int HallId { get; set; }
        [Required]
        public string HallName { get; set; }
        [ForeignKeyAttribute("Movie")]
        public int MovieId { get; set; }
    }
}
