using BooklyCare.Models;
using Microsoft.EntityFrameworkCore;

namespace BooklyCare.Db
{
    public class AppDbContext : DbContext
    {
        public DbSet<Booking> Bookings { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }
    }
}
