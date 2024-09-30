using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionDemo.Domain.Entity
{
    public class Guest : DomainEntity
    {
        private readonly List<Booking>? _bookings;

        protected Guest() { }

        public IReadOnlyCollection<Booking> Bookings => _bookings;
    }
}
