using BooklyCare.Models;

namespace BooklyCare.Services
{
    public interface IBookingService
    {
        Task<Booking> CreateBooking(CreateBookingRequest request);
        Task CancelBooking(Guid id);
        Task<Booking> RescheduleBooking(Guid id, CreateBookingRequest request);
        Task<Booking?> GetBookingById(Guid id);
    }
}
