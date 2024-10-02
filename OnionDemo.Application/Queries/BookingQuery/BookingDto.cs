using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionDemo.Application.Queries.ReviewQuery;

namespace OnionDemo.Application.Queries.BookingQuery
{
    public record BookingDto
    {
        public int Id { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public int AccommodationId { get; set; }
        public ReviewDto Review { get; set; }
        public byte[] RowVersion { get; set; } = null!;
    }
}
