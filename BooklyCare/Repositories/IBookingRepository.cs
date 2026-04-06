using BooklyCare.Models;

namespace BooklyCare.Repositories
{
    public interface IBookingRepository
    {
        Task AddAsync(Booking booking);
        Task<Booking?> GetByIdAsync(Guid id);
        Task<List<Booking>> GetConflictingBookings(
            Guid resourceId, DateTime start, DateTime end);
        Task SaveChangesAsync();
    }
}
