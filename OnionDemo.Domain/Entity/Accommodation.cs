namespace OnionDemo.Domain.Entity
{
    public class Accommodation : DomainEntity
    {
        private readonly List<Booking>? _bookings;
        protected Accommodation() { }
        protected Accommodation(Host host, string address)
        {
            Host = host;
            Address = address;
        }

        public Host Host { get; protected set; }

        public string Address { get; protected set; }

        public IReadOnlyCollection<Booking> Bookings => _bookings;

        public static Accommodation Create(Host host, string address)
        {
            return new Accommodation(host, address);
        }

        public void AddBooking( Guest guest, DateOnly startDate, DateOnly endDate)
        {
            var booking = Booking.Create(guest, startDate, endDate, Bookings);
            _bookings.Add(booking);
        }

        public Booking UpdateBooking(Review review, Guest guest, int bookingId, DateOnly startDate, DateOnly endDate)
        {
            var booking = Bookings.FirstOrDefault(b => b.Id == bookingId);
            if (booking == null) throw new ArgumentException("Booking not found");
            booking.Update(review, guest, startDate, endDate, Bookings);
            return booking;
        }
    }
}
