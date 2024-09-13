using OnionDemo.Application.Query.QueryDTO;
using OnionDemo.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionDemo.Application.AccommodationCommand.CommandDTO
{
    public record UpdateAccommodationDto
    {
        public int Id { get; set; }
        public List<BookingDto> Bookings { get; set; }
        public Host Host { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
