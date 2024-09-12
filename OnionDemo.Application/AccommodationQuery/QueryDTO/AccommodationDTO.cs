using OnionDemo.Application.Query.QueryDTO;
using OnionDemo.Domain.Entity;

namespace OnionDemo.Application.AccommodationQuery.QueryDTO
{
    public record AccommodationDTO
    {
        public int Id { get; set; }
        public Host Host { get; set; }
        public List<BookingDto> Bookings { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
