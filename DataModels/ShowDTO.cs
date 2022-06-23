namespace BookMyShowAPIDapper.DataModels
{
    public class ShowDTO
    {
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Date { get; set; }
        public int HallId { get; set; }
        public int MovieId { get; set; }
    }
}
