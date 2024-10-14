using Microsoft.EntityFrameworkCore;
using OnionDemo.Application.Queries.BookingQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionDemo.Application.Queries.ReviewQuery;
using OnionDemo.Domain.Entity;
using OnionDemo.Application.Queries.GuestQuery;

namespace OnionDemo.Infrastructure.Queries
{
    public class BookingQuery(BookMyHomeContext db) : IBookingQuery
    {
        BookingDto IBookingQuery.GetBooking(int accommodationId,int bookingId)
        {
            var accommodation = db.Accommodations.Include(b => b.Bookings).ThenInclude(b => b.Guest).AsNoTracking()
                .Single(a => a.Id == accommodationId);
            var booking = accommodation.Bookings.Single(b => b.Id == bookingId);
            return new BookingDto
            {
                Id = booking.Id,
                StartDate = booking.StartDate,
                EndDate = booking.EndDate,
                AccommodationId = accommodation.Id,
                Guest = new GuestDto()
                {
                    Id = booking.Guest.Id,
                    RowVersion = booking.Guest.RowVersion
                },
                Review = booking.Review != null ? new ReviewDto()
                {
                    Blurb = booking.Review.Blurb,
                    Rating = booking.Review.Rating
                } : null,
                //black magic null check
                RowVersion = booking.RowVersion
            };
        }

        IEnumerable<BookingDto> IBookingQuery.GetBookings(int accommodationId)
        {
            var accommodation = db.Accommodations.Include(a => a.Host).Include(a => a.Bookings).ThenInclude(b => b.Guest).AsNoTracking()
                .Single(a => a.Id == accommodationId);
            var result = accommodation.Bookings.Select(booking => new BookingDto
            {
                Id = booking.Id,
                StartDate = booking.StartDate,
                EndDate = booking.EndDate,
                AccommodationId = accommodation.Id,
                Guest = new GuestDto()
                {
                    Id = booking.Guest.Id,
                    RowVersion = booking.Guest.RowVersion
                },
                Review = booking.Review != null ? new ReviewDto()
                {
                    Blurb = booking.Review.Blurb,
                    Rating = booking.Review.Rating
                } : null,
                //black magic null check
                RowVersion = booking.RowVersion
            });
            return result;
        }
    }
}
