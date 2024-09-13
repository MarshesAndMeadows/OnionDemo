using OnionDemo.Application.Query.QueryDTO;
using OnionDemo.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionDemo.Application.AccommodationCommand.CommandDTO
{
    public class CreateAccommodationDto
    {
        public List<BookingDto> Bookings { get; set; }

        public HostDto Host { get; set; }
    }
}
