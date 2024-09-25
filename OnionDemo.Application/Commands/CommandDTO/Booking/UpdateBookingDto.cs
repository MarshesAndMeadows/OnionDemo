using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace OnionDemo.Application.Commands.CommandDTO.Booking
{
    public record UpdateBookingDto
    {
        public int Id { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public int AccommodationId { get; internal set; }
        public byte[] RowVersion { get; set; }
        public int reviewId { get; set; }
    }
}
