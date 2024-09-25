using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionDemo.Application.Commands.CommandDTO.Booking
{
    public record CreateBookingDto
    {
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public int AccommodationId { get; set; }
    }
}
