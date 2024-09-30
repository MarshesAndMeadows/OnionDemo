using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionDemo.Application.Commands.CommandDTO.Review
{
    public record CreateReviewDto
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Blurb { get; set; }
        public int BookingId { get; set; }
    }
}
