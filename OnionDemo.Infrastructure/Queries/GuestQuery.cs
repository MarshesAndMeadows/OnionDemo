using Microsoft.EntityFrameworkCore;
using OnionDemo.Application.Queries.AccommodationQuery;
using OnionDemo.Application.Queries.BookingQuery;
using OnionDemo.Application.Queries.GuestQuery;
using OnionDemo.Application.Queries.HostQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionDemo.Infrastructure.Queries
{
    public class GuestQuery(BookMyHomeContext db) : IGuestQuery
    {
        GuestDto IGuestQuery.GetBookings(int guestId)
        {
            var guest = db.Guests
                .Include(b => b.Bookings)
                .FirstOrDefault(g => g.Id == guestId);

            if (guest == null) return null;

            return new GuestDto
            {
                Id = guest.Id,
                Bookings = (List<BookingDto>)db.Bookings.Select(b => new BookingDto
                {
                    Id = b.Id,
                    StartDate = b.StartDate,
                    EndDate = b.EndDate,
                    RowVersion = b.RowVersion
                })
            };
        }
    }
}
