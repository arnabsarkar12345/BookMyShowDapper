using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookMyShowAPIDapper.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }
        [Required]
        public int RequiredSeats { get; set; }
        [Required]
        public string BookingDate { get; set; }
        [ForeignKeyAttribute("User")]
        public string Name { get; set; }
        [ForeignKeyAttribute("User")]
        public string Mobile { get; set; }
        [ForeignKeyAttribute("Show")]
        public int ShowId { get; set; }
        [ForeignKeyAttribute("Show")]
        public string StartTime { get; set; }
        [ForeignKeyAttribute("Hall")]
        public int HallId { get; set; }
        [ForeignKeyAttribute("Hall")]
        public string HallName { get; set; }

        [ForeignKeyAttribute("Movie")]
        public int MovieId { get; set; }
        [ForeignKeyAttribute("Movie")]
        public string Title { get; set; }
    }
}
