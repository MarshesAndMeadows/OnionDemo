using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionDemo.Domain.Entity
{
    public class Accomodation
    {
        public int Id { get; private set; }

        public IEnumerable<Booking> Bookings { get; private set; }
    }
}
