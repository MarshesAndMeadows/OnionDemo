using Microsoft.EntityFrameworkCore;
using OnionDemo.Domain.Entity;

namespace OnionDemo.Infrastructure
{
    public class BookMyHomeContext(DbContextOptions<BookMyHomeContext> options) : DbContext(options)
    {
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Accommodation> Accommodations { get; set; }
        public DbSet<Host> Hosts { get; set; }
        public DbSet<Review> Reviews { get; set; }

    }
}
