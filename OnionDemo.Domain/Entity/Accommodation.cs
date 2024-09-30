﻿
namespace OnionDemo.Domain.Entity
{
    public class Accommodation : DomainEntity
    {
        private readonly List<Booking>? _bookings;
        protected Accommodation() { }

        protected Accommodation(Host host)
        {
            Host = host;
        }

        public Host Host { get; protected set; }

        public string Address { get; protected set; }

        public IReadOnlyCollection<Booking> Bookings => _bookings;

        public static Accommodation Create(Host host)
        {
            return new Accommodation(host);
        }

        public void AddBooking(DateOnly startDate, DateOnly endDate)
        {
            var booking = Booking.Create(startDate, endDate, Bookings);
            _bookings.Add(booking);
        }

        public Booking UpdateBooking(int bookingId, DateOnly startDate, DateOnly endDate, Review review)
        {
            var booking = Bookings.FirstOrDefault(b => b.Id == bookingId);
            if (booking == null) throw new ArgumentException("Booking not found");
            booking.Update(startDate, endDate, review, Bookings);
            return booking;
        }
        public Booking UpdateBooking(int bookingId, DateOnly startDate, DateOnly endDate)
        {
            var booking = Bookings.FirstOrDefault(b => b.Id == bookingId);
            if (booking == null) throw new ArgumentException("Booking not found");
            booking.Update(startDate, endDate, Bookings);
            return booking;
        }
    }
}
