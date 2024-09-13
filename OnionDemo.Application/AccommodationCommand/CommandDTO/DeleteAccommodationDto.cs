using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionDemo.Application.AccommodationCommand.CommandDTO
{
    public record DeleteAccommodationDto
    {
        public int Id { get; set; }

        public byte[] RowVersion { get; set; }
    }
}
