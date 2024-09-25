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
    public class BookingQuery : IBookingQuery
    {
        private readonly BookMyHomeContext _db;

        public BookingQuery(BookMyHomeContext db)
        {
            _db = db;
        }
        BookingDto IBookingQuery.GetBooking(int accommodationId,int bookingId)
        {
            var accommodation = _db.Accommodations.Include(b => b.Bookings).AsNoTracking()
                .Single(a => a.Id == accommodationId);
            var booking = _db.Bookings.AsNoTracking().Single(b => b.Id == bookingId);
            
            
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
            var accommodation = _db.Accommodations.Include(b => b.Bookings).AsNoTracking()
                .Single(a => a.Id == accommodationId);
            var result = _db.Bookings.AsNoTracking().Select(a => new BookingDto
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
