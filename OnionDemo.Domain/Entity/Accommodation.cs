namespace OnionDemo.Domain.Entity
{
    public class Accommodation : DomainEntity
    {
        private List<Booking> _bookings;
        protected Accommodation() 
        {
            _bookings = new List<Booking>();
        }
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
            var accommodation = new Accommodation(host, address);
            return accommodation;
        }

        public void AddBooking(Guest guest, DateOnly startDate, DateOnly endDate)
        {
            var booking = Booking.Create(guest, startDate, endDate, Bookings);
            if (_bookings == null)
            {
                _bookings = new List<Booking>();
            }
            _bookings.Add(booking);
        }

        public Booking UpdateBooking(Guest guest, int bookingId, DateOnly startDate, DateOnly endDate)
        {
            var booking = Bookings.FirstOrDefault(b => b.Id == bookingId);
            if (booking == null) throw new ArgumentException("Booking not found");
            booking.Update(guest, startDate, endDate, Bookings);
            return booking;
        }
    }
}
