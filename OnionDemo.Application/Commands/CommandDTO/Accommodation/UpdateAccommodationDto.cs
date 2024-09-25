using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionDemo.Application.Commands.CommandDTO.Accommodation
{
    public record UpdateAccommodationDto
    {
        public int HostId { get; init; }
        public int AccommodationId { get; init; }
    }
}
