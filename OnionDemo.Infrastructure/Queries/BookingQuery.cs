using Microsoft.EntityFrameworkCore;
using OnionDemo.Application.Queries.BookingQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionDemo.Domain.Entity;

namespace OnionDemo.Infrastructure.Queries
{
    public class BookingQuery(BookMyHomeContext db) : IBookingQuery
    {
        BookingDto IBookingQuery.GetBooking(int accommodationId,int bookingId)
        {
            var accommodation = db.Accommodations.Include(b => b.Bookings).AsNoTracking()
                .Single(a => a.Id == accommodationId);
            var booking = db.Bookings.AsNoTracking().Single(b => b.Id == bookingId);
            
            
            return new BookingDto
            {
                Id = booking.Id,
                StartDate = booking.StartDate,
                EndDate = booking.EndDate,
                AccommodationId = accommodation.Id,
                RowVersion = booking.RowVersion
            };
        }

        IEnumerable<BookingDto> IBookingQuery.GetBookings(int accommodationId)
        {
            var accommodation = db.Accommodations.Include(b => b.Bookings).AsNoTracking()
                .Single(a => a.Id == accommodationId);
            var result = db.Bookings.AsNoTracking().Select(a => new BookingDto
            {
                Id = a.Id,
                StartDate = a.StartDate,
                EndDate = a.EndDate,
                AccommodationId = accommodation.Id,
                RowVersion = a.RowVersion
            });
            return result;
        }
    }
}
