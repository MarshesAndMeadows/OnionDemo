using OnionDemo.Application.Queries.BookingQuery;
using OnionDemo.Domain.Entity;

namespace OnionDemo.Application.Queries.AccommodationQuery
{
    public record AccommodationDTO
    {
        public int Id { get; set; }
        public Host Host { get; set; }
        public IEnumerable<BookingDto> Bookings { get; set; }
        public int HostId { get; set; }
    }
}
