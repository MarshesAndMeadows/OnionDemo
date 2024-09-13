
using OnionDemo.Domain.DomainServices;

namespace OnionDemo.Domain.Entity
{
    public class Accommodation : DomainEntity
    {
        protected Accommodation(){}

        private Accommodation(List<Booking> bookings, Host host)
        {
            Bookings = bookings;
            Host = host;
        }
        public List<Booking> Bookings { get; private set; }
        public Host Host { get; private set; }

        public static Accommodation Create(List<Booking> bookings, Host host)
        {
            return new Accommodation(bookings, host);
        }
        public void Update(Accommodation accommodation)
        {
            Bookings = accommodation.Bookings;
            Host = accommodation.Host;
        }
    }
}
