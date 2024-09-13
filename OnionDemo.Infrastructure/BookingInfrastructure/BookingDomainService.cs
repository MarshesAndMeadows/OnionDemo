using OnionDemo.Domain.DomainServices;
using OnionDemo.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionDemo.Infrastructure.BookingInfrastructure
{
    public class BookingDomainService(BookMyHomeContext db) : IBookingDomainService
    {
        public IEnumerable<Booking> GetOtherBookings(Booking booking)
        {
            var result = db.Bookings
                .Where(a => a.Id != booking.Id)
                .ToList();
            return result;
        }
    }
}
