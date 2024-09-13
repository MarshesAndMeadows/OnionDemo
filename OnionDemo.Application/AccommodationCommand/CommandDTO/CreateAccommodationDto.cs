using OnionDemo.Application.Query.QueryDTO;
using OnionDemo.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionDemo.Application.HostQuery;

namespace OnionDemo.Application.AccommodationCommand.CommandDTO
{
    public record CreateAccommodationDto
    {
        public List<BookingDto> Bookings { get; set; }

        public HostDto Host { get; set; }
    }
}
