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
        private Guest(List<Booking> bookings)
        {
            _bookings = bookings;
        }
        public IReadOnlyCollection<Booking> Bookings => _bookings;
        public static Guest Create()
        {
            return new Guest(); 
        }
    }
}
