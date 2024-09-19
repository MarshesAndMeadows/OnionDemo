
using OnionDemo.Domain.DomainServices;

namespace OnionDemo.Domain.Entity
{
    public class Accommodation : DomainEntity
    {
        protected Accommodation(){}

        private Accommodation (Host host)
        {
            Host = host;
        }
        public List<Booking> Bookings { get; private set; }
        public Host Host { get; private set; }

        public static Accommodation Create(Host host)
        {
            return new Accommodation(host);
        }
        public void Update(Accommodation accommodation, byte[] rowVersion)
        {
            Bookings = accommodation.Bookings;
            Host = accommodation.Host;
        }

    }
}
