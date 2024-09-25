using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OnionDemo.Domain.Entity
{
    public class Review : DomainEntity
    {
        private Booking Booking { get; set; }
        private int Rating { get; set; }
        private string Blurb { get; set; }

        void Create(int bookingId, int rating, string blurb)
        {
            //create new rating, find the booking, attach review to the booking.

            var booking = _db.Bookings.Single(a => a.Id == bookingId);
            var review = new Review(booking, rating, blurb);
        }

    }
}
