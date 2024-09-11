using OnionDemo.Application.Query.QueryDTO;


namespace OnionDemo.Application.Query
{
    public interface IBookingQuery
    {
        BookingDto GetBooking(int id);

        IEnumerable<BookingDto> GetBookings();
    }

}
