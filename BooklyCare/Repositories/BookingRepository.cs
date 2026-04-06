using BooklyCare.Db;
using BooklyCare.Models;
using Microsoft.EntityFrameworkCore;

namespace BooklyCare.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly AppDbContext _context;

        public BookingRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Booking booking)
        {
            await _context.Bookings.AddAsync(booking);
        }

        public async Task<Booking?> GetByIdAsync(Guid id)
        {
            return await _context.Bookings.FindAsync(id);
        }

        public async Task<List<Booking>> GetConflictingBookings(
            Guid resourceId, DateTime start, DateTime end)
        {
            return await _context.Bookings
                .Where(b =>
                    b.ResourceId == resourceId &&
                    b.Status == "ACTIVE" &&
                    b.StartTime < end &&
                    b.EndTime > start)
                .ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
