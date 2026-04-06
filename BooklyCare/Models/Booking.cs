namespace BooklyCare.Models
{
    public class Booking
    {
        public Guid Id { get; set; }
        public Guid ResourceId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Capacity { get; set; } = 1;

        public string Status { get; set; } = "ACTIVE"; // ACTIVE, CANCELLED
    }
}
