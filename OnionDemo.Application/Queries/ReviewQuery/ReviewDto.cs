using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionDemo.Application.Queries.ReviewQuery
{
    public record ReviewDto
    {
        public int Id { get; set; }
        public string Blurb { get; set; }
        public int Rating { get; set; }
        public byte[] RowVersion { get; set; } = null!;

    }
}
