using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionDemo.Application.Commands.CommandDTO.Accommodation
{
    public record CreateAccommodationDto
    {
        public int HostId { get; set; }

        public string Address { get; set; }
    }
}
