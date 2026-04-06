namespace BooklyCare.Models
{
    public class CreateBookingRequest
    {
        public Guid ResourceId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Capacity { get; set; } = 1;
    }
}
