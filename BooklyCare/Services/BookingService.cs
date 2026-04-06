using BooklyCare.Db;
using BooklyCare.Models;
using BooklyCare.Repositories;

namespace BooklyCare.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _repo;
        private readonly AppDbContext _context;

        private const int MAX_CAPACITY = 5; // example

        public BookingService(IBookingRepository repo, AppDbContext context)
        {
            _repo = repo;
            _context = context;
        }

        public async Task<Booking> CreateBooking(CreateBookingRequest request)
        {
            // 🔥 Transaction to prevent race conditions
            using var transaction = await _context.Database.BeginTransactionAsync();

            var conflicts = await _repo.GetConflictingBookings(
                request.ResourceId,
                request.StartTime,
                request.EndTime);

            int usedCapacity = conflicts.Sum(b => b.Capacity);

            if (usedCapacity + request.Capacity > MAX_CAPACITY)
            {
                throw new Exception("Capacity exceeded - double booking prevented");
            }

            var booking = new Booking
            {
                Id = Guid.NewGuid(),
                ResourceId = request.ResourceId,
                StartTime = request.StartTime,
                EndTime = request.EndTime,
                Capacity = request.Capacity
            };

            await _repo.AddAsync(booking);
            await _repo.SaveChangesAsync();

            await transaction.CommitAsync();

            return booking;
        }

        public async Task CancelBooking(Guid id)
        {
            var booking = await _repo.GetByIdAsync(id);

            if (booking == null)
                throw new Exception("Booking not found");

            booking.Status = "CANCELLED";

            await _repo.SaveChangesAsync();
        }

        public async Task<Booking> RescheduleBooking(Guid id, CreateBookingRequest request)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            var booking = await _repo.GetByIdAsync(id);

            if (booking == null)
                throw new Exception("Booking not found");

            // Temporarily cancel current booking
            booking.Status = "CANCELLED";
            await _repo.SaveChangesAsync();

            // Try new slot
            var newBooking = await CreateBooking(request);

            await transaction.CommitAsync();

            return newBooking;
        }

        public async Task<Booking?> GetBookingById(Guid id)
        {
            var booking = await _repo.GetByIdAsync(id);
            return booking;
        }
    }
}
