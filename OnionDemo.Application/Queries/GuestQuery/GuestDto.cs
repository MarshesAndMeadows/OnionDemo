using OnionDemo.Application.Queries.BookingQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionDemo.Application.Queries.GuestQuery
{
    public class GuestDto
    {
        public int Id { get; set; }

        public List<BookingDto> Bookings;
        public byte[] RowVersion { get; set; } = null!;
    }
}
