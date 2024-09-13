using Microsoft.EntityFrameworkCore;
using OnionDemo.Application.Query;
using OnionDemo.Application.Query.QueryDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionDemo.Infrastructure.Queries
{
    public class BookingQuery(BookMyHomeContext db) : IBookingQuery
    {
        BookingDto IBookingQuery.GetBooking(int id)
        {
            var booking = db.Bookings.AsNoTracking().Single(a => a.Id == id);
            return new BookingDto
            {
                Id = booking.Id,
                StartDate = booking.StartDate,
                EndDate = booking.EndDate,
                RowVersion = booking.RowVersion
            };
        }

        IEnumerable<BookingDto> IBookingQuery.GetBookings()
        {
            var result = db.Bookings.AsNoTracking().
                Select(a => new BookingDto
                {
                    Id = a.Id,
                    StartDate = a.StartDate,
                    EndDate = a.EndDate,
                });
            return result;
        }
    }
}
