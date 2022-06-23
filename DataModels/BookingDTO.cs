namespace BookMyShowAPIDapper.DataModels
{
    public class BookingDTO
    {
        public int RequiredSeats { get; set; }
        public string BookingDate { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public int ShowId { get; set; }
        public string StartTime { get; set; }
        public int HallId { get; set; }
        public string HallName { get; set; }
        public int MovieId { get; set; }
        public string Title { get; set; }
    }
}
