using Microsoft.EntityFrameworkCore;
using OnionDemo.Domain.Entity;

namespace OnionDemo.Infrastructure
{
    public class BookMyHomeContext : DbContext
    {
        public BookMyHomeContext(DbContextOptions<BookMyHomeContext> options)
            :   base(options)
        {    
        }
        public DbSet<Booking> Bookings { get; set; }
    }
}
